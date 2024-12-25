using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsShowListUsersScreen:clsScreen
    {
        static void _PrintClientRecordLine(clsUser _User)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" |{_User.UserName,-15}" + $"|{_User.FirstName,-20}" + $"|{_User.Email,-20}" +
                $"|{_User.Password,-20}" + $"|{_User.Phone,-15}" + $"|{_User.Permissions,-12}");
            Console.ResetColor();
            Console.WriteLine(" |.........................................................................................................|");


        }
        static void _HeaderList()
        {

            Console.WriteLine(" _____________________________________________________________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($" |{"USERNAME",-15}" +
                $"|{"FRIST NAME",-20}" +
                $"|{"EMAIL",-20}" +
                $"|{"PASSWORD",-20}" +
                 $"|{"PHONE",-15}" +
                $"|{"PERMTION",-12}");


            Console.ResetColor();
            Console.WriteLine("\n _____________________________________________________________________________________________________________");
        }
      


        public static void ShowListUsersScreen()
        {
            List<clsUser> _LitsUser = clsUser._GetAllUser();
            /*Console.WriteLine("\n" + clsUtil.Tabs(7) + "Client List[" + _LitsClient.Count + "]");*/
            string Title = "User List Screen";
            string SubTitle = "(" + _LitsUser.Count.ToString() + ") User(s).";
            _DrawScreenHeader(Title, SubTitle);
            _HeaderList();

            if (_LitsUser.Count != 0)
            {
                foreach (clsUser _User in _LitsUser)
                {
                    _PrintClientRecordLine(_User);
                }
            }
            else
                Console.WriteLine("\n\n\n " + clsUtil.Tabs(6) + "NO Data Loading");
            Console.WriteLine("<:_____________________________________________________________________________________________________________:>");
            /*  _footerList();
  */

        }
       
    }
}
