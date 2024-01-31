using Dapper;
using System.CodeDom.Compiler;
using System.Data;

namespace Azel_Raportare_Balkani
{
    public class Debit_Calculat
    {
        public static bool[] Index = new bool[11];
    }
    public class DataAccess
    {
        public List<DateDB> GetDateToataZiua(DateTime DataSetata1, DateTime DataSetata2, String Conditii_Where, String Zona_Selectie)
        {

            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
                {

                    string sql = $"select * from {Zona_Selectie} WHERE (Date_Time BETWEEN '{DataSetata1.ToString("yyyy-MM-dd HH:mm:ss.fff")}' AND '{DataSetata2.ToString("yyyy-MM-dd HH:mm:ss.fff")}') {Conditii_Where} ORDER BY Date_Time";
                    var output = connection.Query<DateDB>($"select * from {Zona_Selectie} WHERE (Date_Time BETWEEN '{DataSetata1.ToString("yyyy-MM-dd HH:mm:ss.fff")}' AND '{DataSetata2.ToString("yyyy-MM-dd HH:mm:ss.fff")}') ORDER BY Date_Time").ToList();
                    
                    foreach (var item in output)
                    {
                        item.Putere = Verificare_Pozitiv(item.Putere);
                        
                    }

                    return output;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Database Error: " + ex.Message);
                return null;
            }
        }

        public List<DatePutere> GetDatePuteri(DateTime DataSetata1, DateTime DataSetata2)
        {

            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
                {
                   /* string sql = $"" +
                        $"SELECT Cuntu_Grup_1.[Date_Time] " +
                        $",Cuntu_Grup_1.[Putere] as Cuntu_Grup_1 " +
                        $",Cuntu_Grup_2.[Putere] as Cuntu_Grup_2 " +
                        $",Sebesel_2_Grup_1.[Putere] as Sebesel_2_Grup_1 " +
                        $",Sebesel_2_Grup_2.[Putere] as Sebesel_2_Grup_2 " +
                        $" FROM Cuntu_Grup_1" +
                        $" full outer join Cuntu_Grup_2" +
                        $" on ((Cuntu_Grup_1.Date_Time < DATEADD(ss,30,Cuntu_Grup_2.Date_Time) ) and (Cuntu_Grup_1.Date_Time > DATEADD(ss,-30,Cuntu_Grup_2.Date_Time)))" +
                        $" full outer join Sebesel_2_Grup_1" +
                        $" on ((Cuntu_Grup_1.Date_Time < DATEADD(ss,30,Sebesel_2_Grup_1.Date_Time)) and (Cuntu_Grup_1.Date_Time > DATEADD(ss,-30,Sebesel_2_Grup_1.Date_Time)))" +
                        $" full outer join Sebesel_2_Grup_2" +
                        $" on ((Cuntu_Grup_1.Date_Time < DATEADD(ss,30,Sebesel_2_Grup_2.Date_Time)) and (Cuntu_Grup_1.Date_Time > DATEADD(ss,-30,Sebesel_2_Grup_2.Date_Time)))" +
                        $" WHERE (Cuntu_Grup_1.Date_Time BETWEEN '{DataSetata1.ToString("yyyy-MM-dd HH:mm:ss.fff")}' AND '{DataSetata2.ToString("yyyy-MM-dd HH:mm:ss.fff")}')" +
                        $" ORDER BY Date_Time ";*/

                    var output = connection.Query<DatePutere>($"" +
                        $"SELECT Cuntu_Grup_2.[Date_Time] " +

                        $",Cuntu_Grup_1.[Putere] as Cuntu_Grup_1 " +
                        $",Cuntu_Grup_2.[Putere] as Cuntu_Grup_2 " +
                        $",Craiu_1_Grup_1.[Putere] as Craiu_1_Grup_1 " +
                        $",Craiu_1_Grup_2.[Putere] as Craiu_1_Grup_2 " +
                        $",Craiu_2_Grup_1.[Putere] as Craiu_2_Grup_1 " +
                        $",Craiu_2_Grup_2.[Putere] as Craiu_2_Grup_2 " +
                        $",Sebesel_1_Grup_1.[Putere] as Sebesel_1_Grup_1 " +
                        $",Sebesel_1_Grup_2.[Putere] as Sebesel_1_Grup_2 " +
                        $",Sebesel_2_Grup_1.[Putere] as Sebesel_2_Grup_1 " +
                        $",Sebesel_2_Grup_2.[Putere] as Sebesel_2_Grup_2 " +
                        $",Cornereva.[Putere] as Cornereva " +

                        $" FROM Cuntu_Grup_2" +
                        $" full outer join Cuntu_Grup_1" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Cuntu_Grup_1.Date_Time) ) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Cuntu_Grup_1.Date_Time)))" +
                       
                        $" full outer join Craiu_1_Grup_1" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Craiu_1_Grup_1.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Craiu_1_Grup_1.Date_Time)))" +

                        $" full outer join Craiu_1_Grup_2" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Craiu_1_Grup_2.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Craiu_1_Grup_2.Date_Time)))" +

                        $" full outer join Craiu_2_Grup_1" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Craiu_2_Grup_1.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Craiu_2_Grup_1.Date_Time)))" +

                        $" full outer join Craiu_2_Grup_2" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Craiu_2_Grup_2.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Craiu_2_Grup_2.Date_Time)))" +
                       
                        $" full outer join Sebesel_1_Grup_1" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Sebesel_1_Grup_1.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Sebesel_1_Grup_1.Date_Time)))" +

                        $" full outer join Sebesel_1_Grup_2" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Sebesel_1_Grup_2.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Sebesel_1_Grup_2.Date_Time)))" +

                        $" full outer join Sebesel_2_Grup_1" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Sebesel_2_Grup_1.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Sebesel_2_Grup_1.Date_Time)))" +

                        $" full outer join Sebesel_2_Grup_2" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Sebesel_2_Grup_2.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Sebesel_2_Grup_2.Date_Time)))" +
                        
                        $" full outer join Cornereva" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Cornereva.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Cornereva.Date_Time)))" +



                        $" WHERE (Cuntu_Grup_2.Date_Time BETWEEN '{DataSetata1.ToString("yyyy-MM-dd HH:mm:ss.fff")}' AND '{DataSetata2.ToString("yyyy-MM-dd HH:mm:ss.fff")}')" +
                        $" ORDER BY Date_Time ").ToList();

                    foreach ( var item in output)
                    {
                       item.Cuntu_Grup_1= Verificare_Pozitiv(item.Cuntu_Grup_1);
                       item.Cuntu_Grup_2 = Verificare_Pozitiv(item.Cuntu_Grup_2);
                       item.Craiu_1_Grup_1 = Verificare_Pozitiv(item.Craiu_1_Grup_1);
                       item.Craiu_1_Grup_2 = Verificare_Pozitiv(item.Craiu_1_Grup_2);
                       item.Craiu_2_Grup_1 = Verificare_Pozitiv(item.Craiu_2_Grup_1);
                       item.Craiu_2_Grup_2 = Verificare_Pozitiv(item.Craiu_2_Grup_2);
                       item.Sebesel_1_Grup_1 = Verificare_Pozitiv(item.Sebesel_1_Grup_1);
                       item.Sebesel_1_Grup_2 = Verificare_Pozitiv(item.Sebesel_1_Grup_2);
                       item.Sebesel_2_Grup_1 = Verificare_Pozitiv(item.Sebesel_2_Grup_1);
                       item.Sebesel_2_Grup_2 = Verificare_Pozitiv(item.Sebesel_2_Grup_2);
                       item.Cornereva = Verificare_Pozitiv(item.Cornereva);
                    }
                    return output;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Database Error: " + ex.Message);
                return null;
            }
        }
        private double Verificare_Pozitiv(double valoare)
        {
            if (valoare <0) 
            { 
            valoare = 0;
            }
            return valoare;
        }
        public List<DatePutere> GetDateEnergie(DateTime DataSetata1, DateTime DataSetata2)
        {

            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
                {

                    var output = connection.Query<DatePutere>($"" +
                         $"SELECT Cuntu_Grup_2.[Date_Time] " +

                        $",Cuntu_Grup_1.[Energie] as Cuntu_Grup_1 " +
                        $",Cuntu_Grup_2.[Energie] as Cuntu_Grup_2 " +
                        $",Craiu_1_Grup_1.[Energie] as Craiu_1_Grup_1 " +
                        $",Craiu_1_Grup_2.[Energie] as Craiu_1_Grup_2 " +
                        $",Craiu_2_Grup_1.[Energie] as Craiu_2_Grup_1 " +
                        $",Craiu_2_Grup_2.[Energie] as Craiu_2_Grup_2 " +
                        $",Sebesel_1_Grup_1.[Energie] as Sebesel_1_Grup_1 " +
                        $",Sebesel_1_Grup_2.[Energie] as Sebesel_1_Grup_2 " +
                        $",Sebesel_2_Grup_1.[Energie] as Sebesel_2_Grup_1 " +
                        $",Sebesel_2_Grup_2.[Energie] as Sebesel_2_Grup_2 " +
                        $",Cornereva.[Energie] as Cornereva " +

                        $" FROM Cuntu_Grup_2" +
                        $" full outer join Cuntu_Grup_1" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Cuntu_Grup_1.Date_Time) ) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Cuntu_Grup_1.Date_Time)))" +

                        $" full outer join Craiu_1_Grup_1" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Craiu_1_Grup_1.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Craiu_1_Grup_1.Date_Time)))" +

                        $" full outer join Craiu_1_Grup_2" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Craiu_1_Grup_2.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Craiu_1_Grup_2.Date_Time)))" +

                        $" full outer join Craiu_2_Grup_1" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Craiu_2_Grup_1.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Craiu_2_Grup_1.Date_Time)))" +

                        $" full outer join Craiu_2_Grup_2" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Craiu_2_Grup_2.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Craiu_2_Grup_2.Date_Time)))" +

                        $" full outer join Sebesel_1_Grup_1" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Sebesel_1_Grup_1.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Sebesel_1_Grup_1.Date_Time)))" +

                        $" full outer join Sebesel_1_Grup_2" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Sebesel_1_Grup_2.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Sebesel_1_Grup_2.Date_Time)))" +

                        $" full outer join Sebesel_2_Grup_1" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Sebesel_2_Grup_1.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Sebesel_2_Grup_1.Date_Time)))" +

                        $" full outer join Sebesel_2_Grup_2" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Sebesel_2_Grup_2.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Sebesel_2_Grup_2.Date_Time)))" +
                        
                        $" full outer join Cornereva" +
                        $" on ((Cuntu_Grup_2.Date_Time < DATEADD(ss,30,Cornereva.Date_Time)) and (Cuntu_Grup_2.Date_Time > DATEADD(ss,-30,Cornereva.Date_Time)))" +



                        $" WHERE (Cuntu_Grup_2.Date_Time BETWEEN '{DataSetata1.ToString("yyyy-MM-dd HH:mm:ss.fff")}' AND '{DataSetata2.ToString("yyyy-MM-dd HH:mm:ss.fff")}')" +
                        $" ORDER BY Date_Time ").ToList();

                    for (int i = 0; i < output.Count-1; i++)
                    {
                        var date = new Tuple<DatePutere, DatePutere>(output[i], output[i + 1]);

                        Verificare_Energie(ref date);
                        output[i] = date.Item1;
                        output[i + 1] = date.Item2;
                     
                    }
                    output.RemoveAt(output.Count-1);
                    return output;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Database Error: " + ex.Message);
                return null;
            }
        }
        private void Verificare_Energie(ref Tuple<DatePutere, DatePutere> i)
        {
            double initial = i.Item1.Cuntu_Grup_1;
            double final = i.Item2.Cuntu_Grup_1;
            Verificare_Valori_Energie(ref initial, ref final);
            i.Item1.Cuntu_Grup_1 = initial;
            i.Item2.Cuntu_Grup_1 = final;

            initial = i.Item1.Cuntu_Grup_2;
            final = i.Item2.Cuntu_Grup_2;
            Verificare_Valori_Energie(ref initial, ref final);
            i.Item1.Cuntu_Grup_2 = initial;
            i.Item2.Cuntu_Grup_2 = final;

            initial = i.Item1.Craiu_1_Grup_1;
            final = i.Item2.Craiu_1_Grup_1;
            Verificare_Valori_Energie(ref initial, ref final);
            i.Item1.Craiu_1_Grup_1 = initial;
            i.Item2.Craiu_1_Grup_1 = final;

            initial = i.Item1.Craiu_1_Grup_2;
            final = i.Item2.Craiu_1_Grup_2;
            Verificare_Valori_Energie(ref initial, ref final);
            i.Item1.Craiu_1_Grup_2 = initial;
            i.Item2.Craiu_1_Grup_2 = final;

            initial = i.Item1.Craiu_2_Grup_1;
            final = i.Item2.Craiu_2_Grup_1;
            Verificare_Valori_Energie(ref initial, ref final);
            i.Item1.Craiu_2_Grup_1 = initial;
            i.Item2.Craiu_2_Grup_1 = final;

            initial = i.Item1.Craiu_2_Grup_2;
            final = i.Item2.Craiu_2_Grup_2;
            Verificare_Valori_Energie(ref initial, ref final);
            i.Item1.Craiu_2_Grup_2 = initial;
            i.Item2.Craiu_2_Grup_2 = final;

            initial = i.Item1.Sebesel_1_Grup_1;
            final = i.Item2.Sebesel_1_Grup_1;
            Verificare_Valori_Energie(ref initial, ref final);
            i.Item1.Sebesel_1_Grup_1 = initial;
            i.Item2.Sebesel_1_Grup_1 = final;

            initial = i.Item1.Sebesel_1_Grup_2;
            final = i.Item2.Sebesel_1_Grup_2;
            Verificare_Valori_Energie(ref initial, ref final);
            i.Item1.Sebesel_1_Grup_2 = initial;
            i.Item2.Sebesel_1_Grup_2 = final;

            initial = i.Item1.Sebesel_2_Grup_1;
            final = i.Item2.Sebesel_2_Grup_1;
            Verificare_Valori_Energie(ref initial, ref final);
            i.Item1.Sebesel_2_Grup_1 = initial;
            i.Item2.Sebesel_2_Grup_1 = final;

            initial = i.Item1.Sebesel_2_Grup_2;
            final = i.Item2.Sebesel_2_Grup_2;
            Verificare_Valori_Energie(ref initial, ref final);
            i.Item1.Sebesel_2_Grup_2 = initial;
            i.Item2.Sebesel_2_Grup_2 = final;

            initial = i.Item1.Cornereva;
            final = i.Item2.Cornereva;
            Verificare_Valori_Energie(ref initial, ref final);
            i.Item1.Cornereva = initial;
            i.Item2.Cornereva = final;


        }
        private void Verificare_Valori_Energie(ref double valoare_initiala,ref double valoare_finala)
        {
       
            if (valoare_initiala <= 0 && valoare_finala > 0)
            {
                valoare_initiala = 0;

            }
            else if (valoare_finala <= 0 && valoare_initiala > 0)
            {
                valoare_finala = valoare_initiala;
                valoare_initiala = Math.Round(valoare_finala - valoare_initiala,2);
            }
            else if (valoare_initiala <= 0 && valoare_finala <= 0)
            {
                valoare_initiala = 0;
            }
            else
            {
                valoare_initiala = Math.Round(valoare_finala - valoare_initiala, 2);
            }
            

        }

        public List<DateRaportZilnic> GetDateRaportZilnic()
        {

            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
                {

                    var output = connection.Query<DateRaportZilnic>($"Select * From (Select top (1)  Energie, 'Cuntu_Grup_1' as Nume_Grup from Cuntu_Grup_1 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}' Order by Date_Time desc) As A1 " +
                        $"\r\nUNION ALL\r\nSelect * From (Select top (1)  Energie, 'Cuntu_Grup_2' as Nume_Grup from Cuntu_Grup_2 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}'  Order by Date_Time desc) As A2" +
                        $"\r\nUNION ALL\r\nSelect * From (Select top (1)  Energie, 'Craiu_1_Grup_1' as Nume_Grup from Craiu_1_Grup_1 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}'  Order by Date_Time desc) As A3" +
                        $"\r\nUNION ALL\r\nSelect * From (Select top (1)  Energie, 'Craiu_1_Grup_2' as Nume_Grup from Craiu_1_Grup_2 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}'  Order by Date_Time desc) As A4" +
                        $"\r\nUNION ALL\r\nSelect * From (Select top (1)  Energie, 'Craiu_2_Grup_1' as Nume_Grup from Craiu_2_Grup_1 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}'  Order by Date_Time desc) As A5" +
                        $"\r\nUNION ALL\r\nSelect * From (Select top (1)  Energie, 'Craiu_2_Grup_2' as Nume_Grup from Craiu_2_Grup_2 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}'  Order by Date_Time desc) As A6" +
                        $"\r\nUNION ALL\r\nSelect * From (Select top (1)  Energie, 'Sebesel_1_Grup_1' as Nume_Grup from Sebesel_1_Grup_1 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}'  Order by Date_Time desc) As A7" +
                        $"\r\nUNION ALL\r\nSelect * From (Select top (1)  Energie, 'Sebesel_1_Grup_2' as Nume_Grup from Sebesel_1_Grup_2 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}'  Order by Date_Time desc) As A8" +
                        $"\r\nUNION ALL\r\nSelect * From (Select top (1)  Energie, 'Sebesel_2_Grup_1' as Nume_Grup from Sebesel_2_Grup_1 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}'  Order by Date_Time desc) As A9" +
                        $"\r\nUNION ALL\r\nSelect * From (Select top (1)  Energie, 'Sebesel_2_Grup_2' as Nume_Grup from Sebesel_2_Grup_2 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}'  Order by Date_Time desc) As A10" +
                        $"\r\nUNION ALL\r\nSelect * From (Select top (1)  Energie, 'Cornereva' as Nume_Grup from Cornereva where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}'  Order by Date_Time desc) As A11").ToList();



                    return output;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Database Error: " + ex.Message);
                return null;
            }
        }
        public List<DateRaportZilnic> GetDateRaportZilnicZiuaTrecuta()
        {

            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
                {

                    var output = connection.Query<DateRaportZilnic>($"Select * From (Select top (1)  Energie, 'Cuntu_Grup_1' as Nume_Grup from Cuntu_Grup_1 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddDays(-1).AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}' Order by Date_Time desc) As A1" +
                        $"\r\nUNION ALL" +
                        $"\r\nSelect * From (Select top (1)  Energie, 'Cuntu_Grup_2' as Nume_Grup from Cuntu_Grup_2 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddDays(-1).AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}' Order by Date_Time desc) As A2" +
                        $"\r\nUNION ALL" +
                        $"\r\nSelect * From (Select top (1)  Energie, 'Craiu_1_Grup_1' as Nume_Grup from Craiu_1_Grup_1 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddDays(-1).AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}' Order by Date_Time desc) As A3" +
                        $"\r\nUNION ALL" +
                        $"\r\nSelect * From (Select top (1)  Energie, 'Craiu_1_Grup_2' as Nume_Grup from Craiu_1_Grup_2 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddDays(-1).AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}' Order by Date_Time desc) As A4" +
                        $"\r\nUNION ALL" +
                        $"\r\nSelect * From (Select top (1)  Energie, 'Craiu_2_Grup_1' as Nume_Grup from Craiu_2_Grup_1 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddDays(-1).AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}' Order by Date_Time desc) As A5" +
                        $"\r\nUNION ALL" +
                        $"\r\nSelect * From (Select top (1)  Energie, 'Craiu_2_Grup_2' as Nume_Grup from Craiu_2_Grup_2 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddDays(-1).AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}' Order by Date_Time desc) As A6" +
                        $"\r\nUNION ALL" +
                        $"\r\nSelect * From (Select top (1)  Energie, 'Sebesel_1_Grup_1' as Nume_Grup from Sebesel_1_Grup_1 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddDays(-1).AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}' Order by Date_Time desc) As A7" +
                        $"\r\nUNION ALL" +
                        $"\r\nSelect * From (Select top (1)  Energie, 'Sebesel_1_Grup_2' as Nume_Grup from Sebesel_1_Grup_2 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddDays(-1).AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}' Order by Date_Time desc) As A8" +
                        $"\r\nUNION ALL" +
                        $"\r\nSelect * From (Select top (1)  Energie, 'Sebesel_2_Grup_1' as Nume_Grup from Sebesel_2_Grup_1 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddDays(-1).AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}' Order by Date_Time desc) As A9" +
                        $"\r\nUNION ALL" +
                        $"\r\nSelect * From (Select top (1)  Energie, 'Sebesel_2_Grup_2' as Nume_Grup from Sebesel_2_Grup_2 where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddDays(-1).AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}' Order by Date_Time desc) As A10" +
                        $"\r\nUNION ALL" +
                        $"\r\nSelect * From (Select top (1)  Energie, 'Cornereva' as Nume_Grup from Cornereva where Energie > 0 and Date_Time < '{DateTime.Now.Date.AddDays(-1).AddMinutes(1).ToString("yyyy-MM-dd HH:mm")}' Order by Date_Time desc) As A11").ToList();



                    return output;

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Database Error: " + ex.Message);
                return null;
            }
        }

        /*     public List<DateDB> GetDateOra(DateTime DataSetata1, DateTime DataSetata2, DateTime timpselectat)
             {

                 using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
                 {

                     var output = connection.Query<DateDB>($"select * from Linia_2 WHERE ((Data_Timp BETWEEN '{DataSetata1}' AND '{DataSetata2}') AND (DATEPART(HOUR,Data_Timp) = DATEPART(HOUR,'{timpselectat.Hour.ToString("D2")}:00'))) ORDER BY Data_Timp").ToList();
                     // "Data Source=192.168.100.55,1433;Network Library=DBMSSOCN;Initial Catalog=Siemens_PLC;User ID=siemens;Password=siemens;"




                     return output;
                 }
             }
             public List<DateDB> GetDateIntervalOrar(DateTime DataSetata1, DateTime DataSetata2, DateTime timpselectat1, DateTime timpselectat2)
             {

                 using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
                 {

                     var output = connection.Query<DateDB>($"select * from Linia_2 WHERE ((Data_Timp BETWEEN '{DataSetata1}' AND '{DataSetata2}') AND (DATEPART(HOUR,Data_Timp) BETWEEN DATEPART(HOUR,'{timpselectat1.Hour.ToString("D2")}:00') AND DATEPART(HOUR,'{timpselectat2.Hour.ToString("D2")}:00'))) ORDER BY Data_Timp").ToList();
                     // "Data Source=192.168.100.55,1433;Network Library=DBMSSOCN;Initial Catalog=Siemens_PLC;User ID=siemens;Password=siemens;"




                     return output;
                 }
             }*/


        /*    public double? SumData1(DateTime DataSetata1, DateTime DataSetata2)
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
                {

                    var output_sum = connection.Query($"select SUM(Cantitate_Descarcata_Snec_1) As Suma from Linia_2 WHERE Data_Timp BETWEEN '{DataSetata1}' AND '{DataSetata2}' ORDER BY Data_Timp ").SingleOrDefault();




                    return output_sum.Suma;
                }
            }*/


        /*  public void InsertDate(float Data1, float Data2, float Data3, DateTime DataTimp)
          {
              using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
              {
                  //Person newPerson = new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber };
                  List<DateDB> Date_Ins = new List<DateDB>();

                  Date_Ins.Add(new DateDB { Data1 = Data1, Data2 = Data2, Data3 = Data3, DataTimp = DataTimp });

                  //connection.Execute("dbo.People_Insert @Data1, @Data2, @Data3, @DataTimp", Date_Ins);
                  connection.Execute($"INSERT INTO Date values ({Data1},{Data2},{Data3},convert(datetime,18-10-21))");
              }
          }*/
    }
}
