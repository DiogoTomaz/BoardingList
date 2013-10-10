using System;
using System.Collections.Generic;

namespace CoachBot.Common
{
    public interface ITeam
    {
        Guid ID { get; set; }
        string Name { get; set; }
        List<IPlayer> Players { get; set; }
    }
}
