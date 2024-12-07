using System;
using System.Text.RegularExpressions;

namespace Task_Tracker_CLI
{
    class TextProcessor
    {
        public static string[] GetCommands(string text)
        {
            //split the text and look for any command
            //what's a command? a special word
            string[] commands;

            string result = text.Trim();

            //we're separating the "arg" between cotes  
            string strArg = result.Substring(result.IndexOf('"'), (result.LastIndexOf('"') + 1) - result.IndexOf('"'));

            strArg = strArg.Trim('"');

            //foreground es el color de letra papu
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(strArg);
            Console.ForegroundColor = ConsoleColor.White;

            result = Regex.Replace(result, "\\s+", ",");
            
            commands = result.Split(",");
            
            //we're supposed to be getting the commands from this method -.-
            return commands;
        }
    }
}
