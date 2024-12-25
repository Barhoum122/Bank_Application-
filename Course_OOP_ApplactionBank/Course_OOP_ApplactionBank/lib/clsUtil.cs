using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace Course__OOP_Level_2_Applaction
{
    public class clsUtil
    {
      static  DateTime _DateTime = DateTime.Now;
        public static DateTime DateTime
        {
            set { _DateTime = value; }
            get { return _DateTime; }
        }


        public static string NumberToText(int Number)
        {

            if (Number == 0)
            {
                return "";
            }

            if (Number >= 1 && Number <= 19)
            {
                /* string arr[] = { "", "One","Two","Three","Four","Five","Six","Seven",
        "Eight","Nine","Ten","Eleven","Twelve","Thirteen","Fourteen",
          "Fifteen","Sixteen","Seventeen","Eighteen","Nineteen" };

                 return arr[Number] + " ";*/
                String[] arr = { "", "One","Two","Three","Four",
                    "Five","Six","Seven", "Eight","Nine","Ten","Eleven",
                    "Twelve","Thirteen","Fourteen", "Fifteen","Sixteen","Seventeen","Eighteen","Nineteen "};
                return arr[(int)Number] + " ";

            }

            if (Number >= 20 && Number <= 99)
            {
                string [] arr = { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
                return arr[Number / 10] + " " + NumberToText(Number % 10);
            }

            if (Number >= 100 && Number <= 199)
            {
                return "One Hundred " + NumberToText(Number % 100);
            }

            if (Number >= 200 && Number <= 999)
            {
                return NumberToText(Number / 100) + "Hundreds " + NumberToText(Number % 100);
            }

            if (Number >= 1000 && Number <= 1999)
            {
                return "One Thousand " + NumberToText(Number % 1000);
            }

            if (Number >= 2000 && Number <= 999999)
            {
                return NumberToText(Number / 1000) + "Thousands " + NumberToText(Number % 1000);
            }

            if (Number >= 1000000 && Number <= 1999999)
            {
                return "One Million " + NumberToText(Number % 1000000);
            }

            if (Number >= 2000000 && Number <= 999999999)
            {
                return NumberToText(Number / 1000000) + "Millions " + NumberToText(Number % 1000000);
            }

            if (Number >= 1000000000 && Number <= 1999999999)
            {
                return "One Billion " + NumberToText(Number % 1000000000);
            }
            else
            {
                return NumberToText(Number / 1000000000) + "Billions " + NumberToText(Number % 1000000000);
            }


        }

        public static string SearchTextInFile(string Path, string searchText)
        {
            string json = JsonSerializer.Serialize(searchText);
            string return_line = "";
            StreamReader sr = new StreamReader(Path);
            while ((return_line = sr.ReadLine()!) != null)
            {
                if (return_line.Contains(searchText))
                {
                    return_line = return_line.Replace(searchText, return_line);
                    Console.WriteLine(return_line);
                    return return_line;


                }


            }
            sr.Close();

            return "(!) Not found";

        }

      /*   static void _AddDataLineToFile(clsBankClient _object)
        {
            string _Path = @"D:\file\file.txt";
            string json = JsonSerializer.Serialize(_object);
            string _AfterConvertString = _object._ConvertClientToLine();
            StreamWriter sw = new StreamWriter(_Path, true);

            sw.WriteLine(_AfterConvertString);
            sw.Close();
           
        }*/
      /*   static void _SaveDataToFile(List<clsBankClient> List_objects)
        {

            string _Path = @"D:\file\file.txt";
            *//* string json =JsonSerializer.Serialize(_object);*//*
            
            File.Delete(_Path);
            StreamWriter sw = new StreamWriter(_Path, true);
            foreach (var Object_client in List_objects)
            {
                string DataLine = Object_client._ConvertClientToLine();
            sw.WriteLine(DataLine);
            }
            sw.Close();
           
        }  */
        public static string ReadFile(string Path)
        {
            string ReFile = "";
           
            if (File.Exists(Path))
            {
               StreamReader sr=new StreamReader(Path);
                ReFile= sr.ReadToEnd();
                sr.Close();
            }else
            return "NO File To Read";
            return ReFile;
        }

     public   enum enCharType
        {
            SamallLetter = 1, 
            CapitalLetter = 2,
            Digit = 3,
            MixChars = 4,
            SpecialCharacter = 5
        };
       
       public static int RandomNumber(int From, int To)
        {
         
            Random rand = new Random();
            //Function to generate a random number
            /*int randNum = rand() % (To - From + 1) + From;*/
            int randNum = rand.Next(From, To);
            return randNum;
        }
      public  static char GetRandomCharacter(enCharType CharType)
         {

            //updated this method to accept mixchars
            if (CharType == enCharType.MixChars)
            {
                //Capital/Samll/Digits only
                CharType = (enCharType)RandomNumber(1, 3);

            }

            switch (CharType)
            {

                case enCharType.SamallLetter:
                    {
                        return (char)RandomNumber(97, 122);
                     
                    }
                case enCharType.CapitalLetter:
                    {
                        return (char)RandomNumber(65, 90);
                       
                    }
                case enCharType.SpecialCharacter:
                    {
                   
                        return (char)RandomNumber(33, 47);
                     
                    }
                case enCharType.Digit:
                    {
                        return (char)RandomNumber(48, 57);
                    }
               /* defualt:
                    {
                        return (char)RandomNumber(65, 90);
                        break;
                    }*/

            }
            return (char)0; /*(char)RandomNumber(33, 122);*/

        }
      public  static string GenerateWord(enCharType CharType, int Length)

        {
            string Word="";

            for (int i = 1; i <= Length; i++)

            {

                Word = Word + GetRandomCharacter(CharType);

            }
            return Word;
        }
      public  static string GenerateKey(enCharType CharType = enCharType.CapitalLetter)
        {

            string Key = "";
            Key = GenerateWord(CharType, 4) + "-";
            Key = Key + GenerateWord(CharType, 4) + "-";
            Key = Key + GenerateWord(CharType, 4) + "-";
            Key = Key + GenerateWord(CharType, 4);


            return Key;
        }
      public  static string GenerateKeys(int NumberOfKeys, enCharType CharType = enCharType.MixChars)
        {
            string re = "";
            string key = "";
            for (int i = 1; i <= NumberOfKeys; i++)

            {


                Console.WriteLine("Key [" + i + "] :");
                Console.WriteLine(GenerateKey(CharType));
                /* cout << "Key [" << i << "] : ";
                 cout << GenerateKey(CharType) << endl;*/
            }
            return key+"\n"+re ;
        }
      public  static void FillArrayWithRandomNumbers(int[] arr , int arrLength, int From, int To)
        {
            for (int i = 0; i < arrLength; i++)
                arr[i] = RandomNumber(From, To);
           
        }
       public static void FillArrayWithRandomWords(string []arr, int arrLength, enCharType CharType, short Wordlength)
        {
            for (int i = 0; i < arrLength; i++)
                arr[i] = GenerateWord(CharType, Wordlength);


        }
       public static void Swap(ref int A , ref int B)
        {
            int Temp;

            Temp = A;
            A = B;
            B = Temp;
        }
        public static void Swap(ref bool A, ref bool B)
        {
            bool Temp;

            Temp = A;
            A = B;
            B = Temp;
        }
       public  static void Swap(ref char A, ref char B)
        {
            char Temp;

            Temp = A;
            A = B;
            B = Temp;
        }
       public  static void Swap(ref string A, ref string B)
        {
            string Temp;

            Temp = A;
            A = B;
            B = Temp;
        }
      /* public  static void Swap(ClsCalender._structDate date1, ClsCalender._structDate date2)
        {
            ClsCalender.Swapdates(ref date1, ref date2);
        }*/
       public static void ShuffleArray(int [] arr,  int arrLength)
        {

            for (int i = 0; i < arrLength; i++)
            {
                Swap(ref arr[RandomNumber(1, arrLength) - 1],ref  arr[RandomNumber(1, arrLength) - 1]);
            }

        }
       public static void ShuffleArray(string []arr, int arrLength)
        {

            for (int i = 0; i < arrLength; i++)
            {
                Swap(ref arr[RandomNumber(1, arrLength) - 1],ref arr[RandomNumber(1, arrLength) - 1]);
            }

        }
       public  static string Tabs(short NumberOfTabs)
        {
            string tab = "";

            for (int i = 1; i < NumberOfTabs; i++)
            {
                tab = tab + "\t";
              /* Console.WriteLine(tab);*/
            }
            return tab;
        }
       public static string EncryptText(string Text, short EncryptionKey=3)
        {
          char[] chars = Text.ToCharArray();

            for (int i = 0; i < Text.Length; i++)
            {

                 chars[i] = (char)(chars[i] + EncryptionKey);
            }
            return new string(chars);
        }
       public  static string DecryptText(string Text, short EncryptionKey=3)
        {

            char[] chars = Text.ToCharArray();

            for (int i = 0; i < Text.Length; i++)
            {

                chars[i] = (char)(chars[i] - EncryptionKey);




            }

            return new string(chars);

        }




    }




}

