using System.Collections.Generic;
using System.Linq;

namespace RSHiscore
{
    class HiscoreType
    {
        // sometimes I really miss Java enums man, like what even is this class
        private static Dictionary<string, HiscoreType> lookup = new Dictionary<string, HiscoreType>();

        public static HiscoreType ByName(string name)
        {
            return lookup[name];
        }

        public static HiscoreType[] Values()
        {
            return lookup.Values.ToArray<HiscoreType>();
        }

        public static readonly HiscoreType GENERAL = new HiscoreType("General", "");
        public static readonly HiscoreType IRONMAN = new HiscoreType("Ironman", "_ironman");
        public static readonly HiscoreType HARDCORE = new HiscoreType("HCIM", "_hardcore_ironman");
        public static readonly HiscoreType ULTIMATE = new HiscoreType("UIM", "_ultimate");
        public static readonly HiscoreType DEADMAN = new HiscoreType("Deadman", "_deadman");
        public static readonly HiscoreType SEASONAL = new HiscoreType("Seasonal", "_seasonal");
        public static readonly HiscoreType TOURNAMENT = new HiscoreType("Tournament", "_tournament");
        
        public string Name { get; private set; }
        public string UrlNode { get; private set; }

        private HiscoreType(string name, string urlNode)
        {
            this.Name = name;
            this.UrlNode = urlNode;

            lookup.Add(this.Name, this);
        }
    }
}
