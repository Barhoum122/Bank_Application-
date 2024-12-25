using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsShowTotalBalancesScreen:clsScreen
    {
        static void _PrintClientRecordLine(clsBankClient client)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"\t\t |{client.AccountNumber,-15}" + $"\t\t|{client.FirstName,-20}"  + $"\t\t|{client.AccountBalance,-12}");
            Console.ResetColor();
            Console.WriteLine("\t \t |.........................................................................|");


        }
        static void _HeaderList()
        {

            Console.WriteLine(" \t\t _______________________________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"\t\t |{"ACC-NMBERS",-15}" +
                $"\t\t|{"FRIST NAME",-20}" +
                $"\t\t|{"ACC-BALANCE",-12}");


            Console.ResetColor();
            Console.WriteLine("\n\t\t _______________________________________________________________________________");
        }
        static void _footerList()
        {
            int _totalBalance = clsBankClient.GetTotaleBalance();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" " + clsUtil.Tabs(6) + "<:> Totile Balance:" + _totalBalance);
            Console.WriteLine(" " + clsUtil.Tabs(6) + "<:> " + clsUtil.NumberToText(_totalBalance));
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t\t<:_____________________________________________________________________________:>");
        }


        public static void ShowTotalBalancesScreen()
        {
            List<clsBankClient> _LitsClient = clsBankClient._GetAllClient();
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
