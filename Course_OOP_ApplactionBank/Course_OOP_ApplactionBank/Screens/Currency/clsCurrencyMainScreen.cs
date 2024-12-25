using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    internal class clsCurrencyMainScreen:clsScreen
    {
        enum enCurrencyExhangeOptions
        {
            eListCurrency = 1, eFindCurrency = 2, eUpdateRate = 3,
            eCurrencyCalu = 4, eMainMenu = 5
        }
        static short _ReadMainMenuScreen()
        {
            Console.Write(clsUtil.Tabs(6) + "Choose what do you want to do?[1 to 5] ? ");
            short Choice = clsInputValidate.ReadShortNumberBetween(1, 5, clsUtil.Tabs(6) + "Enter Number between 1 to 5? ");
            return Choice;
        }
		static void _ShowListCurrencyScreen()
		{
			ShowListCurrencyScreen.PrintListCurrency();
			
		}

		static void _ShowFindCurrencyScreen()
		{
			clsFindCurrencyScreen.PrintFindCurrency();
		
		}

		static void _ShowUpdateRateScreen()
		{
			clsUpdateCurrencyScreen.PrintUpdateCurrency();
		}

		static void _ShowCurrencyCalculatorScreen()
		{
			clsCurrency_CalculatorScreen.ShowCurrencyCalculatorScreen();
		}

		static void _ShowMainMenuScreen()
		{
			/*clsMainScreen.ShowMainMenue();*/
		}

		static void _GoBackToCurrencyMainScreen()
		{
			
			Console.Write(clsUtil.Tabs(6) + "\nPress Any Key To Back Currency Main Screen ? ");
            Console.ReadKey();
            Console.Clear();

            ShowCurrencyMainScreen();
        }

		static void _PrefromCurrencyExhangeOptions(enCurrencyExhangeOptions CurrencyExhangeOption)
        {
            switch (CurrencyExhangeOption)
            {
				case enCurrencyExhangeOptions.eListCurrency:
					Console.Clear();
					_ShowListCurrencyScreen();
					_GoBackToCurrencyMainScreen();
					break;
				case enCurrencyExhangeOptions.eFindCurrency:
					Console.Clear();
					_ShowFindCurrencyScreen();
					_GoBackToCurrencyMainScreen();
					break;
				case enCurrencyExhangeOptions.eUpdateRate:
					Console.Clear();
					_ShowUpdateRateScreen();
					_GoBackToCurrencyMainScreen();
					break;

				case enCurrencyExhangeOptions.eCurrencyCalu:
					Console.Clear();
					_ShowCurrencyCalculatorScreen();
					_GoBackToCurrencyMainScreen();
					break;
				/*case enCurrencyExhangeOptions.eMainMenu:
					
					break;
*/
					default:

					break;


			}
        }

		public static void ShowCurrencyMainScreen()
        {
			_DrawScreenHeader("Currency Exhange Main Screen", " ");
			Console.WriteLine(clsUtil.Tabs(6) + " ===========================================");
			Console.WriteLine(clsUtil.Tabs(7) + " Currency Exhange Menue\n");
			Console.WriteLine(clsUtil.Tabs(6) + " [1] List Currencies..");
			Console.WriteLine(clsUtil.Tabs(6) + " [2] Find Currency..");
			Console.WriteLine(clsUtil.Tabs(6) + " [3] Update Rate.");
			Console.WriteLine(clsUtil.Tabs(6) + " [4] Currency Calculator.");
			Console.WriteLine(clsUtil.Tabs(6) + " [5] Main Menue.\n");

			Console.WriteLine(clsUtil.Tabs(6) + " ===========================================");
			_PrefromCurrencyExhangeOptions((enCurrencyExhangeOptions)_ReadMainMenuScreen());
		}

	}
}
