using Models;
using System.Data;
using System.Data.SqlClient;

namespace FinansalTakipWebApiCore.DatabaseJobs
{
    public static class DatabaseJobsTahakkukFisi
    {
        public static string SaveTahakkukFisi(TahakkukFisi tahakkukFisi)
        {
            string returnMessage = "";
            int errorCode = 1;
            string sqlCommandText = "spSaveTahakkukFisi";
            SqlCommand sqlCommand = new SqlCommand(sqlCommandText, DataBaseJobsGeneral.GetConnection());
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter parameter0 = new SqlParameter("@tahakkukFisId", System.Data.SqlDbType.Int, 0);
            parameter0.Direction = System.Data.ParameterDirection.Input;
            parameter0.Value = tahakkukFisi.tahakkukFisId;
            sqlCommand.Parameters.Add(parameter0);
            SqlParameter parameter1 = new SqlParameter("@cariKartId", System.Data.SqlDbType.Int, 0);
            parameter1.Direction = System.Data.ParameterDirection.Input;
            parameter1.Value = tahakkukFisi.cari.cariKartId;
            sqlCommand.Parameters.Add(parameter1);
            SqlParameter parameter2 = new SqlParameter("@tutar", System.Data.SqlDbType.Float, 0);
            parameter2.Direction = System.Data.ParameterDirection.Input;
            parameter2.Value = tahakkukFisi.tutar.tutar;
            sqlCommand.Parameters.Add(parameter2);
            SqlParameter parameter3 = new SqlParameter("@dovizId", System.Data.SqlDbType.Int, 0);
            parameter3.Direction = System.Data.ParameterDirection.Input;
            parameter3.Value = tahakkukFisi.tutar.dovizCinsi.id;
            sqlCommand.Parameters.Add(parameter3);
            SqlParameter parameter4 = new SqlParameter("@tahakkukTarihi", System.Data.SqlDbType.DateTime2, 0);
            parameter4.Direction = System.Data.ParameterDirection.Input;
            parameter4.Value = tahakkukFisi.tahakkukTarihi;
            sqlCommand.Parameters.Add(parameter4);
            SqlParameter parameter5 = new SqlParameter("@vadeTarihi", System.Data.SqlDbType.DateTime2, 0);
            parameter5.Direction = System.Data.ParameterDirection.Input;
            parameter5.Value = tahakkukFisi.vadeTarihi;
            sqlCommand.Parameters.Add(parameter5);
            SqlParameter parameter6 = new SqlParameter("@aciklama", System.Data.SqlDbType.NVarChar, 150);
            parameter6.Direction = System.Data.ParameterDirection.Input;
            parameter6.Value = tahakkukFisi.aciklama;
            sqlCommand.Parameters.Add(parameter6);
            try
            {
                errorCode = 7;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                System.Data.DataSet dataSet = new System.Data.DataSet();
                sqlDataAdapter.Fill(dataSet);
                errorCode = 8;
                returnMessage = "success";
            }
            catch (Exception ex)
            {
                returnMessage = "error" + errorCode + " : Veri tabanı hatası : " + ex.Message;
            }
            finally { sqlCommand.Connection.Close(); }
            return returnMessage;
        }
        public static string GetFilteredTahakkukFisi(TahakkukFisi tahakkukFisi)
        {
            string returnMessage = "";
            int errorCode = 1;
            string sqlCommandText = "spGetFilteredTahakkukFisi";
            SqlCommand sqlCommand = new SqlCommand(sqlCommandText, DataBaseJobsGeneral.GetConnection());
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter parameter0 = new SqlParameter("@tahakkukFisId", System.Data.SqlDbType.Int, 0);
            parameter0.Direction = System.Data.ParameterDirection.Input;
            parameter0.Value = tahakkukFisi.tahakkukFisId;
            sqlCommand.Parameters.Add(parameter0);
            SqlParameter parameter1 = new SqlParameter("@cariAdi", System.Data.SqlDbType.NVarChar, 150);
            parameter1.Direction = System.Data.ParameterDirection.Input;
            parameter1.Value = tahakkukFisi.cari.cariAdi;
            sqlCommand.Parameters.Add(parameter1);
            try
            {
                errorCode = 7;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                System.Data.DataSet dataSet = new System.Data.DataSet();
                sqlDataAdapter.Fill(dataSet);
                errorCode = 8;
                returnMessage = DataBaseJobsGeneral.SerializeObject(dataSet);
            }
            catch (Exception ex)
            {
                returnMessage = "error" + errorCode + " : Veri tabanı hatası : " + ex.Message;
            }
            finally
            {
                sqlCommand.Connection.Close();
            }
            return returnMessage;
        }
        public static string DeleteTahakkukFisi(TahakkukFisi tahakkukFisi)
        {
            string returnMessage = "";
            int errorCode = 1;
            string sqlCommandText = "spDeleteTahakkukFisi";
            SqlCommand sqlCommand = new SqlCommand(sqlCommandText, DataBaseJobsGeneral.GetConnection());
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter parameter0 = new SqlParameter("@tahakkukFisId", System.Data.SqlDbType.Int, 0);
            parameter0.Direction = System.Data.ParameterDirection.Input;
            parameter0.Value = tahakkukFisi.tahakkukFisId;
            sqlCommand.Parameters.Add(parameter0);
            try
            {
                errorCode = 7;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                errorCode = 8;
                returnMessage = "success";
            }
            catch (Exception ex)
            {
                returnMessage = "error" + errorCode + " : Veri tabanı hatası : " + ex.Message;
            }
            finally
            {
                sqlCommand.Connection.Close();
            }
            return returnMessage;
        }
    }
}
