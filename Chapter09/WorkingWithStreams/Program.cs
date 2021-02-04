using System;
using System.IO;
using System.Xml;
using static System.Console;
using static System.Environment;
using static System.IO.Path;


namespace WorkingWithStreams
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkWithText();
            WorkWithXml();
        }

        static string[] callsigns = new string[] {
            "Husker", "Starbuck", "Apollo", "Boomer",
            "Bulldog", "Athena", "Helo", "Racetrack"
        };

        static void WorkWithText()
        {
            StreamWriter text = null;

            try
            {
                // define a file to write to
                string textFile = Combine(CurrentDirectory, "streams.txt");
                
                // create a text file and return a helper writer
                text = File.CreateText(textFile);

                // enumerate the strings, writing each one
                // to the stream on a separate line
                foreach (string item in callsigns)
                {
                    text.WriteLine(item);
                }
                text.Close(); // release resources

                // output the contents of the file
                WriteLine("{0} contains {1:N0} bytes.",
                    arg0: textFile,
                    arg1: new FileInfo(textFile).Length);
                WriteLine(File.ReadAllText(textFile));
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            finally
            {
                if (text != null)
                {
                    text.Dispose();
                    WriteLine("The file stream's unmanaged resources have been disposed.");
                }
            }
        }

        static void WorkWithXml()
        {
            FileStream xmlFileStream = null;
            XmlWriter xml = null;

            try{
                // define a file to write to
                string xmlFile = Combine(CurrentDirectory, "streams.xml");

                // create a file stream
                xmlFileStream = File.Create(xmlFile);

                // wrap the file stream in an XML writer helper
                // and automatically indent nested elements
                xml = XmlWriter.Create(xmlFileStream,
                    new XmlWriterSettings { Indent = true });

                // write the XML declaration
                xml.WriteStartElement("callsigns");

                // enumerate the strings writing each one to the stream
                foreach (string item in callsigns)
                {
                    xml.WriteElementString("callsign", item);
                }

                // write the close root element
                xml.WriteEndElement();

                // close the helper and stream
                xml.Close();
                xmlFileStream.Close();

                // output all the contents of the file
                WriteLine("{0} contains {1:N0} bytes.",
                    arg0: xmlFile,
                    arg1: new FileInfo(xmlFile).Length);
                
                WriteLine(File.ReadAllText(xmlFile));
            }
            catch (Exception ex)
            {
                // if the path doesn't exist the exception will be caught
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            finally
            {
                if (xml != null)
                {
                    xml.Dispose();
                    WriteLine("The XML writer's unmanaged resources have been disposed.");
                }
                if (xmlFileStream != null)
                {
                    xmlFileStream.Dispose();
                    WriteLine("The file stream's unmanaged resources have been disposed.");
                }
            }
        }
    }
}
