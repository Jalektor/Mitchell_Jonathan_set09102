using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using messageFilterSystem.Models;
using System.IO;

namespace messageFilterSystem.Database
{
    public class LoadFromFile
    {
        private string FileLocation;

        public List<TxtAbbreviations> Message { get; set; }     
        public string ErrorCode { get; set; }

        public LoadFromFile()
        {
            Message = new List<TxtAbbreviations>();
            FileLocation = "D:\\textWordAbbreviations.txt";
        }
        public bool LoadTxtAbbreviations()
        {
            try
            {
                var data = File.ReadAllLines(FileLocation);
                foreach(string value in data)
                {
                    var line = value.Split(',');
                    Message.Add(new TxtAbbreviations()
                    {
                        Abbreviation = line[0],
                        FullWord = line[1]
                    });
                }
                return true;
            }
            catch(Exception ex)
            {
                ErrorCode = ex.ToString();
                return false;
            }
        }
    }
}
