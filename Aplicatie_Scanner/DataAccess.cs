using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aplicatie_Scanner
{
    public class DataAccess
    {
       public List<DateDB> GetDateToataZiua(DateTime DataSetata1, DateTime DataSetata2, String Conditii_Where, String Zona_Selectie)
        {

            try
            { 
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
                {


                    var output = connection.Query<DateDB>($"select * from {Zona_Selectie} {Conditii_Where} ORDER BY Data_Timp").ToList();
                     return output;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error Connecting to the Database ! Error:" + ex.Message);
                return null;
            }
        }

        public async Task<List<DateFurnizori>> GetDateFurnizori()
        {

            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
                {

                    var output = connection.Query<DateFurnizori>($"SELECT Denumire FROM Furnizori ORDER BY Denumire").ToList();
                    return output;
                }

            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public async Task<List<DateCalitate>> GetDateCalitate()
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
                {
                    var output = connection.Query<DateCalitate>($"SELECT Calitate FROM Calitate").ToList();
                    // "Data Source=192.168.100.55,1433;Network Library=DBMSSOCN;Initial Catalog=Siemens_PLC;User ID=siemens;Password=siemens;"
                    return output;
                }
            }
            catch (Exception ex)
            {


                 // MessageBox.Show("Error Connecting to the Database ! Error:" + ex.Message);
                return null;
            }


        }
        public async Task<List<DateLungime>> GetDateLungime()
        {
            try
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("ConnStr")))
                {
                    var output = connection.Query<DateLungime>($"SELECT Lungime FROM Lungimi Order by Lungime").ToList();
                    for (var i = 0; i < output.Count; i++)
                    {
                        output[i].Lungime = Math.Round(output[i].Lungime, 2);
                    }

                    return output;
                }
            }
            catch (Exception ex)
            {


                // MessageBox.Show("Error Connecting to the Database ! Error:" + ex.Message);
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
        internal List<DateDB> GetDate(object text)
        {
            throw new NotImplementedException();
        }

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
