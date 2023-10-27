namespace Azel_Raportare_Balkani
{

    public class DateDB
    {
        public DateTime Date_Time { get; set; }
        public double Putere { get; set; }

        public double Energie { get; set; }
        public double Presiune_Aductiune { get; set; }
        public double Presiune_GUP { get; set; }
        public double Pozitie_Injector_1 { get; set; }
        public double Pozitie_Injector_2 { get; set; }
        public double Vibratii_Generator { get; set; }
        public double Debit_Turbinat_Instantaneu { get; set; }
        public double Debit_Turbinat_Total { get; set; }
        public double Meteo_Temperatura { get; set; }
        public double Meteo_Umiditate { get; set; }
        public double Meteo_Precipitatii { get; set; }

        public string Doardata
        {
            get
            {
                // Stringul afisat 
                return $"{Date_Time.Day.ToString("D2")}/{Date_Time.Month.ToString("D2")}/{Date_Time.Year}";
            }
        }
        public string DoarTimp
        {
            get
            {
                // Stringul afisat 
                return $"{Date_Time.Hour.ToString("D2")}:{Date_Time.Minute.ToString("D2")}:{Date_Time.Second.ToString("D2")}";
            }
        }
        public string FullString
        {
            get
            {
                // Stringul afisat 
                return $"{Doardata},{DoarTimp},{Putere},{Energie},{Presiune_Aductiune},{Presiune_GUP},{Pozitie_Injector_1},{Pozitie_Injector_2},{Vibratii_Generator},{Debit_Turbinat_Instantaneu},{Debit_Turbinat_Total},{Meteo_Temperatura},{Meteo_Umiditate},{Meteo_Precipitatii}";
                return null;
            }
        }
    }
    public class DatePutere :ICloneable
    {
        public DateTime Date_Time { get; set; }
        public double Cuntu_Grup_1 { get; set; }
        public double Cuntu_Grup_2 { get; set; }
        public double Craiu_1_Grup_1 { get; set; }
        public double Craiu_1_Grup_2 { get; set; }
        public double Craiu_2_Grup_1 { get; set; }
        public double Craiu_2_Grup_2 { get; set; }
        public double Sebesel_1_Grup_1 { get; set; }
        public double Sebesel_1_Grup_2 { get; set; }
        public double Sebesel_2_Grup_1 { get; set; }
        public double Sebesel_2_Grup_2 { get; set; }
        public double Cornereva { get; set; }

        public double Total
        {
            get
            {
                return Math.Round(Cuntu_Grup_1 + Cuntu_Grup_2 + Craiu_1_Grup_1 + Craiu_1_Grup_2 + Craiu_2_Grup_1 + Craiu_2_Grup_2 + Sebesel_1_Grup_1 + Sebesel_1_Grup_2 + Sebesel_2_Grup_1 + Sebesel_2_Grup_2 + Cornereva, 1) ;
            }
        }

        public string Doardata
        {
            get
            {
                // Stringul afisat 
                return $"{Date_Time.Day.ToString("D2")}/{Date_Time.Month.ToString("D2")}/{Date_Time.Year}";
            }
        }
        public string DoarTimp
        {
            get
            {
                // Stringul afisat 
                return $"{Date_Time.Hour.ToString("D2")}:{Date_Time.Minute.ToString("D2")}:{Date_Time.Second.ToString("D2")}";
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }


}
