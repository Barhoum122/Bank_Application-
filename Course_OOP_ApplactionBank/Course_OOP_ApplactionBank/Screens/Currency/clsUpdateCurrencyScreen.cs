using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsUpdateCurrencyScreen:clsScreen
    {
        static void _HeaderList()
        {

            Console.WriteLine(" \t\t _______________________________________________________________________________\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"\t\t |{"Country",-15}" +
                $"\t\t|{"Code",-20}" +
                $"\t\t|{"Rate",-12}");


            Console.ResetColor();
            Console.WriteLine("\n\t\t _______________________________________________________________________________");
        }
        static void _PrintClientRecordLine(clsCurrency UserRegister, ConsoleColor color = ConsoleColor.White)
        {


            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"\t\t |{UserRegister.Country,-15}" + $"\t\t|{UserRegister.CurrencyCode,-20}");
            Console.ResetColor();
            Console.ForegroundColor = color;
            Console.Write($"\t\t|{UserRegister.Rate,-12}\n");
            Console.ResetColor();
            Console.WriteLine("\t \t .........................................................................");


        }

        private static void Printinfo(clsCurrency UserRegister, ConsoleColor color = ConsoleColor.White)
        {
            _HeaderList();
            _PrintClientRecordLine(UserRegister, color);

        }

      /*  static void _PrintUsersRegisterRecordLine(clsCurrency UserRegister)
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" |{UserRegister.Country,-25}" + $"|{UserRegister.CurrencyName,-20}" + $"|{UserRegister.CurrencyCode,-20}" +
                $"|{UserRegister.Rate,-20}");
            Console.ResetColor();
            Console.WriteLine(" |.........................................................................................................|");


        }*/
      /*  static void _HeaderList()
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
*/
        public static void PrintUpdateCurrency()
        {
            string Title = "Update Currency Screen";
            _DrawScreenHeader(Title, " ");
            Console.Write("Inter Countery Name To Find: ");

            string Countery = clsInputValidate.ReadString();

            clsCurrency cls = clsCurrency.FindByCode(Countery);
            if (!cls.IsEmpty())
            {
                Printinfo(cls);
                Console.Write("\nEnter new Rate : ");
                double Choice = clsInputValidate.ReadDblNumber();
                cls.UpdateRate(Choice);
                Console.Write("\n\t\t\t\tSeccsesful Update \n");

                Printinfo(cls,ConsoleColor.Green);
                return;
            }
            Console.Write("\t\t\nNot Found the Countery..");
            return;

          


        }
    }
}
