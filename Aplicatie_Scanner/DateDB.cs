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
        public string Nume_Reteta { get; set; }
        public float Cantitate_Descarcata_Snec_1 { get; set; }


        public float Referinta_Descarcare_Snec_1 { get; set; }


        public float Diferenta_Greutate_Snec_1 { get; set; }


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
}
