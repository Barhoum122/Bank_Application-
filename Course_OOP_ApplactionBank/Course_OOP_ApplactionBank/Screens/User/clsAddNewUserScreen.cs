using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsAddNewUserScreen:clsScreen
    {
     
     

        static void _ReadUserInfo(ref clsUser User)
        {
            Console.Clear();
            _DrawScreenHeader("TO Add New User");

            Console.Write("\n  Enter Frist Name  :");
            User.FirstName = clsInputValidate.ReadString();
            Console.Write("  Enter New Last Name :");
            User.LastName = clsInputValidate.ReadString();
            Console.Write("  Enter New Phone     :");
            User.Phone = clsInputValidate.ReadString();
            Console.Write("  Enter New Email     :");
            User.Email = clsInputValidate.ReadString();
            Console.Write("  Enter New Password  :");
            User.Password = clsInputValidate.ReadString();
            Console.Write("  Enter  Permissions  :");
           User.Permissions= _ReadPermissions();

        }
       static int _ReadPermissions()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int _Permissions = 0;
            char Answer = 'n';
            Console.Write("\n  Do you want to give full access? y/n?");
          
            Answer = clsInputValidate.Readchar();
            if (Answer == 'y' || Answer == 'Y')
            {
                
                return -1;
            }
            Console.Write(" Do you want to give access to Show List  Client Screen  y/n?");
            Answer = clsInputValidate.Readchar();
            if (Answer == 'y' || Answer == 'Y')
            {
                /*_Permissions += clsUser.enPermissions.pListClients;*/
                _Permissions += (int)clsUser.enPermissions.pListClients;

            }

            Console.Write(" Do you want to give access to Show Add New Client Screen  y/n?");
            Answer = clsInputValidate.Readchar();
            if (Answer == 'y' || Answer == 'Y')
            {
                /*_Permissions += clsUser.enPermissions.pListClients;*/
                _Permissions += (int)clsUser.enPermissions.pAddNewClient;

            }
            Console.Write(" Do you want to give access to Show Delet Client Screen  y/n?");
            Answer = clsInputValidate.Readchar();
            if (Answer == 'y' || Answer == 'Y')
            {
                /*_Permissions += clsUser.enPermissions.pListClients;*/
                _Permissions += (int)clsUser.enPermissions.pDeleteClient;

            }
            Console.Write(" Do you want to give access to _Show Update Client Screen  y/n?");
            Answer = clsInputValidate.Readchar();
            if (Answer == 'y' || Answer == 'Y')
            {
                /*_Permissions += clsUser.enPermissions.pListClients;*/
                _Permissions += (int)clsUser.enPermissions.pUpdateClients;

            }
            Console.Write(" Do you want to give access to  Show Find Client Screen  y/n?");
            Answer = clsInputValidate.Readchar();
            if (Answer == 'y' || Answer == 'Y')
            {
                /*_Permissions += clsUser.enPermissions.pListClients;*/
                _Permissions += (int)clsUser.enPermissions.pFindClient;

            }
            Console.Write(" Do you want to give access to Transactions  y /n?");
            Answer = clsInputValidate.Readchar();
            if (Answer == 'y' || Answer == 'Y')
            {

                _Permissions += (int)clsUser.enPermissions.pTranactions;

            }
            Console.Write(" Do you want to give access to Manage Users  y/n?");
            Answer = clsInputValidate.Readchar();
            if (Answer == 'y' || Answer == 'Y')
            {

                _Permissions += (int)clsUser.enPermissions.pManageUsers;

            }
            Console.Write(" Do you want to give access to Show List Register Screen  y/n?");
            Answer = clsInputValidate.Readchar();
            if (Answer == 'y' || Answer == 'Y')
            {

                _Permissions += (int)clsUser.enPermissions.pManageUsersRegister;

            }


            return _Permissions;

        }
        static void _PrintUser(clsUser user)
        {
            Console.WriteLine("\n Client Card ");
            Console.WriteLine("-------------------");
            Console.WriteLine(" Frist Name :" + user.FirstName);
            Console.WriteLine(" Last  Name :" + user.LastName);
            Console.WriteLine(" Full  Name :" + user.FirstName + " " + user.LastName);
            Console.WriteLine(" Phone      :" + user.Phone);
            Console.WriteLine(" Email      :" + user.Email);
            Console.WriteLine(" UserName :" + user.UserName);
            Console.WriteLine(" Permissions:" + user.Permissions);
            Console.WriteLine(" Password   :" + user.Password);
            Console.WriteLine("-------------------");

        }
        public static void ShowAddNewUserScreen()
        {
            _DrawScreenHeader("TO Add New User");
            string _UserName = "";
            Console.WriteLine("\n Please Inter User Name  : ");
            _UserName = clsInputValidate.ReadString();
            while (clsUser.IsUserExist(_UserName))
            {
                Console.WriteLine("Please Inter User Name  Again is Exist: ");
                _UserName = clsInputValidate.ReadString();
            }

            clsUser _NewUser = clsUser.GetAddNewUserObject(_UserName);

            _ReadUserInfo(ref _NewUser);

            clsUser.enSaveResults _enSaveResulte;
            _enSaveResulte = _NewUser.Save();

            switch (_enSaveResulte)
            {
                case
                   clsUser.enSaveResults.svSucceeded:
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\t\t(.-.) Added User Succesfuly");
                        Console.ResetColor();
                        _PrintUser(_NewUser);
                       /* Console.ResetColor();*/
                        break;
                    }
                case clsUser.enSaveResults.svFaildEmptyObject:
                    {
                        Console.WriteLine("Added User Faild,because is Empty");
                        break;
                    }
                case clsUser.enSaveResults.svFaildUserExists:
                    {
                        Console.WriteLine("Added User Faild,because is Name  Is Exist");
                        break;
                    }

                default:
                    break;
            }


        }
    }
}
