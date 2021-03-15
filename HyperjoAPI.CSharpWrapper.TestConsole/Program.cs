using System;

namespace HyperjoAPI.CSharpWrapper.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Usage and examples NO KEY
            
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
                var itemName = farmingStatistic.ItemName;
                var currentPrice = farmingStatistic.CurrentPrice;
            }

            //Usage and examples WITH PERSONAL KEY
            
            HyperjoAPIWrapper hyperjoApiWithKey = new HyperjoAPIWrapper("32a8428a-7eae-42e1-870e-5f15526d0539"); // Invalid example key!

            var name = hyperjoApiWithKey.GetName();
            var ownId = name.CharacterId;
            var ownName = name.Name;

            var money = hyperjoApiWithKey.GetMoney();
            var ownMoney = money.Money;

            var number = hyperjoApiWithKey.GetPhoneNumber();
            var ownNumber = number.PhoneNumber;

            
            //We need own id for this get call            
            var valid = hyperjoApiWithKey.GetValid(ownId);
            var isOwnKeyValid = valid.Valid;

            Console.ReadLine();
        }
    }
}