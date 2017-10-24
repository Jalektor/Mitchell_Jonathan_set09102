using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using messageFilterSystem.Models;
using Newtonsoft.Json;

namespace messageFilterSystem.Database
{
    class SaveToFile
    {
        public string FilePath;

        public string ErrorCode { get; set; }

        public SaveToFile()
        {
            FilePath = string.Empty;

            ErrorCode = string.Empty;
        }

        public bool WriteToCSV(MessageAdd AddMessage, string MessageType)
        {

            switch(MessageType)
            {
                case "S":
                    FilePath = "D:\\SMS.txt";
                    try
                    {
                        string JSON = JsonConvert.SerializeObject(AddMessage);
                        JSON = JSON + Environment.NewLine;
                        File.AppendAllText(FilePath, JSON.ToString());
                        return true;
                    }
                    catch (Exception ex)
                    {
                        ErrorCode = ex.ToString();
                        return false;
                    }
                case "E":
                    FilePath = "D:\\Email.txt";
                    try
                    {
                        string JSON = JsonConvert.SerializeObject(AddMessage);
                        JSON = JSON + Environment.NewLine;
                        File.AppendAllText(FilePath, JSON.ToString());
                        return true;
                    }
                    catch (Exception ex)
                    {
                        ErrorCode = ex.ToString();
                        return false;
                    }                    
                case "T":
                    FilePath = "D:\\Tweet.txt";
                    try
                    {
                        string JSON = JsonConvert.SerializeObject(AddMessage);
                        JSON = JSON + Environment.NewLine;
                        File.AppendAllText(FilePath, JSON.ToString());
                        return true;
                    }
                    catch (Exception ex)
                    {
                        ErrorCode = ex.ToString();
                        return false;
                    }
            }
            try
            {
                string JSON = JsonConvert.SerializeObject(AddMessage);
                JSON = JSON + Environment.NewLine;
                File.AppendAllText(FilePath, JSON.ToString());
                return true;
            }
            catch (Exception ex)
            {
                ErrorCode = ex.ToString();
                return false;
            }
        }
    }
}
