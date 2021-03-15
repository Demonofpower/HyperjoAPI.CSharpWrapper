using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperjoAPI.CSharpWrapper.DTOs
{
    public class FarmingTable
    {
        public List<FarmingItem> Farming;
    }

    public struct FarmingItem
    {
        public string ItemName;
        public string Symbol;
        public int CurrentPrice;
    }
}
