using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsFindCurrencyScreen:clsScreen
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

        public static void PrintFindCurrency()
        {
            string Title = "Find Currency Screen";
            _DrawScreenHeader(Title, " ");
            Console.Write("Inter Countery Name To Find: ");

            string Choice = clsInputValidate.ReadString();
          
            clsCurrency cls = clsCurrency.FindByCode(Choice);
            if (!cls.IsEmpty())
            {
                _HeaderList();
                _PrintUsersRegisterRecordLine(cls);
                return;
            }
            Console.Write("\t\t\nNot Found the Countery..");
            return;
         
        


        }
    }
}
