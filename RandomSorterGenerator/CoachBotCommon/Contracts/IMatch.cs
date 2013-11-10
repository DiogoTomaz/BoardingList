using System;
using System.Collections.Generic;

namespace CoachBot.Common
{
    public interface IMatch
    {
        ITeam HomeTeam { get; set; }
        ITeam AwayTeam { get; set; }

        int HomeResult { get; set; }
        int AwayResult { get; set; }

        string VenueLocation { get; set; }
        DateTime EventTime { get; set; }
        decimal TotalPrice { get; set; }
        decimal PricePerPerson { get; set; }
        bool WasCanceled { get; set; }

        /// <summary>
        /// Information regarding the game, or just plain miscellaneous information
        /// </summary>
        string Report { get; set; }

        /// <summary>
        /// Random Informations on Logistics
        /// </summary>
        IEnumerable<ILogistics> LogisticsInformation { get; set; }

        TypeOfMatch Type { get; set; }
        TypeOfFlooring Floor { get; set; }

        /// <summary>
        /// The number of players per team, this usually defines the type of game played.
        /// I.e: Fut5 , Fut11, etc
        /// </summary>
        int PlayerPerTeam { get; set; }
        PitchLocation PitchLocaton { get; set; }
        GeographicalLocation GeographicalLocation { get; set; }
    }
}
