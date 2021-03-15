using System;

namespace HyperjoAPI.CSharpWrapper.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Usage of login system
            //We need the Character name, the own password,the key of all rights we want with ',' to separate (in this case all available), and a redirect (ask to register yours at the management)
            HyperjoLoginWrapper login = new HyperjoLoginWrapper();
            var loginResult = login.Login("Leter Pustig", "ABCDE", "name,money,phonenumber,vehicles", "YOUR_REQUESTET_REDIRECT HERE");
            var ownKey = loginResult.Key;
            var ownId = loginResult.CharacterId;
            
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
            
            HyperjoAPIWrapper hyperjoApiWithKey = new HyperjoAPIWrapper(ownKey.ToString()); // We use own key from above

            var name = hyperjoApiWithKey.GetName();
            var ownName = name.Name;

            var money = hyperjoApiWithKey.GetMoney();
            var ownMoney = money.Money;

            var number = hyperjoApiWithKey.GetPhoneNumber();
            var ownNumber = number.PhoneNumber;
            
            var valid = hyperjoApiWithKey.GetValid(ownId); //We need own id for this get call        
            var isOwnKeyValid = valid.Valid;

            var vehicles = hyperjoApiWithKey.GetVehicles();
            foreach (var vehicle in vehicles.Vehicles)
            {
                var displayName = vehicle.DisplayName;
                var numberPlate = vehicle.NumberPlate;
            }

            Console.ReadLine();
        }
    }
}