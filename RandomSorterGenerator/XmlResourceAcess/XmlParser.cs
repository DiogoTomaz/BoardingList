using System;
using System.Collections.Generic;
using System.Xml.Linq;
using CoachBot.Common;
using System.Xml.Serialization;
using System.Linq;
using System.IO;
using System.Text;
using Microsoft.Xml.Serialization.GeneratedAssembly;

namespace XmlResourceAcess
{
    // TODO: DT: Existe o conceito de trasacção em Xml? (Senão, criar ficheiro temp)
    public class XmlParser
    {
        public Func<IPlayer> GetNewPlayer { get; private set; }
        public Func<IMatch> GetNewMatch { get; private set; }

        public XmlParser(Func<IPlayer> getEmptyPlayer, Func<IMatch> getEmptyMatch)
        {
            GetNewPlayer = getEmptyPlayer;
            GetNewMatch = getEmptyMatch;
        }

        /// <summary>
        /// Parses the Xml document to a List of players
        /// </summary>
        /// <param name="xDoc"></param>
        /// <returns></returns>
        public List<IPlayer> LoadFromRooster(XDocument xDoc)
        {
            List<IPlayer> players = new List<IPlayer>();
            foreach (var playerEl in xDoc.Root.Elements()) // Root element is ignored, all subsequent elements will be players
            {
                PlayerPlayerSerializer ser = new PlayerPlayerSerializer();
                players.Add(this.SerializePlayerToEntity((Player)ser.Deserialize(playerEl.CreateReader())));
            }

            return players;
        }

        /// <summary>
        /// Given a list of players, will update the document
        /// Existing players will be updated, new players in the rooster will be inserted
        /// </summary>        
        public void UpdateRooster(List<IPlayer> rooster, XDocument xDoc)
        {
            if (rooster.Any(p => !p.IsValid()))
                throw new ArgumentException("Rooster provided contains invalid Player(s)");

            var currentRooster = LoadFromRooster(xDoc);
            var newPlayers = rooster.Where(p => !currentRooster.Contains(p));
            var existingPlayers = rooster.Where(p => currentRooster.Contains(p));

            // Add each new player (if all of it's associated guest's exists)
            foreach (var newPlayer in newPlayers)
            {
                foreach(var associatedGuest in newPlayer.AssociatedGuests)
                {
                    if(!currentRooster.Select(x=>x.ID).Contains(associatedGuest.ID) && !newPlayers.Select(x=>x.ID).Contains(associatedGuest.ID))
                        throw new ArgumentException("A new Player has associated guests that do not exists");
                }

                currentRooster.Add(newPlayer);                
            }

            var existingIds = currentRooster.Select(p=>p.ID).ToList();
            foreach (var p in existingPlayers)
            {
                foreach (var associatedGuest in p.AssociatedGuests)
                {
                    if(!currentRooster.Select(x=>x.ID).Contains(associatedGuest.ID))
                        throw new ArgumentException("A existing player in the rooster has associated guests that do not exists");
                }
                
                // At this point all data in the player is valid, simply remove the old player and add the new one
                currentRooster.Remove(currentRooster.Single(x => x.ID == p.ID));
                currentRooster.Add(p);
            }

            xDoc.Root.RemoveAll(); // Clear all players
            var newSerializedRooster = currentRooster.Select
                (p=> 
                    { 
                        return this.SerializeEntityToPlayer(p);
                    }
                );

            // Create a new Element for our current rooster in the XDoc            
            foreach(var serializedPlayer in newSerializedRooster)
                xDoc.Root.Add(ToXElement(serializedPlayer));            
        }


        /// <summary>
        /// Saves a player to the Xml Document. 
        /// If player exists its information is updated, if not will be inserted
        /// </summary>
        /// <param name="player"></param>
        /// <param name="xDoc"></param>
        public void SavePlayerToRooster(IPlayer player, XDocument xDoc)
        {
            // This way we can use our validation coded in the UpdateRooster
            UpdateRooster(new List<IPlayer>() { player }, xDoc);
        }

        /// <summary>
        /// Deletes player from the Xml Document
        /// </summary>       
        public void DeletePlayerFromRooster(IPlayer player, XDocument xDoc)
        {
            xDoc.Root.Elements().Where(el => (string)el.Attribute("id") == player.ID.ToString()).Remove();            
        }

        public void UpdateMatchList(List<IMatch> match, XDocument xDoc)
        {
            // Falta criar ID único para Match, Xsd, regerar,etc            
            throw new NotImplementedException();
        }

        public List<IMatch> GetAllMatches(XDocument xDocument)
        {
            throw new NotImplementedException();
        }

        public void SaveMatch(IMatch match, XDocument xDoc)
        {
            // This way we can use our validations coded in UpdateMatchList
            UpdateMatchList(new List<IMatch>() { match }, xDoc);
        }



        /// <summary>
        /// Ignores All Information of the player, and updates only the Match Statistics        
        /// </summary>
        /// <exception cref="System.ArgumentException">Thrown if a player does not exist</exception>
        public void UpdateStatisticsOnRooster(List<IPlayer> players, XDocument xDoc)
        {
            throw new NotImplementedException();
        }

        public IPlayer GetPlayerFromRooster(Guid id)
        {
            throw new NotImplementedException();
        }

        #region Translation 
        private IPlayer SerializePlayerToEntity(Player playerSerialized)
        {
            var p = this.GetNewPlayer();

            p.ID = ParseGuidWithException(playerSerialized.id);

            p.Name = playerSerialized.Name;
            p.Statistics.Assists = playerSerialized.MatchStatistics.Assists;
            p.Statistics.Goals = playerSerialized.MatchStatistics.Goals;
            p.Statistics.TotalAttendences = playerSerialized.MatchStatistics.TotalAttendences;
            p.Statistics.TotalWaivers = playerSerialized.MatchStatistics.TotalWaivers;

            p.AssociatedGuests = GetEntitiesFromSerializedList(playerSerialized.AssociatedPlayers);

            return p;
        }

        private Player SerializeEntityToPlayer(IPlayer entity)
        {
            var p = new Player();

            p.id = entity.ID.ToString();

            p.Name = entity.Name;
            p.MatchStatistics = new PlayerMatchStatistics();
            p.MatchStatistics.Assists = entity.Statistics.Assists;
            p.MatchStatistics.Goals = entity.Statistics.Goals;
            p.MatchStatistics.TotalAttendences = entity.Statistics.TotalAttendences;
            p.MatchStatistics.TotalWaivers = entity.Statistics.TotalWaivers;            

            // For each Associated guest, create a new PlayerPlayer
            p.AssociatedPlayers = entity.AssociatedGuests.Select(x => { return new PlayerPlayer() { id = x.ID.ToString() }; }).ToList();

            return p;
        }

        private IMatch SerializeMatchToEntity(Match matchSerialized)
        {
            var m = this.GetNewMatch();

            m.AwayResult = matchSerialized.Result.AwayResult;
            m.HomeResult = matchSerialized.Result.HomeResult;

            m.EventTime = matchSerialized.EventTime;
            m.Floor = (TypeOfFlooring)Enum.Parse(typeof(TypeOfFlooring), matchSerialized.PitchType.ToString());

            m.AwayTeam.ID = ParseGuidWithException(matchSerialized.AwayTeam.Team.id);
            m.AwayTeam.Name = matchSerialized.AwayTeam.Team.Name;
            m.AwayTeam.Players = GetPlayersFromSerializedList(matchSerialized.AwayTeam.Team.Players.ToList());
            
            m.HomeTeam.ID = ParseGuidWithException(matchSerialized.HomeTeam.Team.id);
            m.HomeTeam.Name = matchSerialized.HomeTeam.Team.Name;
            m.HomeTeam.Players = GetPlayersFromSerializedList(matchSerialized.HomeTeam.Team.Players.ToList());

            m.LogisticsInformation = matchSerialized.LogisticsInformation;
            m.PitchLocaton = (PitchLocation)Enum.Parse(typeof(PitchLocation), matchSerialized.PitchLocation.ToString());
            m.GeographicalLocation = (GeographicalLocation)Enum.Parse(typeof(GeographicalLocation), matchSerialized.GeographicalLocation.ToString());
            m.PlayerPerTeam = matchSerialized.PlayersPerTeam;
            m.PricePerPerson = matchSerialized.PricePerPerson;
            m.Report = matchSerialized.Report;
            m.TotalPrice = matchSerialized.TotalPrice;
            m.Type = (TypeOfMatch)Enum.Parse(typeof(TypeOfMatch), matchSerialized.Type.ToString());
            m.VenueLocation = matchSerialized.VenueLocation;
            m.WasCanceled = matchSerialized.WasCanceled;

            return m;
        }

        private Guid ParseGuidWithException(string target)
        {
            Guid id;
            if (!Guid.TryParse(target, out id))
                throw new ApplicationException("Unable to parse unique identifier for player");

            return id;
        }

        // TODO: This sort of translation could be avoid if in the schema they share the same type
        private List<IPlayer> GetEntitiesFromSerializedList(List<PlayerPlayer> serializedList)
        {
            List<IPlayer> list = new List<IPlayer>();
            foreach (var pl in serializedList)
            {
                Guid plID;
                if (Guid.TryParse(pl.id, out plID))
                {
                    list.Add(this.GetPlayerFromRooster(plID));
                }
            }

            return list;
        }

        private List<IPlayer> GetPlayersFromSerializedList(List<MatchAwayTeamTeamPlayer> serializedList)
        {
            List<IPlayer> list = new List<IPlayer>();
            foreach (var pl in serializedList)
            {
                Guid plID;
                if (Guid.TryParse(pl.id, out plID))
                {
                    list.Add(this.GetPlayerFromRooster(plID));
                }
            }

            return list;
        }

        private List<IPlayer> GetPlayersFromSerializedList(List<MatchHomeTeamTeamPlayer> serializedList)
        {
            List<IPlayer> list = new List<IPlayer>();
            foreach (var pl in serializedList)
            {
                Guid plID;
                if (Guid.TryParse(pl.id, out plID))
                {
                    list.Add(this.GetPlayerFromRooster(plID));
                }
            }

            return list;
        }
        #endregion

        #region Serialization With XElement
        private XElement ToXElement<T>(T obj)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    if (obj.GetType().Equals(typeof(Player)))
                    {
                        var xmlSerializer = new PlayerPlayerSerializer();
                        xmlSerializer.Serialize(streamWriter, obj);
                        return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
                    }
                    else
                    {
                        var xmlSerializer = new MatchSerializer();
                        xmlSerializer.Serialize(streamWriter, obj);
                        return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
                    }
                }
            }
        }

        private T FromXElement<T>(XElement xElement)
        {
            using (var memoryStream = new MemoryStream(Encoding.ASCII.GetBytes(xElement.ToString())))
            {
                var xmlSerializer = new XmlSerializer(typeof(T));
                return (T)xmlSerializer.Deserialize(memoryStream);
            }
        }
        #endregion
    }    
}
