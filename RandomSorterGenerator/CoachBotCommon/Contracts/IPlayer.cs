using System;
using System.Collections.Generic;
using CoachBot.Common.ResouceAcess;

namespace CoachBot.Common
{
    public interface IPlayer : IComparable, IValidator, ICloneable
    {
        Guid ID { get; set; }
        string Name { get; set; }
        IMatchStatistics Statistics { get; set; }
        List<IPlayer> AssociatedGuests { get; set; }
    }
}
