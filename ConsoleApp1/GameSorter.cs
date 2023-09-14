using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ConsoleApp1
{
    internal class GameSorter
    {
        GameInfo gameInfo = new GameInfo();
        Dictionary<int,Info> Games = new Dictionary<int,Info>();
        public GameSorter()
        {
            //Adds data to Games Dictionary
            foreach(var _gameInfo in gameInfo.MetaData)
            {
                Games.Add(_gameInfo.Id, _gameInfo);
            }
        }

        public void PrintAllInfo() //Prints all the meta data for each game
        {
            foreach (var _gameInfo in Games)//Loops through each game
            {
                Console.WriteLine($"ID: {_gameInfo.Key}\nName: {_gameInfo.Value.Name}\nGenre: {_gameInfo.Value.Genre}");
                Console.WriteLine("Maps:");
                foreach (var _maps in _gameInfo.Value.MapNames)
                {
                    Console.WriteLine($"{_maps}");
                }
                Console.WriteLine("\nPress any button to continue");
                Console.ReadLine();

            }
            Console.WriteLine("End of List");
            Console.WriteLine("\nPress any button to continue");
            Console.ReadLine();
            Console.Clear();
        }

        public void PrintNumber()//Prints Number of Games
        {
            int number = 0;
            foreach (var _gameInfo in gameInfo.MetaData)
            {
                number++;
            }
            Console.WriteLine($"The number of games is: {number}");
            Console.WriteLine("\nPress any button to continue");
            Console.ReadLine();
            Console.Clear();
        }

        public void PrintMostGenre()//Prints the most frequent genre in the games dictionary
        {
            int mostGenreCount = 0;
            int previousGenreCount = 0;
            string previousGenre = "";
            string mostGenre="";
            List<string> genres= new List<string>();
            foreach (var _gameInfo in Games)
            {
                genres.Add(_gameInfo.Value.Genre);
            }
            genres.Sort();//sorts genres to ensure the most frequent genre is found
            foreach (var _genre in genres)//loops through each genre
            {
                if (previousGenre == _genre)//if the previous genre in the index is the same as the current the count goes up
                {
                    mostGenreCount++;
                }
                if(mostGenreCount > previousGenreCount)//if the count is higher than the previous count it is replaced and the most frequent genre is updated
                {
                    previousGenreCount = mostGenreCount;
                    mostGenre = _genre;
                }
                previousGenre = _genre;
            }
            Console.WriteLine($"The most frequent genre is: {mostGenre}");
            Console.WriteLine("\nPress any button to continue");
            Console.ReadLine();
            Console.Clear();
        }
        public void PrintLongestMapName()//Prints the longest map names found within the dictionary
        {
            int mapWordCount = 0;
            int longestMapWordCount = 0;
            int spaces = 0;
            List<string> longestMapNames = new List<string>();
            //First loop to determine the longest word count of all maps
            foreach(var _gameinfo in Games)
            {
                foreach (var _maps in _gameinfo.Value.MapNames)
                {
                    spaces = 0;
                    mapWordCount = 0;
                    foreach(char _letter in _maps)
                    {
                        if (_letter ==' ')
                        {
                            spaces++;
                        }
                        mapWordCount++;
                    }
                    mapWordCount -= spaces;
                    if(mapWordCount > longestMapWordCount) 
                    { 
                        longestMapWordCount = mapWordCount;
                    }
                }
            }
            //Second loop to add all maps that have the longest word count
            foreach (var _gameinfo in Games)
            {
                foreach (var _maps in _gameinfo.Value.MapNames)
                {
                    spaces = 0;
                    mapWordCount = 0;
                    foreach (char _letter in _maps)
                    {
                        if (_letter == ' ')
                        {
                            spaces++;
                        }
                        mapWordCount++;
                    }
                    mapWordCount -= spaces;
                    if (mapWordCount == longestMapWordCount)
                    {
                        longestMapNames.Add(_maps);
                    }
                }
            }
            Console.WriteLine("Longest Map Names: ");
            //Last loop to print values
            foreach (var _gameinfo in Games)
            {
                foreach (var _maps in _gameinfo.Value.MapNames)
                {
                    for(int i=0; i< longestMapNames.Count; i++)
                    {
                        if (longestMapNames[i] == _maps)
                        {
                            Console.WriteLine($"Game: {_gameinfo.Value.Name}");
                            Console.WriteLine($"Map Name: {longestMapNames[i]}");
                        }
                    }
                }
            }
            Console.WriteLine("\nPress any button to continue");
            Console.ReadLine();
            Console.Clear();
        }
        public void PrintMapsWithZ()//Prints map containing the letter Z
        {
            List<string> mapsWithZ = new List<string>();
            foreach (var _gameinfo in Games)//Loop to add maps with Z to list
            {
                foreach (var _maps in _gameinfo.Value.MapNames)
                {
                    if (_maps.ToUpper().Contains("Z"))
                    {
                        mapsWithZ.Add(_maps);
                    }
                }
            }
            Console.WriteLine("Maps containing Z: ");
            foreach(var _maps in mapsWithZ)
            {
                Console.WriteLine(_maps);
            }
            Console.WriteLine("\nPress any button to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
