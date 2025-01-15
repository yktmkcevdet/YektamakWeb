using FinansalTakipWebApiCore.Business;
using Models;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace FinansalTakipWebApiCore.DatabaseJobs
{
    public static class DataBaseJobsKrediKarti
    {
        public static string SaveKrediKarti(KrediKarti krediKarti)
        {
            string returnMessage = "";
            int errorCode = 1;
            string sqlCommandText = "spSaveKrediKarti";
            SqlCommand sqlCommand = new SqlCommand(sqlCommandText, DataBaseJobsGeneral.GetConnection());
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            SqlParameter parameter0 = new SqlParameter("krediKartiId", System.Data.SqlDbType.Int, 0);
            parameter0.Direction = System.Data.ParameterDirection.Input;
            parameter0.Value = krediKarti.krediKartiId;
            sqlCommand.Parameters.Add(parameter0);
            SqlParameter parameter1 = new SqlParameter("kartSahibi", System.Data.SqlDbType.NVarChar, 150);
            parameter1.Direction = System.Data.ParameterDirection.Input;
            parameter1.Value = krediKarti.kartSahibi;
            sqlCommand.Parameters.Add(parameter1);
            SqlParameter parameter2 = new SqlParameter("kartNumarasi", System.Data.SqlDbType.NVarChar, 19);
            parameter2.Direction = System.Data.ParameterDirection.Input;
            parameter2.Value = krediKarti.kartNumarasi;
            sqlCommand.Parameters.Add(parameter2);
            SqlParameter parameter3 = new SqlParameter("hesapId", System.Data.SqlDbType.Int, 0);
            parameter3.Direction = System.Data.ParameterDirection.Input;
            parameter3.Value = krediKarti.bagliHesap.hesapId;
            sqlCommand.Parameters.Add(parameter3);
            SqlParameter parameter4 = new SqlParameter("dovizId", System.Data.SqlDbType.Int, 0);
            parameter4.Direction = System.Data.ParameterDirection.Input;
            parameter4.Value = krediKarti.dovizCinsi.id;
            sqlCommand.Parameters.Add(parameter4);
            SqlParameter parameter5 = new SqlParameter("hesapKesimTarihi", System.Data.SqlDbType.DateTime2, 7);
            parameter5.Direction = System.Data.ParameterDirection.Input;
            parameter5.Value = krediKarti.hesapKesimTarihi;
            sqlCommand.Parameters.Add(parameter5);
            SqlParameter parameter6 = new SqlParameter("sonOdemeTarihi", System.Data.SqlDbType.DateTime2, 7);
            parameter6.Direction = System.Data.ParameterDirection.Input;
            parameter6.Value = krediKarti.sonOdemeTarihi;
            sqlCommand.Parameters.Add(parameter6);
            SqlParameter parameter7 = new SqlParameter("kartLimiti", System.Data.SqlDbType.Float, 0);
            parameter7.Direction = System.Data.ParameterDirection.Input;
            parameter7.Value = krediKarti.kartLimiti;
            sqlCommand.Parameters.Add(parameter7);
            SqlParameter parameter8 = new SqlParameter("guncelKartLimiti", System.Data.SqlDbType.Float, 0);
            parameter8.Direction = System.Data.ParameterDirection.Input;
            parameter8.Value = krediKarti.guncelKartLimiti;
            sqlCommand.Parameters.Add(parameter8);
            SqlParameter parameter9 = new SqlParameter("ekstreBorcu", System.Data.SqlDbType.Float, 0);
            parameter9.Direction = System.Data.ParameterDirection.Input;
            parameter9.Value = krediKarti.ekstreBorcu;
            sqlCommand.Parameters.Add(parameter9);
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
            finally
            {
                sqlCommand.Connection.Close();
            }

            return returnMessage;
        }
        public static string GetFilteredKrediKarti(KrediKarti krediKarti)
        {
            return DataAccessLayer.dataAccesLayer.GetObject("spGetFilteredKrediKarti");
        }
        public static string DeleteKrediKarti(KrediKarti krediKarti)
        {
            return DataAccessLayer.dataAccesLayer.DeleteObject(krediKarti, "spDeleteKrediKarti");
        }
    }
}