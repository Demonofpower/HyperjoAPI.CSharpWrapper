using System;

namespace HyperjoAPI.CSharpWrapper.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Usage and examples
            
            HyperjoAPIWrapper hyperjoApi = new HyperjoAPIWrapper();

            var globalStatistics = hyperjoApi.GetGlobalStatistics();
            var medicPlaytime = globalStatistics.Playtime.Medic;
            var allMoney = globalStatistics.Money;

            var globalGangStatistics = hyperjoApi.GetGlobalGangStatistics();
            var allGangMembers = globalGangStatistics.GangMembers;
            var gangCount = globalGangStatistics.Gangs;

            var onlineStatistics = hyperjoApi.GetOnline();
            var onlinePlayers = onlineStatistics.OnlinePlayers;

            var farmingStatistics = hyperjoApi.GetFarming();
            foreach (var farmingStatistic in farmingStatistics.Farming)
            {
                var name = farmingStatistic.ItemName;
                var currentPrice = farmingStatistic.CurrentPrice;
            }
            
            Console.ReadLine();
        }
    }
}