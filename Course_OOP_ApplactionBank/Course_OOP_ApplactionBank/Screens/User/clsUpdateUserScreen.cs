using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsUpdateUserScreen:clsScreen
    {
        static void _ReadUserInfo(ref clsUser User)
        {
          
            

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
            User.Permissions = _ReadPermissions();

        }
        static void _PrintUser(clsUser user)
        {
            Console.WriteLine("\n User Card ");
            Console.WriteLine("-------------------");
            Console.WriteLine(" Frist Name :" + user.FirstName);
            Console.WriteLine(" Last  Name :" + user.LastName);
            Console.WriteLine(" Full  Name :" + user.FirstName + " " + user.LastName);
            Console.WriteLine(" Phone      :" + user.Phone);
            Console.WriteLine(" Email      :" + user.Email);
            Console.WriteLine(" User Name  :" + user.UserName);
            Console.WriteLine(" Permissions:" + user.Permissions);
            Console.WriteLine(" Password   :" + user.Password);
            Console.WriteLine("-------------------");

        }
        static int _ReadPermissions()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int _Permissions = 0;
            char Answer = 'n';
            Console.Write("\n Do you want to give full access? y/n?");

            Answer = clsInputValidate.Readchar();
            if (Answer == 'y' || Answer == 'Y')
            {

                return -1;
            }
            Console.Write(" Do you want to give access to Show List New Client Screen  y/n?");
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

        public static void ShowUpdateUsertScreen()
        {
            _DrawScreenHeader("TO Update a User");
            string UserName = "";
            int count = 0;
            while (count < 3)
            {
                if (count == 0)
                    Console.Write("\n Please Inter User Name : ");
                else Console.Write("\n Please Inter User Name  Again Not Found: ");
                UserName = clsInputValidate.ReadString();

                if (clsUser.IsUserExist(UserName))
                {

                    clsUser _User = clsUser.Find(UserName);
                    _PrintUser(_User);
                    Console.WriteLine("\n ---------Update User Info----------");
                    _ReadUserInfo(ref _User);
                    clsUser.enSaveResults _enSaveResulte;
                    _enSaveResulte = _User.Save();


                    switch (_enSaveResulte)
                    {
                        case
                          clsUser.enSaveResults.svSucceeded:
                            {
                                Console.WriteLine(" \n Update User Succsed");

                                break;
                            }
                        case clsUser.enSaveResults.svFaildEmptyObject:
                            {
                                Console.WriteLine("Update User Faild");
                                break;
                            }

                        default:
                            break;
                    }

                    break;

                }

                count++;

            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(count >= 3 ? "\n<:> Sorry,you Can`t Try This Moment Try Again Later....<:>\n" : "");
            Console.ResetColor();


        }
    }
}
