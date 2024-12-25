using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsCurrency_CalculatorScreen:clsScreen
    {
        static double _ReadAmount()
        {
            Console.WriteLine("Enter Amount to Exchange: ");
            double Amount = 0;
            Amount = clsInputValidate.ReadFloutNumber();
            return Amount;
        }
        static clsCurrency _GetCurrency(string Message)
        {

            string CurrencyCode;
            Console.WriteLine(Message);
           

            CurrencyCode = clsInputValidate.ReadString();

            while (!clsCurrency.IsCurrencyExist(CurrencyCode))
            {
                Console.WriteLine("Currency is not found, choose another one:");
               
                CurrencyCode = clsInputValidate.ReadString();
            }

            clsCurrency Currency = clsCurrency.FindByCode(CurrencyCode);
            return Currency;

        }

        static void _PrintCurrencyCard(clsCurrency Currency, string Title = "Currency Card:")
        {
           

                Console.WriteLine(Title+" \n");
                Console.WriteLine(" _____________________________________________________________________________________________________________\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($" |{"Country",-25}" +
                    $"|{"CurrencyName",-20}" +
                    $"|{"CurrencyCode",-20}" +
                    $"|{"Rate",-20}"
                   );


                Console.ResetColor();
                Console.WriteLine("\n _____________________________________________________________________________________________________________");
          

          

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($" |{Currency.Country,-25}" + $"|{Currency.CurrencyName,-20}" + $"|{Currency.CurrencyCode,-20}" +
                    $"|{Currency.Rate,-20}");
                Console.ResetColor();
                Console.WriteLine(" |.........................................................................................................|");


           
        }

        static void _PrintCalculationsResults(double Amount, clsCurrency Currency1, clsCurrency Currency2)
        {

            _PrintCurrencyCard(Currency1, "Convert From:");

            double AmountInUSD = Currency1.ConvertToUSD(Amount);
            Console.WriteLine(clsUtil.Tabs(6) + Amount+" "+ Currency1.CurrencyCode+" = "+ AmountInUSD+ " $USD");
            Console.WriteLine(clsUtil.Tabs(6) + "<:> " + clsUtil.NumberToText((int)AmountInUSD)+ " $USD");


            if (Currency2.CurrencyCode == "USD")
            {
                return;
            }

          
            Console.WriteLine("Converting from USD to:");

            _PrintCurrencyCard(Currency2, "To:");

            double AmountInCurrrency2 = Currency1.ConvertToOtherCurrency(Amount, Currency2);
            Console.WriteLine(clsUtil.Tabs(6) + Amount + " " + Currency1.CurrencyCode + " = " + AmountInCurrrency2 + " "+ Currency2.CurrencyCode);
          
            Console.WriteLine(clsUtil.Tabs(6) + "<:> " + clsUtil.NumberToText((int)AmountInCurrrency2));


        }




      public  static void ShowCurrencyCalculatorScreen()
        {
            char Continue = 'y';

            while (Continue == 'y' || Continue == 'Y')
            {
                Console.Clear();

                _DrawScreenHeader("\tUpdate Currency Screen");

                clsCurrency CurrencyFrom = _GetCurrency("\nPlease Enter Currency1 Code: ");
                clsCurrency CurrencyTo = _GetCurrency("\nPlease Enter Currency2 Code: ");
                double Amount = _ReadAmount();

                _PrintCalculationsResults(Amount, CurrencyFrom, CurrencyTo);
                Console.WriteLine("Do you want to perform another calculation? y/n ? ");
               /* Continue =char.Parse( Console.ReadLine()!);*/
                Continue=clsInputValidate.Readchar();



            }


        }

    }
}
