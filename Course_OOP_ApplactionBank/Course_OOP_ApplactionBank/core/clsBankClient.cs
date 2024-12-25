using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Course__OOP_Level_2_Applaction
{

   public  class clsBankClient : person 
    {
        enMode _enMode;
        string _AccountNumber = "";
        string _PinCode = "";
        float _AccountBalance = 0;
        bool _MarkclientForDelet=false;
       public enum enSaveResulte
        {
            svFaildEmptyObject=0,
            svSucceeded=1,
            svFaildAccountNumberIsExist = 2,
            
        }
        public enum enMode
        {
            EmptyMode = 0,
            UpdateMode = 1,
            AddNewMode = 2
        }
        public struct stTransferLogData
        {

            public string _DataTime;
            public string From;
            public string To;
            public int Amount;
            public string SourceBalunce;
            public string DistnationBalunce;
            public string _UserName;
        }
        public clsBankClient(enMode enMode, string FirstName, string LastName, string Phone, string Email, string AccountNumber, float AccountBalance, string PinCode) :
           base(FirstName, LastName, Phone, Email)
        {
            _enMode = enMode;
            _AccountNumber = AccountNumber;
            _AccountBalance = AccountBalance;
            _PinCode = PinCode;
        }
        /*public clsBankClient():base("Ibrahim1", "Anam","22222","w@gmil")
         {
             _enMode = enMode.EmptyMode;
             _AccountNumber = "A002";
             _AccountBalance = 300;
             _PinCode = "00000";



         } */
        public clsBankClient() : base("", "", "", "")
        {
            _enMode = enMode.EmptyMode;
            _AccountNumber = "";
            _AccountBalance = 0;
            _PinCode = "";
        }
        bool IsEmpty()
        {
            return _enMode == enMode.EmptyMode;
        }
        public string AccountNumber
        {
            get { return _AccountNumber; }
            /*set { _AccountNumber = value; }*/
        }
        public string PinCode
        {
            get { return _PinCode; }
            set { _PinCode = value; }
        }
        public float AccountBalance
        {
            get { return _AccountBalance; }
            set { _AccountBalance = value; }
        }
        string _ConvertClientToLine()
        {

            return $"{_enMode},{FirstName},{LastName},{Phone},{Email},{AccountNumber},{AccountBalance},{PinCode}";
        }
       
        static stTransferLogData _converTransfeToStrict(string line)
        {
            string[] userinfo = line.Split(',');

            stTransferLogData _TransferLog;
            _TransferLog._DataTime = userinfo[0];
            _TransferLog.From = userinfo[1];
            _TransferLog.To = userinfo[2];
            _TransferLog.Amount = int.Parse(userinfo[3]);
            _TransferLog.SourceBalunce = userinfo[4];
            _TransferLog.DistnationBalunce = userinfo[5];
            _TransferLog._UserName = userinfo[6];
            return _TransferLog;
        }
        string _ConvertTransferToLine(DateTime _DataTime, float Amount,  clsBankClient _DistntionClient,string UserName)
        {


            return $"{_DataTime},{AccountNumber},{_DistntionClient.AccountNumber},{Amount},{AccountBalance},{_DistntionClient.AccountBalance},{UserName}";
        }
        static clsBankClient _convertLineToClient(string line)
        {
            string[] arr = line.Split(',');

            clsBankClient _client = new clsBankClient(enMode.UpdateMode, arr[1], arr[2], arr[3], arr[4], arr[5], float.Parse(arr[6]), arr[7]);
            return _client;
        }

        static clsBankClient _GetEmptyClientObject()
        {

            return new clsBankClient(enMode.EmptyMode, "", "", "", "", "", 0, "");
        }
        static List<clsBankClient> _LoadClientData()
        {
            string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\file.txt";
            //* string json =JsonSerializer.Serialize(_object);*//*
            List < clsBankClient> _list_client = new List<clsBankClient>();
            StreamReader sr = new StreamReader(_Path);
            string line;
            while ((line = sr.ReadLine()!) != null)
            {
                clsBankClient client = _convertLineToClient(line);
                /* if (client.AccountNumber != null)*/
                _list_client.Add(client);

            }
            sr.Close();
            return _list_client;

        }
        static List<stTransferLogData>? _LoadTransferLogData()
        {
            try
            {
                string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\TransferLog_db.txt";


                //* string json =JsonSerializer.Serialize(_object);*//*
                List<stTransferLogData> _list_TransferLog = new List<stTransferLogData>();
                StreamWriter sw = new StreamWriter(_Path, true);
                sw.Close();
                StreamReader sr = new StreamReader(_Path);
                string line;
                while ((line = sr.ReadLine()!) != null)
                {
                    stTransferLogData TransferLog = _converTransfeToStrict(line);
                    /* if (client.AccountNumber != null)*/
                    _list_TransferLog.Add(TransferLog);

                }
                sr.Close();
                return _list_TransferLog;


            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }

        }
        static void _AddDataLineToFile(clsBankClient _object)
        {
            try
            {
            string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\file.txt";
            string _AfterConvertString = _object._ConvertClientToLine();
            StreamWriter sw = new StreamWriter(_Path, true);

            sw.WriteLine(_AfterConvertString);
            sw.Close();

            } catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

        }
        static void _SaveDataToFile(List<clsBankClient> List_objects)
        {

            string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\file.txt";
            /* string json =JsonSerializer.Serialize(_object);*/

            File.Delete(_Path);
            StreamWriter sw = new StreamWriter(_Path, true);
            foreach (var Object_client in List_objects)
            {
                if(Object_client._MarkclientForDelet==false)
                {

                string DataLine = Object_client._ConvertClientToLine();
                sw.WriteLine(DataLine);
                }
            }
            sw.Close();

        }
        public  void SaveTransferLog(DateTime _DataTime, float Amount,  clsBankClient _DistntionClient,string UserName)
        {
            try
            {
                string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\TransferLog_db.txt";

                string _AfterConvertString = _ConvertTransferToLine(_DataTime, Amount, _DistntionClient, UserName);
                StreamWriter sw = new StreamWriter(_Path, true);

                sw.WriteLine(_AfterConvertString);
                sw.Close();

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

        }
        public static List<clsBankClient> _GetAllClient()
        {
            return _LoadClientData();
        }
        public static bool IsClientExist(string _AccountNumber)
        {
            clsBankClient _client = Find(_AccountNumber);
            return !_client.IsEmpty();
        }
        public static clsBankClient Find(string _AccountNumber)
        {
            /* string json = JsonSerializer.Serialize(_object);*/
            string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\file.txt";
            StreamWriter sw = new StreamWriter(_Path, true);
            sw.Close();
            StreamReader sr = new StreamReader(_Path,true);
            string line;
            while ((line = sr.ReadLine()!) != null)
            {
                clsBankClient client = _convertLineToClient(line);
                /* if (client.AccountNumber != null)*/
                if (client.AccountNumber == _AccountNumber)
                {
                    sr.Close();
                    return client;
                }

            }
            sr.Close();
            return _GetEmptyClientObject();

        }
        public static clsBankClient Find(string _AccountNumber, string Pin_Code)
        {

            /* string json =JsonSerializer.Serialize(_object);*/
            string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\file.txt";
            StreamReader sr = new StreamReader(_Path);
            string line;

            while ((line = sr.ReadLine()!) != null)
            {
                clsBankClient client = _convertLineToClient(line);
                /* if (client.AccountNumber != null)*/
                if (client.AccountNumber == _AccountNumber && client.PinCode == Pin_Code)
                {
                    sr.Close();
                    return client;
                }

            }
            sr.Close();
            return _GetEmptyClientObject();

        }
        public static  clsBankClient GetAddNewClientObject(string _AccountNumber)
        {
            return new clsBankClient(enMode.AddNewMode, "", "", "", "", _AccountNumber, 0, "");
           
        }
        public static List<stTransferLogData> _GetTransferLogData()
        {
            return _LoadTransferLogData()!;
        }
        public  enSaveResulte Save()
        {
            switch (_enMode)
            {
/*                case enMode.EmptyMode:
                    {
                        return enSaveResulte.svFaildEmptyObject;
                    }*/
                case enMode.UpdateMode:
                    {
                        _Updute();
                        return enSaveResulte.svSucceeded;
                    }
                case enMode.AddNewMode:
                    {
                        if (IsClientExist(_AccountNumber))
                        {
                            return enSaveResulte.svFaildAccountNumberIsExist;
                        }
                        
                         else
                        {

                            _enMode = enMode.UpdateMode;
                            _AddNewClient();
                             return enSaveResulte.svSucceeded;
                        }
                    }
                default:
                    return enSaveResulte.svFaildEmptyObject;
            }
        }
        public static int GetTotaleBalance()
        {
            List<clsBankClient> _LitsClient = _GetAllClient();
            double totileBalance=0;
            
                foreach (clsBankClient client in _LitsClient)
                {
                totileBalance += client.AccountBalance;
                }

            return (int)totileBalance;
        }       
        void _Updute()
        {
            
            List<clsBankClient> _list_clients = _LoadClientData();

            foreach (clsBankClient client in _list_clients)
            {
                if (client.AccountNumber == AccountNumber)
                {
                    client.FirstName=FirstName;
                    client.LastName=LastName;
                    client.Phone=Phone;
                    client.Email=Email;
                    client.AccountBalance=AccountBalance;
                    client.PinCode=PinCode;
                    break;
                }
               
            }

            _SaveDataToFile(_list_clients);

        }           
        void _AddNewClient()
        {
            _AddDataLineToFile(this);
        }
        public bool Deposit(float amount)
        {
            AccountBalance += amount;
            Save();
            return true;
        } 
        public bool Withdraw(float amount)
        {
            if(amount < AccountBalance)
            {

            AccountBalance -= amount;
                Save();
                return true;
            }
            else return false;
        } 
        public bool Transfer(float amount, ref clsBankClient  _DistnationClient, string UserName)
        {
            if(amount > AccountBalance)
            {
                return false;
            }
             Withdraw(amount);
            _DistnationClient.Deposit(amount);
            SaveTransferLog(clsUtil.DateTime, amount, _DistnationClient , UserName);
            return true;
          
        }
        public bool Delet()
        {
            List<clsBankClient> _list_clients = _LoadClientData();

            foreach (clsBankClient client in _list_clients)
            {
                if (client.AccountNumber == AccountNumber)
                {
                    client._MarkclientForDelet = true;
                    break;
                }

            }
            _SaveDataToFile(_list_clients);
           /* _GetEmptyClientObject(this);*/
            return true;
        }
    
        /// <summary>
        /// For Print All Date Clients
        /// </summary>
    
    
}}
