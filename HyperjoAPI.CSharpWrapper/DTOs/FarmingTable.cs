using System.Collections.Generic;

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
