using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicatie_Scanner
{
    
    public class DateDB
    {
        public DateTime Data_Timp { get; set; }
        public string Furnizor { get; set; }
        public string Calitate { get; set; }
        public string GUID { get; set; }
        public string Doardata
        {
            get
            {
                // Stringul afisat 
                return $"{Data_Timp.Day.ToString("D2")}/{Data_Timp.Month.ToString("D2")}/{Data_Timp.Year}";
            }
        }
        public string DoarTimp
        {
            get
            {
                // Stringul afisat 
                return $"{Data_Timp.Hour.ToString("D2")}:{Data_Timp.Minute.ToString("D2")}:{Data_Timp.Second.ToString("D2")}";
            }
        }
    }
    public class DateFurnizori
    { 
        public float Index { get; set; }
        public DateTime Data_Timp { get; set; }
        public string Denumire { get; set; }
        public string Localitate { get; set; }


        public string Doardata
        {
            get
            {
                // Stringul afisat 
                return $"{Data_Timp.Day.ToString("D2")}/{Data_Timp.Month.ToString("D2")}/{Data_Timp.Year}";
            }
        }
        public string DoarTimp
        {
            get
            {
                // Stringul afisat 
                return $"{Data_Timp.Hour.ToString("D2")}:{Data_Timp.Minute.ToString("D2")}:{Data_Timp.Second.ToString("D2")}";
            }
        }
    }

    public class DateCalitate
    {
        public float Index { get; set; }

        public string Calitate { get; set; }
    }
}
