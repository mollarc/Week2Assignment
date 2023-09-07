using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class GameSorter
    {
        GameInfo gameInfo = new GameInfo();
        Dictionary<int,Info> Games = new Dictionary<int,Info>();
        public GameSorter()
        {
            foreach(var _gameInfo in gameInfo.MetaData)
            {
                Games.Add(_gameInfo.Id, _gameInfo);
            }
        }
    }
}
