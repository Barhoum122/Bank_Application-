using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
	internal class clsInputValidate
	{
		
		public static bool IsNumberBetween(short Number, short From, short To)
		{
			if (Number >= From && Number <= To)
				return true;
			else
				return false;
		}
		public static bool IsNumberBetween(int Number, int From, int To)
		{
			if (Number >= From && Number <= To)
				return true;
			else
				return false;

		}
		public static bool IsNumberBetween(float Number, float From, float To)
		{
			if (Number >= From && Number <= To)
				return true;
			else
				return false;
		}
		public static bool IsNumberBetween(double Number, double From, double To)
		{
			if (Number >= From && Number <= To)
				return true;
			else
				return false;
		}
      
		public	static bool IsDateBetween(ClsCalender._structDate Date, ClsCalender._structDate From, ClsCalender._structDate To)
		{
			//Date>=From && Date<=To
			
			if ((ClsCalender.IsDate1LessThanData2( Date, From) || ClsCalender.IsDate1quailData2(Date, From))
				&&
				(ClsCalender.IsDate1GreaterThanData2(Date, To) || ClsCalender.IsDate1quailData2(Date, To))
			  )
			{
				return true;
			}

			//Date>=To && Date<=From
			if ((ClsCalender.IsDate1LessThanData2(Date, To) || ClsCalender.IsDate1quailData2(Date, To))
				&&
				(ClsCalender.IsDate1GreaterThanData2(Date, From) || ClsCalender.IsDate1quailData2(Date, From))
			   )
			{
				return true;
			}

			return false;
		}


		
      public  static int ReadIntNumber(string ErrorMessage = "Invalid Number, Enter again\n")
        {
            int Number;
            while (true)
            {
				string input = Console.ReadLine()!;
				if(int.TryParse(input, out Number))
                {
					break;
                }
                else
                {
					Console.WriteLine(ErrorMessage);
                }
               
            }
            return Number;
        }

       

       
		static short ReadShortNumber(string ErrorMessage = "Invalid Number, Enter again")
        {
            short Number;
            while (true)
            {
				string input = Console.ReadLine()!;
				if(short.TryParse(input, out Number))
                {
					break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                   /* Console.BackgroundColor = ConsoleColor.White;*/
                    Console.Write(ErrorMessage);
                    Console.ResetColor();
                }
               
            }
            return Number;
        }
	public static double ReadDblNumber(string ErrorMessage = "Invalid Number, Enter again\n")
        {
            double Number;
            while (true)
            {
				string input = Console.ReadLine()!;
				if(double.TryParse(input, out Number))
                {
					break;
                }
                else
                {
					Console.WriteLine(ErrorMessage);
                }
               
            }
            return Number;
        }

    public static int ReadIntNumberBetween(int From, int To, string ErrorMessage = "Number is not within range, Enter again:\n")
        {
            int Number = ReadIntNumber();

            while (!IsNumberBetween(Number, From, To))
            {
               
                Console.WriteLine(ErrorMessage);
                Number = ReadIntNumber();
            }
            return Number;
        }
	public	static short ReadShortNumberBetween(int From, int To, string ErrorMessage = "Number is not within range, Enter again:\n")
        {
            short Number = ReadShortNumber(clsUtil.Tabs(6) + "Invalid Number, Enter again? ");

            while (!IsNumberBetween(Number, From, To))
            {
               Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(ErrorMessage);
                Number = ReadShortNumber();
				Console.ResetColor();
            }
            return Number;
        }
       
		
		/*static double ReadDblNumber(string ErrorMessage = "Invalid Number, Enter again\n")
		{
			double Number;
			while (!(cin >> Number))
			{
				cin.clear();
				cin.ignore(numeric_limits < streamsize >::max(), '\n');
				Console.WriteLine(ErrorMessage);
			}
			return Number;
		}*/

        /*	static double ReadDblNumberBetween(double From, double To, string ErrorMessage = "Number is not within range, Enter again:\n")
            {
                double Number = ReadDblNumber();

                while (!IsNumberBetween(Number, From, To))
                {
                    Console.WriteLine(ErrorMessage);
                    Number = ReadDblNumber();
                }
                return Number;
            }*/
        public static string ReadString(string ErrorMessage= "Invalid String,Mybe is null Enter again:")
        {
				string input = Console.ReadLine()!;
			while (true)
			{
				if (input!="")
				{
					break;
				}else
					Console.Error.Write(ErrorMessage);
				 input = Console.ReadLine()!;

			}
			return input;
			

		} 
		public static char Readchar(string ErrorMessage= "Invalid Char,Choose Y or N Just:")
        {
            char input = char.Parse(Console.ReadLine()!);
         
			while (true)
			{
                if (input == 'Y' || input == 'y' || input == 'N' || input == 'n')
                {
                    break;
                }
                else
						Console.Error.Write(ErrorMessage);
					input = char.Parse(Console.ReadLine()!);





			}
			return input ;
			

		}
		public static float ReadFloutNumber(string ErrorMessage = "Invalid Number, Enter again Like this Format 0.0")
        {
            
			float Number;
		
			while (true)
			{
				string input = Console.ReadLine()!;
				if (float.TryParse(input, out Number))
				{
					break;
				}
				else
				{
					Console.WriteLine(ErrorMessage);
				}

			}
			return Number ;
		}
        public static bool IsValideDate(ClsCalender._structDate Date)
        {
            return ClsCalender.IsValideDate(Date);
        }
        //solving the proplem
        public static void ExecutingProplems()
		{

			ClsCalender._structDate date = ClsCalender.ReadFullDate();
          /*  short totalDaysOfTheYear = NumbersOfDaysFromBeginingOfTheYear(date);

            date = getDatefromNumberOfDayInMonth(totalDaysOfTheYear, date.Year);*/
            Console.WriteLine("IsValideDate: " + IsValideDate(date));
			;

		}





	}
}
