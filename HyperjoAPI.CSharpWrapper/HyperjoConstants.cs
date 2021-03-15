using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HyperjoAPI.CSharpWrapper
{
    public static class HyperjoConstants
    {
        public const string Endpoint = @"https://api.hyperjo.de/";

        public const string CurrVersion = "1";

        public const string VersionParam = "version";
        public const string RequestParam = "request";

        public const string GlobalStatisticsParamValue = "globalstats";
        public const string GlobalGangStatisticsParamValue = "globalgangstats";
        public const string OnlineParamValue = "online";
        public const string FarmingParamValue = "farming";
    }
}
