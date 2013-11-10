using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using CoachBot.Common;
using CoachBot.Common.ResourceAcess;
using System;

namespace XmlResourceAcess
{    
    public class XmlRepository : IRepository
    {
        private string _roosterFileName;
        private string _matchesFileName;

        public DirectoryInfo BaseDirectory { get; private set; }

        private XDocument _rooster;
        public XDocument Rooster 
        {
            get
            {
                _rooster = _rooster ?? GetFileAsXDocument(_roosterFileName);

                return _rooster;
            }
        }

        private XDocument _matches;
        public XDocument Matches 
        {
            get
            {
                _matches = _matches ?? GetFileAsXDocument(_matchesFileName);

                return _matches;
            }
        }

        public XmlParser Parser { get; private set; }

        public XmlRepository(DirectoryInfo baseDirectory, Func<IPlayer> getEmptyPlayer, Func<IMatch> getEmptyMatch, string roosterFileName = "Rooster.xml", string matchesFileName = "Matches.xml")
        {
            this.Parser = new XmlParser(getEmptyPlayer, getEmptyMatch);
            BaseDirectory = baseDirectory;
            _roosterFileName = roosterFileName;
            _matchesFileName = matchesFileName;
        }

        private XDocument GetFileAsXDocument(string fileName)
        {
            if (!BaseDirectory.Exists)
                throw new DirectoryNotFoundException("No directory found in " + BaseDirectory.FullName);

            var files = BaseDirectory.EnumerateFiles(fileName);

            if (files.Count() > 2)
                throw new IOException("Multiple files found in base directory with name " + fileName);

            if (files.Count() == 0)
                throw new FileNotFoundException("No file found in base directory with name " + fileName);
            
            return XDocument.Load(files.Single().FullName);
        }

        public List<IPlayer> GetRooster()
        {
            return Parser.LoadFromRooster(Rooster);
        }
     
        public void UpdateRooster(List<IPlayer> rooster)
        {
            Parser.UpdateRooster(rooster, this.Rooster);
        }

        public void SavePlayer(IPlayer player)
        {
            Parser.SavePlayerToRooster(player, this.Rooster);
        }
 
        public void DeletePlayer(IPlayer player)
        {
            Parser.DeletePlayerFromRooster(player, this.Rooster);
        }

        public void SaveMatch(IMatch match)
        {
            Parser.SaveMatch(match, this.Matches);
        }

        public List<IMatch> GetMatchHistory()
        {
            return Parser.GetAllMatches(this.Matches);
        }

        public void UpdateStatistics(List<IPlayer> players)
        {
            Parser.UpdateStatisticsOnRooster(players, this.Rooster);
        }
    }
}
