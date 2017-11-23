using messageFilterSystem.Database;
using messageFilterSystem.Models;
using messageFilterSystem.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace messageFilterSystem.ViewModels
{
    public class AddSIRViewModel : BaseViewModel
    {
        public bool check;
        public string WebCheck { get; set; }
        public List<string> Incidents { get; set; }
        #region DatePickerContent
        public string DPickerContent { get; set; }
        public string CentreCode { get; set; }
        public string Incident { get; set; }
        #endregion
        #region ButtonContent/Command
        public string BtnInsertSIRContent { get; private set; }
        public ICommand BtnInsertSIRCommand { get; private set; }
        #endregion
        List<EmailAdd> ListEmail = new List<EmailAdd>();
        List<ListAdd> ListSIR = new List<ListAdd>();
        List<ListAdd> ListQuarantine = new List<ListAdd>();
        #region Constructor
        public AddSIRViewModel()
        {
            Incidents = new List<string>();
            Incidents.Add("Theft of Properties");
            Incidents.Add("Staff Attack");
            Incidents.Add("Device Damage");
            Incidents.Add("Raid");
            Incidents.Add("Customer Attack");
            Incidents.Add("Staff Abuse");
            Incidents.Add("Bomb Threat");
            Incidents.Add("Terrorism");
            Incidents.Add("Suspicious Incident");
            Incidents.Add("Sport Injury");
            Incidents.Add("Personal Info Leak");

            CentreCode = "66-666-999";
            TBlockTitle = "Add Email message";
            TBlockMHeader = "Message Header";
            TBlockMID = "Message Type: E";
            TBlockMChars = "Please Enter the 9 Numeric Characters:";
            TBlockSender = "Sender:";
            TBlockSubject = "Please Select a date:";
            TBlockBody = "Body";

            TBoxMID = string.Empty;
            TBoxSender = string.Empty;
            TBoxBody = string.Empty;

            BtnInsertSIRContent = "Insert SIR";

            BtnInsertSIRCommand = new RelayCommand(InsertSMSClick);

            MessageType = "S";
        }
        #endregion
        #region ButtonClick
        private void InsertSMSClick()
        {
            var email = new EmailAddressAttribute();
            var website = new UrlAttribute();
            
            if(email.IsValid(TBoxSender))
            {
                
                string[] Body = TBoxBody.Split(' ');
                foreach(string word in Body)
                {
                    WebCheck = word;
                    if (website.IsValid(word) || word.Contains("www"))
                    {
                        ListAdd Quarantine = new ListAdd();
                        {
                            Quarantine.ListType = word;
                            Quarantine.Count = "1";
                        }
                        ListType = "Q";
                        ListQuarantine.Add(Quarantine);

                        SaveToList Q = new SaveToList();

                        if (!Q.WriteToCSV(ListQuarantine, ListType))
                        {
                            MessageBox.Show("Error while saving\n" + Q.ErrorCode);
                        }
                        else
                        {
                            Q = null;
                        }

                        WebCheck = WebCheck.Replace(WebCheck, "<URL Quarantined>");
                        MessageBox.Show(WebCheck);
                        for(int x = 0; x < Body.Length; x++)
                        {
                            if(Body[x] == word)
                            {
                                Body[x] = Body[x].Replace(word, WebCheck);
                            }
                        }
                    }
                }
                TBoxBody = string.Join(" ", Body);
                MessageBox.Show(TBoxBody);

                EmailAdd AddEmail = new EmailAdd();
                {
                    AddEmail.MessageID = "E" + TBoxMID;
                    AddEmail.Sender = TBoxSender;
                    try
                    {
                        AddEmail.Subject = "SIR " + DPickerContent.ToString();
                        check = true;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Please Select a date");
                        check = false;
                    }
                    AddEmail.Body = CentreCode + "" + Incident + "" + TBoxBody;
                }

                if(check == true)
                {
                    ListEmail.Add(AddEmail);

                    SaveToFile save = new SaveToFile();

                    if (!save.EmailToCSV(ListEmail, MessageType))
                    {
                        MessageBox.Show("Error while saving\n" + save.ErrorCode);
                    }
                    else
                    {
                        save = null;
                    }

                    ListAdd SIRList = new ListAdd();
                    {
                        SIRList.ListType = AddEmail.Subject;
                        SIRList.Count = "66-666-99";
                    }

                    ListType = "S";
                    ListSIR.Add(SIRList);

                    SaveToList SIR = new SaveToList();
                    if (!SIR.WriteToCSV(ListSIR, ListType))
                    {
                        MessageBox.Show("Error while saving\n" + SIR.ErrorCode);
                    }
                    else
                    {
                        SIR = null;
                    }
                    MessageBox.Show("Order saved");
                }              
            }
            else
            {
                MessageBox.Show("Wrong");
            }           
        }
        #endregion
    }
}
