using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DataLayer
{
    public class SingletonResults
    {
        public static SingletonResults instance;
        private string path = @"C:\Users\simon\source\repos\PesScores\DataLayer\results.xml";


        private SingletonResults() { }

        public static SingletonResults Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SingletonResults();
                }
                return instance;
            }
        }

        // Method to save the date into the result
        //If the file does not exist, create the file and add the text.
        // If the file exists, just append the text to the file
        public void saveDate(string date)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(date);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(date);
                    
                }
            }
        }

        public void saveResult(string result)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(result);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(result);
                }
            }
        }

        public string loadResult()
        {
            if (!File.Exists(path))
            {
                string output = "File does not exist";
                return output;
            }
            else
            {
                string output = File.ReadAllText(path);
                return output;
            }
        }
        /*
        public void saveBoard(string setBoard)
        {
            if (!File.Exists(board))
            {
                using (StreamWriter sw = File.CreateText(board))
                {
                    sw.WriteLine(setBoard);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(board))
                {
                    sw.WriteLine(setBoard);
                }
            }
        }*/
    }
}
