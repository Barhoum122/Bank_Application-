using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    public class clsUser : person
    {
        public enum enMode { EmptyMode = 0, UpdateMode = 1, AddNewMode = 2 };
        enMode _Mode;
        string _UserName;
        string _Password;
        int _Permissions;
        bool _MarkedForDelete = false;
        
       
        public enum enPermissions
        {
            eAll = -1, pListClients = 1, pAddNewClient = 2, pDeleteClient = 4,
            pUpdateClients = 8, pFindClient = 16, pTranactions = 32, pManageUsers = 64,pManageUsersRegister = 128
        };
        public struct stUsersRegisterData
            {
            
           public  string _DataTime;
           public   string _UserName;
           public   string _Password;
           public   int _Permissions;
        }
       
       
         
        public clsUser(enMode mode, string FirstName, string LastName, string Phone, string Email, string userName, string password, int permissions) : base(FirstName, LastName, Phone, Email)
        {
            _Mode = mode;
            _UserName = userName;
            _Password = password;
            _Permissions = permissions;
         

        }
        public  string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public string Password 
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public int Permissions
        {
            get { return _Permissions; }
            set { _Permissions = value; }
        } 
      /*  public DateTime DataTime
        {
            get { return _DateTime; }
            set { _DateTime = value; }
        }*/
        public bool MarkedForDelete
        {
            get { return _MarkedForDelete; }
            set { _MarkedForDelete = value; }
        }
       
       public bool IsEmpty()
        {
            return (_Mode == enMode.EmptyMode);
        }

        //private Finctions 
        string _ConvertUserToLine()
        {
            Password = clsUtil.EncryptText(Password);
            return $"{_Mode},{FirstName},{LastName},{Phone},{Email},{UserName},{Password},{Permissions}";
        } 
        string _ConvertLogUserToLine(DateTime _DataTime)
        {

           Password= clsUtil.EncryptText(Password);
            return $"{_DataTime},{UserName},{Password},{Permissions}";
        }
     
        static stUsersRegisterData _convertUsersRegistertoStrict(string line)
        {
            string[] userinfo = line.Split(',');

            stUsersRegisterData registerData;
            registerData._DataTime = userinfo[0];
            registerData._UserName = userinfo[1];
            registerData._Password = clsUtil.DecryptText(userinfo[2]); ;
            registerData._Permissions = int.Parse(userinfo[3]);
            return registerData;
        }
        static clsUser _convertLineToUser(string line)
        {
            string[] userinfo = line.Split(',');

            clsUser _user = new clsUser(enMode.UpdateMode, userinfo[1], userinfo[2], userinfo[3], userinfo[4], userinfo[5], userinfo[6],int.Parse(userinfo[7]));
            _user.Password = clsUtil.DecryptText(_user.Password);
            return _user;
        }
        
      public  static clsUser _GetEmptyUserObject()
        {

            return new clsUser(enMode.EmptyMode, "", "", "", "", "",  "",0);
        }
        static List<clsUser>? _LoadUserData()
        {
            try
            {
                string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\_users_db.txt";
                //* string json =JsonSerializer.Serialize(_object);*//*
                List<clsUser> _list_user = new List<clsUser>();
                StreamWriter sw = new StreamWriter(_Path, true);
                sw.Close();
                StreamReader sr = new StreamReader(_Path);
                string line;
                while ((line = sr.ReadLine()!) != null)
                {
                    clsUser user = _convertLineToUser(line);
                    /* if (client.AccountNumber != null)*/
                    _list_user.Add(user);

                }
                sr.Close();
                return _list_user;

          
              }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
            
        } 
        static List<stUsersRegisterData>? _LoadRegisterUserData()
        {
            try
            {
                string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\Login_UserLoge_db.txt";

               
                //* string json =JsonSerializer.Serialize(_object);*//*
                List<stUsersRegisterData> _list_userRegister = new List<stUsersRegisterData>();
                StreamWriter sw = new StreamWriter(_Path, true);
                sw.Close();
                StreamReader sr = new StreamReader(_Path);
                string line;
                while ((line = sr.ReadLine()!) != null)
                {
                    stUsersRegisterData userRegister = _convertUsersRegistertoStrict(line);
                    /* if (client.AccountNumber != null)*/
                    _list_userRegister.Add(userRegister);

                }
                sr.Close();
                return _list_userRegister;


            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
            
        }
       public  static void SaveRegisterUserData(clsUser _object, DateTime _DataTime)
        {
            try
            {
                string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\Login_UserLoge_db.txt";
              
                string _AfterConvertString = _object._ConvertLogUserToLine( _DataTime);
                StreamWriter sw = new StreamWriter(_Path, true);

                sw.WriteLine(_AfterConvertString);
                sw.Close();

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

        }
      
        static void _AddDataLineToFile(clsUser _object)
        {
            try
            {
                string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\_users_db.txt";
              
                string _AfterConvertString = _object._ConvertUserToLine();
                StreamWriter sw = new StreamWriter(_Path, true);

                sw.WriteLine(_AfterConvertString);
                sw.Close();

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

        }
        static void _SaveDataToFile(List<clsUser> List_objects)
        {

            string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\_users_db.txt";
            /* string json =JsonSerializer.Serialize(_object);*/

            File.Delete(_Path);
            StreamWriter sw = new StreamWriter(_Path, true);
            foreach (var Object_user in List_objects)
            {
                if (Object_user.MarkedForDelete == false)
                {

                    string DataLine = Object_user._ConvertUserToLine();
                    sw.WriteLine(DataLine);
                }
            }
            sw.Close();

        }
       
        public static List<clsUser> _GetAllUser()
        {
            return _LoadUserData()!;
        } 
        public static List<stUsersRegisterData> _GetRegisterUserData()
        {
            return _LoadRegisterUserData()!;
        }
        public static bool IsUserExist(string _UserName)
        {
            clsUser _client = Find(_UserName);
            return !_client.IsEmpty();
        } 
        public static bool IsUserNamePasswordExist(string _UserName, string Passowre)
        {
            clsUser _client = Find(_UserName,  Passowre);
            return !_client.IsEmpty();
        }
        public static clsUser Find(string _UserName)
        {
            /* string json = JsonSerializer.Serialize(_object);*/
            string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\_users_db.txt";
            StreamWriter sw = new StreamWriter(_Path, true);
            sw.Close();
            StreamReader sr = new StreamReader(_Path, true);
            string line;
            while ((line = sr.ReadLine()!) != null)
            {
                clsUser _User = _convertLineToUser(line);
                /* if (client.AccountNumber != null)*/
                if (_User.UserName == _UserName)
                {
                    sr.Close();
                    return _User;
                }

            }
            sr.Close();
            return _GetEmptyUserObject();

        }
        public static clsUser Find(string _UserName, string _PassWord)
        {

            /* string json =JsonSerializer.Serialize(_object);*/
            string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\_users_db.txt";
            StreamReader sr = new StreamReader(_Path);
            string line;

            while ((line = sr.ReadLine()!) != null)
            {
                clsUser _User = _convertLineToUser(line);
                /* if (client.AccountNumber != null)*/
                if (_User.UserName == _UserName && _User.Password == _PassWord)
                {
                    sr.Close();
                    return _User;
                }

            }
            sr.Close();
            return _GetEmptyUserObject();

        }
        public static clsUser GetAddNewUserObject(string _UserName)
        {
            return new clsUser(enMode.AddNewMode, "", "", "", "", _UserName, "",0);

        }
        public  enum enSaveResults { svFaildEmptyObject = 0, svSucceeded = 1, svFaildUserExists = 2 };
        public enSaveResults Save()
        {
            switch (_Mode)
            {
                case enMode.EmptyMode:
                    {
                        return enSaveResults.svFaildEmptyObject;
                    }
                case enMode.UpdateMode:
                    {
                        _Updute();
                        return enSaveResults.svSucceeded;
                    }
                case enMode.AddNewMode:
                    {
                        if (IsUserExist(_UserName))
                        {
                            return enSaveResults.svFaildUserExists;
                        }

                        else
                        {

                            _Mode = enMode.UpdateMode;
                            _AddNewUser();
                            return enSaveResults.svSucceeded;
                        }
                    }
                default:
                    return enSaveResults.svFaildEmptyObject;
            }
        }

        void _AddNewUser()
        {
            _AddDataLineToFile(this);
        }
        void _Updute()
        {

            List<clsUser> _list_user = _LoadUserData()!;

            foreach (clsUser _user in _list_user)
            {
                if (_user._UserName == UserName)
                {
                    _user.FirstName = FirstName;
                    _user.LastName = LastName;
                    _user.Phone = Phone;
                    _user.Email = Email;
                    _user._Password= Password;
                    _user._Permissions = Permissions;

                    break;
                }

            }

            _SaveDataToFile(_list_user);

        }
        public bool Delet()
        {
            List<clsUser> _list_user = _LoadUserData()!;

            foreach (clsUser _User in _list_user)
            {
                if (_User._UserName== UserName)
                {
                    _User.MarkedForDelete = true;
                    break;
                }

            }
            _SaveDataToFile(_list_user);
            
            
            Console.WriteLine("To Cheach The Object is empty after delet:UserName: " + FirstName);
            return true;
        }
       public  bool CheckAccessPermistion(enPermissions _enPermissions)
        {
            if (Permissions == (int)enPermissions.eAll) return true;
/*            if ((int)_enPermissions>0 && (int)_enPermissions<= Permissions) return true;
*/              if(((int)_enPermissions & this.Permissions)== (int)_enPermissions)return true;
            else return false;
        }

    }
}
