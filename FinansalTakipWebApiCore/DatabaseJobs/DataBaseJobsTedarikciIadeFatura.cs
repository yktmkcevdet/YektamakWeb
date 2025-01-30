using Models;
using System.Data;
using System.Data.SqlClient;

namespace Api.DatabaseJobs
{
    public static class DataBaseJobsTedarikciIadeFatura
    {
        public static string GetFilteredTedarikciIadeFatura(TedarikciIadeFatura tedarikciIadeFatura)
        {
            string returnMessage = "";
            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            SqlCommand command = new SqlCommand("spGetFilteredTedarikciIadeFatura",connection);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter parameter0 = new SqlParameter("@TedarikciIadeFaturaNo", SqlDbType.NVarChar, 100);
                parameter0.Value = tedarikciIadeFatura.tedarikciIadeFaturaNo;
                command.Parameters.Add(parameter0);

                SqlParameter parameter2 = new SqlParameter("@TedarikciIadeFaturaTarihi", SqlDbType.DateTime2);
                parameter2.Value = tedarikciIadeFatura.tedarikciIadeFaturaTarihi;
                command.Parameters.Add(parameter2);

                SqlParameter parameter3 = new SqlParameter("@ProjeKod", SqlDbType.NVarChar,100);
                parameter3.Value = tedarikciIadeFatura.projeKod.kod;
                command.Parameters.Add(parameter3);

                SqlParameter parameter4 = new SqlParameter("@CariAdi", SqlDbType.NVarChar, 150);
                parameter4.Value = tedarikciIadeFatura.cariKart.cariAdi;
                command.Parameters.Add(parameter4);

                SqlParameter parameter5 = new SqlParameter("@tedarikciIadeFaturaId", SqlDbType.NVarChar, 150);
                parameter5.Value = tedarikciIadeFatura.tedarikciIadeFaturaId;
                command.Parameters.Add(parameter5);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                returnMessage = DataBaseJobsGeneral.SerializeObject(ds);
            }
            catch (Exception ex)
            {
                returnMessage = "error 1: Database error : " + ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return returnMessage;
        }
        public static string SaveTedarikciIadeFatura(TedarikciIadeFatura tedarikciIadeFatura)
        {
            string returnMessage = "";
            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            SqlCommand command = new SqlCommand("spSaveTedarikciIadeFatura",connection);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter parameter = new SqlParameter("@TedarikciIadeFaturaId", SqlDbType.Int);
                parameter.Value = tedarikciIadeFatura.tedarikciIadeFaturaId;
                command.Parameters.Add(parameter);

                SqlParameter parameter0 = new SqlParameter("@TedarikciIadeFaturaNo", SqlDbType.NVarChar, 50);
                parameter0.Value = tedarikciIadeFatura.tedarikciIadeFaturaNo;
                command.Parameters.Add(parameter0);

                SqlParameter parameter2 = new SqlParameter("@ProjeKodId", SqlDbType.Int);
                parameter2.Value = tedarikciIadeFatura.projeKod.Id;
                command.Parameters.Add(parameter2);

                SqlParameter parameter3 = new SqlParameter("@CariKartId", SqlDbType.Int);
                parameter3.Value = tedarikciIadeFatura.cariKart.cariKartId;
                command.Parameters.Add(parameter3);

                SqlParameter parameter4 = new SqlParameter("@TedarikciIadeFaturaTarihi", SqlDbType.DateTime2);
                parameter4.Value = tedarikciIadeFatura.tedarikciIadeFaturaTarihi;
                command.Parameters.Add(parameter4);

                SqlParameter parameter5 = new SqlParameter("@FaturaTutari", SqlDbType.Float);
                parameter5.Value = tedarikciIadeFatura.tedarikciIadeFaturaTutari.tutar;
                command.Parameters.Add(parameter5);

                SqlParameter parameter6 = new SqlParameter("@DovizBirimId", SqlDbType.Int);
                parameter6.Value = tedarikciIadeFatura.tedarikciIadeFaturaTutari.dovizCinsi.id;
                command.Parameters.Add(parameter6);

                SqlParameter parameter7 = new SqlParameter("@KdvId", SqlDbType.Int);
                parameter7.Value = tedarikciIadeFatura.kdv.kdvId;
                command.Parameters.Add(parameter7);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                returnMessage = DataBaseJobsGeneral.SerializeObject(ds);
            }
            catch (Exception ex)
            {
                returnMessage = "error 1: Database error : " + ex.Message;
            }
            finally { connection.Close(); }
            return returnMessage;
        }
        public static string GetTedarikciIadeFaturaById(int tedarikciIadeFaturaId)
        {
            string returnMessage = "";
            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            SqlCommand command = new SqlCommand("spGetTedarikciIadeFaturaById", connection);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter parameter = new SqlParameter("@TedarikciIadeFaturaId", SqlDbType.Int);
                parameter.Value = tedarikciIadeFaturaId;
                command.Parameters.Add(parameter);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                returnMessage = DataBaseJobsGeneral.SerializeObject(ds);
            }
            catch (Exception ex)
            {
                returnMessage = "error 1: Database error : " + ex.Message;
            }
            finally { connection.Close(); }
            return returnMessage;
        }
        public static string DeleteTedarikciIadeFatura(int tedarikciIadeFaturaId)
        {
            string returnMessage = "";
            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            SqlCommand command = new SqlCommand("spDeleteTedarikciIadeFatura", connection);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter parameter = new SqlParameter("@TedarikciIadeFaturaId", SqlDbType.Int);
                parameter.Value = tedarikciIadeFaturaId;
                command.Parameters.Add(parameter);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                returnMessage = DataBaseJobsGeneral.SerializeObject(ds);
            }
            catch (Exception ex)
            {
                returnMessage = "error 1: Database error : " + ex.Message;
            }
            finally { connection.Close(); }
            return returnMessage;
        }
    }
}
