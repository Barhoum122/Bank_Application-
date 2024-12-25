using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsRegisterUsersScreen:clsScreen
    {
        static void _PrintUsersRegisterRecordLine(clsUser.stUsersRegisterData UserRegister)
        {
            
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" |{UserRegister._DataTime,-25}" + $"|{UserRegister._UserName,-20}" + $"|{UserRegister._Password,-20}" +
                $"|{UserRegister._Permissions,-20}" );
            Console.ResetColor();
            Console.WriteLine(" |.........................................................................................................|");


        }
        static void _HeaderList()
        {
            
            Console.WriteLine(" _____________________________________________________________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($" |{"DateTime",-25}" +
                $"|{"User Name",-20}" +
                $"|{"PASSWORD",-20}" +
                $"|{"PERMTION",-20}" 
               );


            Console.ResetColor();
            Console.WriteLine("\n _____________________________________________________________________________________________________________");
        }



    
        public static void ShowListRegisterUsersScreen()
        {
            if (!CheckAccessRight(clsUser.enPermissions.pManageUsersRegister)) return; 
           List<clsUser.stUsersRegisterData> UsersRegisterData = clsUser._GetRegisterUserData();
            /*Console.WriteLine("\n" + clsUtil.Tabs(7) + "Client List[" + _LitsClient.Count + "]");*/
            string Title = "User List Screen";
           
            _DrawScreenHeader(Title," ");
            string SubTitle = "(" + UsersRegisterData!.Count.ToString() + ") User(s).";
            Console.WriteLine("\t\t\t\t\t"+SubTitle);
            _HeaderList();

            if (UsersRegisterData.Count != 0)
            {
                foreach (clsUser.stUsersRegisterData _User in UsersRegisterData)
                {
                    _PrintUsersRegisterRecordLine(_User);
                }
            }
            else
                Console.WriteLine("\n\n\n " + clsUtil.Tabs(6) + "NO Users Register Data Loading");
            Console.WriteLine("<:_____________________________________________________________________________________________________________:>");
            /*  _footerList();
  */

        }



    }
}
