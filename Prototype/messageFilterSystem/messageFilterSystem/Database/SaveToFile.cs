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
    public class SaveToFile
    {
        public string FilePath;
        public bool complete;

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
                        complete = true;
                        
                    }
                    catch (Exception ex)
                    {
                        ErrorCode = ex.ToString();
                        complete = false;
                    }
                    break;
                case "T":
                    FilePath = "D:\\Tweet.txt";
                    try
                    {
                        string JSON = JsonConvert.SerializeObject(AddMessage);
                        JSON = JSON + Environment.NewLine;
                        File.AppendAllText(FilePath, JSON.ToString());
                        complete = true;
                    }
                    catch (Exception ex)
                    {
                        ErrorCode = ex.ToString();
                        complete = false;
                    }
                    break;
            }
            return complete;
        }
        public bool EmailToCSV(EmailAdd AddEmail, string MessageType)
        {
            FilePath = "D:\\StandardEmail.txt";
            try
            {
                string JSON = JsonConvert.SerializeObject(AddEmail);
                JSON = JSON + Environment.NewLine;
                File.AppendAllText(FilePath, JSON.ToString());
                complete = true;
            }
            catch (Exception ex)
            {
                ErrorCode = ex.ToString();
                complete = false;
            }
            return complete;
        }
    }
}
