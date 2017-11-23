using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using messageFilterSystem.Models;
using System.IO;
using Newtonsoft.Json;
using System.Windows;

namespace messageFilterSystem.Database
{
    public class LoadMessageFromFile
    {
        #region Variables/Properties
        private string FileLocation;
        public string ErrorCode;

        public string MessageType { get; set; }
        public List<MessageAdd> Message { get; set; }
        public List<EmailAdd> Email { get; set; }
        #endregion
        #region Constructor
        public LoadMessageFromFile()
        {
        }
        #endregion
        #region LoadMessage
        public bool LoadMessageType(string messageType)
        {
            bool Load = false;
            MessageType = messageType;

            switch(MessageType)
            {
                case "SMS":
                    FileLocation = "D:\\SMS.txt";
                    Load = LoadSMS();
                    break;
                case "Email":
                    FileLocation = "D:\\StandardEmail.txt";
                    Load = LoadStandardEmail();
                    break;
                case "SIR":
                    FileLocation = "D:\\SIREmail.txt";
                    Load = LoadSIREmail();
                    break;
                case "Tweet":
                    FileLocation = "D:\\Tweet.txt";
                    Load = LoadTweet();
                    break;
            }
            return Load;
        }
        #endregion
        #region LoadSMS
        public bool LoadSMS()
        {
            try
            {
                using (StreamReader file = new StreamReader(FileLocation))
                {
                    string json = file.ReadToEnd();
                    Message = JsonConvert.DeserializeObject<List<MessageAdd>>(json);
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
        #region LoadStandardEmail
        public bool LoadStandardEmail()
        {
            try
            {
                using (StreamReader file = new StreamReader(FileLocation))
                {
                    string json = file.ReadToEnd();
                    Message = JsonConvert.DeserializeObject<List<MessageAdd>>(json);
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
        #region LoadSIRList
        public bool LoadSIREmail()
        {
            try
            {
                using (StreamReader file = new StreamReader(FileLocation))
                {
                    string json = file.ReadToEnd();
                    Message = JsonConvert.DeserializeObject<List<MessageAdd>>(json);
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
        #region LoadTweet
        public bool LoadTweet()
        {
            try
            {
                using (StreamReader file = new StreamReader(FileLocation))
                {
                    string json = file.ReadToEnd();
                    Message = JsonConvert.DeserializeObject<List<MessageAdd>>(json);
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
