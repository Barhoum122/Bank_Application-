using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class ShowListCurrencyScreen :clsScreen
    {
        static void _PrintUsersRegisterRecordLine(clsCurrency UserRegister)
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" |{UserRegister.Country,-25}" + $"|{UserRegister.CurrencyName,-20}" + $"|{UserRegister.CurrencyCode,-20}" +
                $"|{UserRegister.Rate,-20}");
            Console.ResetColor();
            Console.WriteLine(" |.........................................................................................................|");


        }
        static void _HeaderList()
        {

            Console.WriteLine(" _____________________________________________________________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($" |{"Country",-25}" +
                $"|{"CurrencyName",-20}" +
                $"|{"CurrencyCode",-20}" +
                $"|{"Rate",-20}"
               );


            Console.ResetColor();
            Console.WriteLine("\n _____________________________________________________________________________________________________________");
        }

        public static void PrintListCurrency()
        {
            List<clsCurrency> UsersRegisterData = clsCurrency.GetAllUSDRates();
            /*Console.WriteLine("\n" + clsUtil.Tabs(7) + "Client List[" + _LitsClient.Count + "]");*/
            string Title = "List Currency Screen";

            _DrawScreenHeader(Title, " ");
            string SubTitle = "(" + UsersRegisterData!.Count.ToString() + ") Currency(s).\n";
            Console.WriteLine("\t\t\t\t\t" + SubTitle);
            _HeaderList();

            if (UsersRegisterData.Count != 0)
            {
                foreach (clsCurrency _User in UsersRegisterData)
                {
                    _PrintUsersRegisterRecordLine(_User);
                }
            }
            else
                Console.WriteLine("\n\n\n " + clsUtil.Tabs(6) + "NO List Currency Data Loading");
            Console.WriteLine("<:_____________________________________________________________________________________________________________:>");
            /*  _footerList();
  */
          /*  clsCurrency cls = FindByCountery("Yemen");
            _HeaderList();
            _PrintUsersRegisterRecordLine(cls);
            cls.UpdateRate(500.3);
            _HeaderList();
            _PrintUsersRegisterRecordLine(cls);*/


        }
    }
}
