using System;

namespace CoachBot.Common
{
    public interface IMatchStatistics
    {
        int Assists { get; set; }
        int Goals { get; set; }
        int TotalAttendences { get; set; }
        int TotalWaivers { get; set; }
    }
}
