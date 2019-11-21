using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MainProgram
{
    public class EDIFACTTest
    {
        public EDIFACTTest()
        {
        }

        public void EDIFACT()
        {
            string path = @"/Users/kamalkumarjesuranjan/Desktop/WorkingPath/Edifact1.txt";

            try
            {
                List<string> expLoc = new List<string>();

                string readText = System.IO.File.ReadAllText(path);

                readText = RemoveEmptyLines(readText);
                string[] splittedLines = readText.Split('\n');

                foreach (string eachline in splittedLines)
                {
                    string[] splittedLOC = eachline.Split('+');

                    if (splittedLOC.Length > 2)
                    {
                        expLoc.Add(splittedLOC[1]);
                        expLoc.Add(splittedLOC[2]);
                    }
                    else if (splittedLOC.Length > 1)
                    {
                        expLoc.Add(splittedLOC[1]);
                    }
                    else
                    {
                        continue;
                    }
                }

                string[] selectedLOC = expLoc.ToArray();

                int len = selectedLOC.Length;

                for(int i=0; i<len; i++)
                {
                    Console.WriteLine(selectedLOC[i]);
                }
            }
            catch (System.IO.FileNotFoundException fnfo)
            {
                throw fnfo;
            }

            Console.ReadLine();
        }

        private static string RemoveEmptyLines(string lines)
        {
            return Regex.Replace(lines, @"^\s*$\n/\r", string.Empty, RegexOptions.Multiline).TrimEnd();
        }
    }
}
