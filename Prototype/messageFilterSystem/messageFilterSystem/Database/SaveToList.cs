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
    public class SaveToList
    {
        public string FilePath;
        public bool complete;

        public string ErrorCode { get; set; }

        public SaveToList()
        {
            FilePath = string.Empty;
            ErrorCode = string.Empty;
        }

        public bool WriteToCSV(List<ListAdd> List, string MessageType)
        {
            switch(MessageType)
            {
                case "M":
                    FilePath = "D:\\Mentions.txt";
                    try
                    {
                        string JSON = JsonConvert.SerializeObject(List.ToArray(), Formatting.Indented);
                        File.WriteAllText(FilePath, JSON.ToString());
                        complete = true;
                    }
                    catch(Exception ex)
                    {
                        ErrorCode = ex.ToString();
                        complete = false;
                    }
                    break;
                case "H":
                    FilePath = "D:\\Hashtag.txt";
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
                    FilePath = "D:\\SIRList.txt";
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
                case "Q":
                    FilePath = "D:\\QuarantineList.txt";
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
