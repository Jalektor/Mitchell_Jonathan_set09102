using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using messageFilterSystem.Models;
using System.IO;
using Newtonsoft.Json;

namespace messageFilterSystem.Database
{
    public class LoadListFromFile
    {
        private string FileLocation;
        public string ListType { get; set; }

        public List<ListAdd> Message { get; set; }     
        public string ErrorCode { get; set; }

        public LoadListFromFile()
        {
            Message = new List<ListAdd>();
        }
        public bool LoadListType(string listType)
        {
            bool Load = false;
            ListType = listType;
            if(ListType == "Trend")
            {
                FileLocation = "D:\\Hashtag.txt";
                Load = LoadTrends();
            }
            if(ListType == "Mention")
            {
                FileLocation = "D:\\Mentions.txt";
                Load = LoadMentions();
            }
            if(ListType == "SIR")
            {
                FileLocation = "D:\\SIR.txt";
                Load = LoadTxtAbbreviations();
            }
            return Load;
        }
        #region LoadtxtAbv
                public bool LoadTxtAbbreviations()
                {
                    try
                    {
                        var data = File.ReadAllLines(FileLocation);
                        foreach(string value in data)
                        {
                            var line = value.Split(',');
                            Message.Add(new ListAdd()
                            {
                                ListType = line[0],
                                Count = line[1]
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
        #endregion
        #region LoadTrend
        public bool LoadTrends()
        {
            try
            {
                var Jsontxt = File.ReadAllLines(FileLocation);
                foreach(string line in Jsontxt)
                {
                    ListAdd list = JsonConvert.DeserializeObject<ListAdd>(line.ToString());
                    Message.Add(list);
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorCode = ex.ToString();
                return false;
            }
        }
        #endregion
        #region LoadHashtag
        public bool LoadMentions()
        {
            try
            {
                var Jsontxt = File.ReadAllLines(FileLocation);
                foreach (string line in Jsontxt)
                {
                    ListAdd list = JsonConvert.DeserializeObject<ListAdd>(line.ToString());
                    Message.Add(list);
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorCode = ex.ToString();
                return false;
            }

        }
        #endregion
        #region LoadSIR
        public bool LoadSIRs()
        {
            try
            {
                var data = File.ReadAllLines(FileLocation);
                foreach (string value in data)
                {
                    var line = value.Split(',');
                    Message.Add(new ListAdd()
                    {
                        ListType = line[0],
                        Count = line[1]
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorCode = ex.ToString();
                return false;
            }
        }
        #endregion
    }
}
