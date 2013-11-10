using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoachBot.Common
{
    public interface ILogistics
    {
        /// <summary>
        /// Player that was selected to gather all the logistics related to a game
        /// </summary>
        IPlayer PlayerSelected { get; set; }

        /// <summary>
        /// Enumerator that keeps the information of wich equipment was assigned to the player
        /// </summary>
        LogisticsOptions EquipmentAssigned { get; set; }
    }
}
