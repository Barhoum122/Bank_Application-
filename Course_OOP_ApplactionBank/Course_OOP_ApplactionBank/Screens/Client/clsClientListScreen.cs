using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsClientListScreen: clsScreen
    {
        static void _PrintClientRecordLine(clsBankClient client)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" |{client.AccountNumber,-15}" + $"|{client.FirstName,-20}" + $"|{client.Email,-20}" +
                $"|{client.PinCode,-20}" + $"|{client.Phone,-15}" + $"|{client.AccountBalance,-12}");
            Console.ResetColor();
            Console.WriteLine(" |.........................................................................................................|");


        }
         static void _HeaderList()
        {

            Console.WriteLine(" _____________________________________________________________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($" |{"ACC-NMBERS",-15}" +
                $"|{"FRIST NAME",-20}" +
                $"|{"EMAIL",-20}" +
                $"|{"PASSWORD",-20}" +
                 $"|{"PHONE",-15}" +
                $"|{"ACC-BALANCE",-12}");


            Console.ResetColor();
            Console.WriteLine("\n _____________________________________________________________________________________________________________");
        }
         static void _footerList()
        {
           int _totalBalance = clsBankClient.GetTotaleBalance();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" " + clsUtil.Tabs(6) + "<:> Totile Balance:" +_totalBalance);
            Console.WriteLine(" " + clsUtil.Tabs(6) + "<:> " + clsUtil.NumberToText(_totalBalance));
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("<:_____________________________________________________________________________________________________________:>");
        }
        

        public static void ShowClientsList()
        {
            if (!CheckAccessRight(clsUser.enPermissions.pListClients)) return; 
            List<clsBankClient> _LitsClient =clsBankClient. _GetAllClient();
            /*Console.WriteLine("\n" + clsUtil.Tabs(7) + "Client List[" + _LitsClient.Count + "]");*/
            string Title = "Client List Screen";
            string SubTitle = "(" + _LitsClient.Count.ToString() + ") Client(s).";
            _DrawScreenHeader(Title, SubTitle);
            _HeaderList();

            if (_LitsClient.Count != 0)
            {
                foreach (clsBankClient client in _LitsClient)
                {
                    _PrintClientRecordLine(client);
                }
            }
            else
                Console.WriteLine("\n\n\n " + clsUtil.Tabs(6) + "NO Data Loading");

            _footerList();


        }
    }
}
