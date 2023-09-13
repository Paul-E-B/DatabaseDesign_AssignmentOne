using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.Design.Serialization;

namespace FirstWeekAssignment
{
    public class Program
    {
        static void Main()
        {
            Utility utility = new Utility();

            //create a copy of metadata
            var metaData = new GameInfo().MetaData;



            //problem 1

            //Output the number of games to console.
            Console.WriteLine(metaData.Count);





            //problem 2

            //initialize value to track frequency of most popular genre
            int popularGenre = 0;

            //Create dictionary for genres
            Dictionary<string,int> genres = new Dictionary<string,int>();

            //add genres to dictionary
            foreach (Info i in metaData)
            {
                //try to add genre and count to dictionary
                try
                {
                    genres.Add(i.Genre, 1);
                }
                //if the genre is in the dictionary, increase count by one
                catch (ArgumentException)
                {
                    genres[i.Genre] += 1;
                }
            }

            //Compare the genre count to itself to find the frequency of the most common occuring genre
            foreach (var genre in genres)
            {
                popularGenre = (popularGenre > genre.Value) ? popularGenre:genre.Value;
            }

            //find all genre with the highest frequency
            var genreList = genres.Where(g => g.Value == popularGenre).ToList();

            //Write most frequent genre to console
            genreList.ForEach(g => Console.WriteLine(g.Key));







            //problem 3
            //Which map names have the most number of characters excluding spaces, and which game they belong to

            //initialize value 
            int mapTitleLength = 0;

            //create a list of to hold all relevant map data
            List<MapInfo> mapData = new List<MapInfo>();

           
            //check each info in metadata
            foreach (Info i in metaData)
            {
                //check each string in map name string array
                foreach (string s in i.MapNames)
                {
                   
                    //create a variable that tracks the total number of characters in a map name
                    int tempTitleLength = 0;


                    //checks each map name for the number of leters and spaces it contains
                    int c = 0;
                    while (c < s.Count())
                    {
                        tempTitleLength = (s[c] != ' ') ? tempTitleLength+=1:tempTitleLength;
                        c++;
                    }


                    //compare the title length for each map
                    mapTitleLength = (mapTitleLength > tempTitleLength) ? mapTitleLength:tempTitleLength;


                    //create an instance of map info that captures the current map title length,
                    //map title, and game title
                    MapInfo tempMapInfo = new MapInfo(tempTitleLength, s, i.Name);


                    //add current map info to a list of map info
                    mapData.Add(tempMapInfo);
                }
            }

            //create a list of all maps with the most characters
            mapData = mapData.Where(m => m.MapNameLength.Equals(mapTitleLength)).ToList();


            //Write most maps with most characters to console
            mapData.ForEach(m => Console.WriteLine($"{m.MapName}  {m.MapNameLength}  {m.GameName}"));






            //problem 4
            //A dictionary that uses the Id Property as a Key and Info object as a value, then display all the information using a loop

            //create dictionary
            Dictionary<int, Info> gameInfo = new Dictionary<int, Info>();
            
            //fill dictionary with id and info from metadata
            foreach(Info i in metaData)
            {
                gameInfo.Add(i.Id, i);
            }

            //loop through each game in dictionary
            foreach(var gameinfo in gameInfo)
            {
                //write all game info to console
                Console.WriteLine("ID: " +gameinfo.Key+ "\nName: " +gameinfo.Value.Name + "\nGenre: " + gameinfo.Value.Genre + "\nMaps: "  +utility.ArrayToString(gameinfo.Value.MapNames, gameinfo.Value.MapNames.Count()) + "\n");
            }




            //problem 5
            //The map names that have the letter z in them
            foreach(Info i in metaData)
            {
                var mapNamesContainingZ = utility.StringArrayToList(i.MapNames).Where(n => n.Contains("z")).ToList();

                mapNamesContainingZ.ForEach(z => Console.WriteLine(z));
            }

        }
    
    
    }

}

