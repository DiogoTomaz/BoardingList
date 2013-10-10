using System;
using System.Collections.Generic;

namespace CoachBot.Common.ResourceAcess
{
    public interface IRepository
    {
        void DeletePlayer(IPlayer player);
        List<IMatch> GetMatchHistory();
        List<IPlayer> GetRooster();
        void SaveMatch(IMatch match);
        void SavePlayer(IPlayer player);
        void UpdateRooster(List<IPlayer> rooster);
        void UpdateStatistics(List<IPlayer> players);
    }
}
