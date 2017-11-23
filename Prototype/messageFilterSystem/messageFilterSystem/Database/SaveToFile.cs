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

        public bool WriteToCSV(List<MessageAdd> List, string MessageType)
        {

            switch(MessageType)
            {
                case "S":
                    FilePath = "D:\\SMS.txt";
                    try
                    {
                        string JSON = JsonConvert.SerializeObject(List.ToArray(), Formatting.Indented);
                        File.WriteAllText(FilePath, JSON.ToString());
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
                        string JSON = JsonConvert.SerializeObject(List.ToArray(), Formatting.Indented);
                        File.WriteAllText(FilePath, JSON.ToString());
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
        public bool EmailToCSV(List<EmailAdd> List, string MessageType)
        {
            switch(MessageType)
            {
                case "E":
                    FilePath = "D:\\StandardEmail.txt";
                    try
                    {
                        string JSON = JsonConvert.SerializeObject(List.ToArray(), Formatting.Indented);
                        File.WriteAllText(FilePath, JSON.ToString());
                        complete = true;
                    }
                    catch (Exception ex)
                    {
                        ErrorCode = ex.ToString();
                        complete = false;
                    }
                    break;

                case "S":
                    FilePath = "D:\\SIREmail.txt";
                    try
                    {
                        string JSON = JsonConvert.SerializeObject(List.ToArray(), Formatting.Indented);
                        File.WriteAllText(FilePath, JSON.ToString());
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
    }
}
