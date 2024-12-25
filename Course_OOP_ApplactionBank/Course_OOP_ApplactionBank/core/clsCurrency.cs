using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course__OOP_Level_2_Applaction
{
    public class clsCurrency
    {

        string _Country;
        string _CurrencyCode;
        string _CurrencyName;
        double _Rate;
     public   enum enMode { EmptyMode = 0, UpdateMode = 1 };
        enMode _Mode;

      public   clsCurrency(enMode Mode,  string Country, string CurrencyCode,string CurrencyName, double Rate)
        {
            _Mode = Mode;
            _Country = Country;
            _CurrencyCode = CurrencyCode;
            _CurrencyName = CurrencyName;
            _Rate = Rate;
           
        }
     public   bool IsEmpty()
        {
            return (_Mode == enMode.EmptyMode);
        }
       
        static clsCurrency _GetEmptyCurrencyObject()
        {
            clsCurrency Obj = new clsCurrency(enMode.EmptyMode, "", "", "", 0);
            return Obj;
        }
      
       
        static List<clsCurrency> _LoadCurrencysDataFromFile()
        {
            string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\_Currencies.txt";
            //* string json =JsonSerializer.Serialize(_object);*//*
            List<clsCurrency> clsCurrency = new List<clsCurrency>();
            StreamReader sr = new StreamReader(_Path);
            string line;
            while ((line = sr.ReadLine()!) != null)
            {
                if (line == null)
                {
                    break;
                }
                clsCurrency _Currency = _ConvertLinetoCurrencyObject(line);
                /* if (client.AccountNumber != null)*/
                clsCurrency.Add(_Currency);

            }
            sr.Close();
            return clsCurrency;

        }
        static void _SaveCurrencyDataToFile(List<clsCurrency> _Currency)
        {
            
            string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\_Currencies.txt";
            /* string json =JsonSerializer.Serialize(_object);*/

            File.Delete(_Path);
            StreamWriter sw = new StreamWriter(_Path, true);
            foreach (var Object in _Currency)
            {
                string DataLine = _ConverCurrencyObjectToLine(Object);
                sw.WriteLine(DataLine);
            }
            sw.Close();

        } 
      public  static void _SaveCurrencyDataToFile(clsCurrency _Currency)
        {
            
            string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\_Currencies.txt";
            /* string json =JsonSerializer.Serialize(_object);*/

            StreamWriter sw = new StreamWriter(_Path, true);
           
                string DataLine = _ConverCurrencyObjectToLine(_Currency);
                sw.WriteLine(DataLine);
            
            sw.Close();

        }
        void _Update()
        {

            List<clsCurrency> _vCurrencys;
            _vCurrencys = _LoadCurrencysDataFromFile();

            foreach (clsCurrency Obj in _vCurrencys)
            {
                if (Obj.CurrencyCode == CurrencyCode)
                {
                    Obj._Country = Country;
                    Obj._CurrencyCode = CurrencyCode;
                    Obj._CurrencyName = CurrencyName;
                    Obj._Rate = Rate;    
                    break;
                }

            }

            _SaveCurrencyDataToFile(_vCurrencys);

        }
        static clsCurrency _ConvertLinetoCurrencyObject(string Line)
        {
            string[] arr = Line.Split(',');

            clsCurrency _client = new clsCurrency(enMode.UpdateMode, arr[1], arr[2], arr[3], double.Parse(arr[4]));
            return _client;
        }
        static string _ConverCurrencyObjectToLine(clsCurrency clsCurrency)
        {
            return $"{clsCurrency._Mode},{clsCurrency._Country},{clsCurrency._CurrencyCode},{clsCurrency._CurrencyName},{clsCurrency._Rate}";
        }

        /// <summary>
        /// Public Function
        /// </summary>
        /// <returns></returns>
        public string Country
        {
            get { return _Country; }
        }
        public string CurrencyCode
        {
            get { return _CurrencyCode; }
        }
        public string CurrencyName
        {
            get { return _CurrencyName; }
        }
        public double Rate
        {
            get { return _Rate; }

        }
        public static List<clsCurrency> GetAllUSDRates()
        {

            return _LoadCurrencysDataFromFile();

        }
       
        public static bool IsCurrencyExist(string Code)
        {
            clsCurrency _Currency = FindByCode(Code);
            return !_Currency.IsEmpty();
        }
        public  double ConvertToUSD(double Amount)
        {
            return Amount / Rate;
        }
        public  double ConvertToOtherCurrency(double Amount,clsCurrency currencyTo)
        {
            double AmountInUSD = ConvertToUSD(Amount);
            if (currencyTo.CurrencyCode == "USD")
            {
                
                return AmountInUSD;
            }
            return AmountInUSD * currencyTo.Rate;
        }
        public void UpdateRate(double NewRate)
        {
            _Rate = NewRate;
            _Update();
        }

        public static clsCurrency FindByCode(string _CurrencyCode)
        {
            /* string json = JsonSerializer.Serialize(_object);*/
            string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\_Currencies.txt";
            StreamWriter sw = new StreamWriter(_Path, true);
            sw.Close();
            StreamReader sr = new StreamReader(_Path, true);
            string line;
            while ((line = sr.ReadLine()!) != null)
            {
                clsCurrency client = _ConvertLinetoCurrencyObject(line);
                /* if (client.AccountNumber != null)*/
                if (client.CurrencyCode == _CurrencyCode)
                {
                    sr.Close();
                    return client;
                }

            }
            sr.Close();
            return _GetEmptyCurrencyObject();

        }
        public static clsCurrency Find(string _Countery, string _CurrencyCode)
        {

            /* string json =JsonSerializer.Serialize(_object);*/
            string _Path = @"D:\Project_File_C#\Course_OOP_ApplactionBank\file\_Currencies.txt";
            StreamReader sr = new StreamReader(_Path);
            string line;

            while ((line = sr.ReadLine()!) != null)
            {
                clsCurrency Obj = _ConvertLinetoCurrencyObject(line);
                /* if (client.AccountNumber != null)*/
                if (Obj.CurrencyCode == _CurrencyCode && Obj._Country == _Countery)
                {
                    sr.Close();
                    return Obj;
                }

            }
            sr.Close();
            return _GetEmptyCurrencyObject();

        }
     
    }



    
}
