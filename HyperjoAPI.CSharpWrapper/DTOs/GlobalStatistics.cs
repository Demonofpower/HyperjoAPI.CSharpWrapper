using Newtonsoft.Json;

namespace HyperjoAPI.CSharpWrapper.DTOs
{
    public class GlobalStatistics
    {
        public int Characters;
        public Vehicles Vehicles;
        public int Messages;
        public int Money;
        public Playtime Playtime;
    }

    public struct Vehicles
    {
        public int Sum;
        public int Destroyed;
    }

    public struct Playtime
    {
        public int All;
        public int Police;
        public int Medic;
    }
}
