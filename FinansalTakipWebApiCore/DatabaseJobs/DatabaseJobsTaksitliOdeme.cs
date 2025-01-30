using Models;
using System.Data.SqlClient;
using System.Data;

namespace Api.DatabaseJobs
{
    public static class DatabaseJobsTaksitliOdeme
    {
        public static string SaveTakstiliOdeme(TaksitliOdeme taksitliOdeme,List<TaksitOdemesi> taksitOdemesiList)
        {
            string returnMessage = "";
            string sqlCommandText = "spSaveTaksitliOdeme";
            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(sqlCommandText, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                SqlParameter parameter0 = new SqlParameter("@taksitliOdemeId", SqlDbType.Int);
                parameter0.Direction = ParameterDirection.Input;
                parameter0.Value = taksitliOdeme.taksitliOdemeId;
                sqlCommand.Parameters.Add(parameter0);

                SqlParameter parameter1 = new SqlParameter("@cariId", SqlDbType.Int);
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = taksitliOdeme.cari.cariKartId;
                sqlCommand.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter("@toplamTutar", SqlDbType.Float);
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = taksitliOdeme.toplamTutar.tutar;
                sqlCommand.Parameters.Add(parameter2);

                SqlParameter parameter3 = new SqlParameter("@dovizId", SqlDbType.Int, 0);
                parameter3.Direction = ParameterDirection.Input;
                parameter3.Value = taksitliOdeme.toplamTutar.dovizCinsi.id;
                sqlCommand.Parameters.Add(parameter3);

                SqlParameter parameter4 = new SqlParameter("@taksitliOdemeTuruId", SqlDbType.Int, 0);
                parameter4.Direction = ParameterDirection.Input;
                parameter4.Value = taksitliOdeme.taksitliOdemeTuru;
                sqlCommand.Parameters.Add(parameter4);

                SqlParameter parameter5 = new SqlParameter("@odemeTanimi", SqlDbType.NVarChar, 150);
                parameter5.Direction = ParameterDirection.Input;
                parameter5.Value = taksitliOdeme.odemeTanimi;
                sqlCommand.Parameters.Add(parameter5);

                SqlParameter parameter6 = new SqlParameter("@islemTarihi", SqlDbType.DateTime2, 0);
                parameter6.Direction = ParameterDirection.Input;
                parameter6.Value = taksitliOdeme.islemTarihi;
                sqlCommand.Parameters.Add(parameter6);

                DataTable taksitOdemesiTable = new DataTable();
                taksitOdemesiTable.Columns.Add("taksitliOdemeId", typeof(int));
                taksitOdemesiTable.Columns.Add("TaksitNo", typeof(int));
                taksitOdemesiTable.Columns.Add("Tutar", typeof(decimal));
                taksitOdemesiTable.Columns.Add("DovizId", typeof(int));
                taksitOdemesiTable.Columns.Add("SonOdemeTarihi", typeof(DateTime));
                foreach (TaksitOdemesi taksitOdemesi in taksitOdemesiList)
                {
                    DataRow row = taksitOdemesiTable.NewRow();
                    row["taksitliOdemeId"] = taksitOdemesi.taksitliOdemeId;
                    row["TaksitNo"] = taksitOdemesi.taksitNo;
                    row["Tutar"] = taksitOdemesi.tutar.tutar;
                    row["DovizId"] = taksitOdemesi.tutar.dovizCinsi.id;                    
                    row["SonOdemeTarihi"] = taksitOdemesi.sonOdemeTarihi;
                    taksitOdemesiTable.Rows.Add(row);
                }
                SqlParameter parameter7 = new SqlParameter("@TaksitOdemesi", SqlDbType.Structured);
                parameter7.Direction = ParameterDirection.Input;
                parameter7.Value = taksitOdemesiTable;
                parameter7.TypeName = "[dbo].[TaksitOdemesi]";
                sqlCommand.Parameters.Add(parameter7);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sqlDataAdapter.Dispose();
                sqlCommand.Dispose();
                returnMessage = DataBaseJobsGeneral.SerializeObject(dataSet);


            }
            catch (Exception ex)
            {
                return "Error 1: Database error :" + ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return returnMessage;
        }
        public static string GetFilteredTakstiliOdeme(TaksitliOdemeFiltre taksitliOdemeFiltre)
        {
            string returnMessage = "";
            string sqlCommandText = "spGetFilteredTaksitliOdeme";
            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(sqlCommandText, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter parameter0 = new SqlParameter("@taksitliOdemeId", SqlDbType.Int);
                parameter0.Direction = ParameterDirection.Input;
                parameter0.Value = taksitliOdemeFiltre.taksitliOdemeId;
                sqlCommand.Parameters.Add(parameter0);

                SqlParameter parameter1 = new SqlParameter("@cariId", SqlDbType.Int);
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = taksitliOdemeFiltre.cari.cariKartId;
                sqlCommand.Parameters.Add(parameter1);

                //SqlParameter parameter2 = new SqlParameter("@toplamTutar", SqlDbType.Float);
                //parameter2.Direction = ParameterDirection.Input;
                //parameter2.Value = taksitliOdemeFiltre.toplamTutar.tutar;
                //sqlCommand.Parameters.Add(parameter2);

                SqlParameter parameter3 = new SqlParameter("@dovizId", SqlDbType.Int, 0);
                parameter3.Direction = ParameterDirection.Input;
                parameter3.Value = taksitliOdemeFiltre.toplamTutar.dovizCinsi.id;
                sqlCommand.Parameters.Add(parameter3);

                SqlParameter parameter4 = new SqlParameter("@BaslangicIslemTarihi", SqlDbType.DateTime2, 0);
                parameter4.Direction = ParameterDirection.Input;
                parameter4.Value = taksitliOdemeFiltre.baslangicIslemTarihi;
                sqlCommand.Parameters.Add(parameter4);

                SqlParameter parameter5 = new SqlParameter("@BitisIslemTarihi", SqlDbType.DateTime2, 0);
                parameter5.Direction = ParameterDirection.Input;
                parameter5.Value = taksitliOdemeFiltre.bitisIslemTarihi;
                sqlCommand.Parameters.Add(parameter5);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);

                returnMessage = DataBaseJobsGeneral.SerializeObject(dataSet);

            }
            catch (Exception ex)
            {
                returnMessage = "Error 1: Database error :" + ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return returnMessage;
        }
        public static string GetTaksitOdemesiByTaksitliOdemeId(int taksitliOdemeId)
        {
            string returnMessage = "";
            string sqlCommandText = "spGetTaksitOdemesiByTaksitliOdemeId";
            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(sqlCommandText, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter parameter0 = new SqlParameter("@taksitliOdemeId", SqlDbType.Int);
                parameter0.Direction = ParameterDirection.Input;
                parameter0.Value = taksitliOdemeId;
                sqlCommand.Parameters.Add(parameter0);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);

                returnMessage = DataBaseJobsGeneral.SerializeObject(dataSet);

            }
            catch (Exception ex)
            {
                returnMessage = "Error 1: Database error :" + ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return returnMessage;
        }
        public static string DeleteTakstiliOdeme(int taksitliOdemeId)
        {
            string returnMessage = "";
            string sqlCommandText = "spDeleteTaksitliOdeme";
            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(sqlCommandText, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter parameter0 = new SqlParameter("@taksitliOdemeId", SqlDbType.Int);
                parameter0.Direction = ParameterDirection.Input;
                parameter0.Value = taksitliOdemeId;
                sqlCommand.Parameters.Add(parameter0);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);

                returnMessage = DataBaseJobsGeneral.SerializeObject(dataSet);

            }
            catch (Exception ex)
            {
                returnMessage = "Error 1: Database error :" + ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return returnMessage;
        }
    }
}
