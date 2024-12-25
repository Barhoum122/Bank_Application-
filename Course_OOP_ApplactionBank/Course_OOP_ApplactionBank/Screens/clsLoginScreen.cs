using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsLoginScreen:clsScreen
    {
    static  bool _login()
        {
            DateTime dateTime = DateTime.Now;
            string _UserName = "";
            string password = "";
            bool LoginFaild = false;
            int FaildLoginCount=3;
            do {
                if (LoginFaild)
                {
                    FaildLoginCount--;
                    Console.Clear();
                    _DrawScreenHeader("Login Screen");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(clsUtil.Tabs(5) + "   Sorry, User Name Or Password Is Faild ");
                    Console.Write(clsUtil.Tabs(5) + "   You Have [" + FaildLoginCount + "] Trails to Logine \n ");
                    Console.ResetColor();
                    Console.WriteLine(clsUtil.Tabs(5) + " ===========================================");

                }
                if (FaildLoginCount == 0)
                {
                    
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\t\t   <:> Sorry,you Can`t Try This Moment Try Again Later Becouse The Temp Is Finshed <:>\n");
                    Console.ResetColor();
                    return false;
                }
                Console.Write(clsUtil.Tabs(6) + " Please Inter User Name  :");
                _UserName = clsInputValidate.ReadString();
                Console.Write(clsUtil.Tabs(6) + " Please Inter Password   :");
                password = clsInputValidate.ReadString();
                clsGlobalUser.Public_User = clsUser.Find(_UserName, password);
                
                LoginFaild = clsGlobalUser.Public_User.IsEmpty();
           


            } while (LoginFaild);
            Console.Clear();
            clsUser.SaveRegisterUserData(clsGlobalUser.Public_User, dateTime);
            clsMainScreen.ShowMainMenue();
            return true;
            

        }
        public static bool LoginScreen()
        {
            _DrawScreenHeader("Login Screen");
            return _login();

        }
      







        
    }
}
