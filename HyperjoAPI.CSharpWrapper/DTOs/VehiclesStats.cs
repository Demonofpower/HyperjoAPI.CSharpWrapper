using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperjoAPI.CSharpWrapper.DTOs
{
    public class VehiclesStats
    {
        public string CharacterId;
        public List<Vehicle> Vehicles;
    }

    public struct Vehicle
    {
        public string DisplayName;
        public string CategoryName;
        public string NumberPlate;
        public int Purchase;
        public int MetersDriven;
    }
}
