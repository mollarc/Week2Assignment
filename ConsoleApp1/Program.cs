using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameSorter gameSorter = new GameSorter();
            gameSorter.PrintNumber();
            gameSorter.PrintMostGenre();
            gameSorter.PrintLongestMapName();
            gameSorter.PrintAllInfo();
            gameSorter.PrintMapsWithZ();
        }
    }
}
