using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWeekAssignment
{
    public class MapInfo
    {
        public int MapNameLength;

        public string MapName;

        public string GameName;

        public MapInfo(int mapNameLength, string mapName, string gameName)
        {
            MapNameLength = mapNameLength;
            MapName = mapName;
            GameName = gameName;
        }
    }
}
