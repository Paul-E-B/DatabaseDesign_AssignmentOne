using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstWeekAssignment
{
    public class Utility
    {
        //utility class to convert string arrays to string
        public string ArrayToString(string[] array, int arrayLength)
        {
            //this variable will be passed all the information from the array
            string temp = "";

            //loop through every string in the array
            for (int c = 0; c < arrayLength; c++)
            {
                //concatonate the temp string and the current index in the string aray
                temp += array[c];

                //add a comma and space after each string except for the final one
                if (c < arrayLength - 1)
                {
                    temp += ", ";
                }
            }

            //return the string which now holds all info from the array
            return temp;
        }


        //convert string array to list of strings
        public List<string> StringArrayToList(string[] array)
        {
            //create vtemp list that wil hold data from array
            List<string> tempList = new List<string>();

            //loop through array
            for (int c = 0; c < array.Count(); c++)
            {
                //add array info to the list
                tempList.Add(array[c]);
            }
            //return list
            return tempList;
        }
    }
}
