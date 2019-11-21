using System;
using System.Collections.Generic;
using System.Xml;

namespace MainProgram
{
    public class REFTEST
    {
        public void REfCodes()
        {
            try
            {
                Console.Write("Please enter the codes that to be extracted = ");
                //Enter the RefCodes in comma seperated values in any case, it will automaticaly convert to caps
                string inputRefCodes = Console.ReadLine().ToUpper();
                string[] refCodeList = inputRefCodes.Split(',');
                string path = @"/Users/kamalkumarjesuranjan/Desktop/WorkingPath/Edifact2.xml"; //actual xml document path
                string readText = System.IO.File.ReadAllText(path);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(readText);
                string lines = string.Join(Environment.NewLine, ExtractXMLData(xmlDoc, refCodeList));
                Console.WriteLine(lines);
                Console.Read();
            }
            catch (XmlException ex)
            {
                Console.Write("Error on the XML Document given..Please check");
                throw ex;
            }
            catch (Exception ex)
            {
                Console.Write("Something went wrong..Please check");
                throw ex;
            }
        }


        private static List<string> ExtractXMLData(XmlDocument xmlDoc, string[] attributes)
        {
            List<string> refTextList = new List<string>();
            foreach (string refCode in attributes)
            {
                XmlNodeList xnMwb = xmlDoc.SelectNodes("/InputDocument/DeclarationList/Declaration/DeclarationHeader/Reference[@RefCode='" + refCode + "']");
                refTextList.Add(xnMwb != null ? xnMwb[0].InnerText : "Invalid Code");
            }
            return refTextList;
        }
    }
}
