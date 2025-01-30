using Models;
using System.Data.SqlClient;
using System.Data;
using static Api.Business.DataAccessLayerMssql;
using Api.Business;

namespace Api.DatabaseJobs
{
    public static class DataBaseJobsSatisProjeSafha
    {
        public static string SaveSatisProjeSafhaList(SatisProje satisProje)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(satisProje, "spSaveSatisProjeSafhaList");
        }
        public static string GetSatisProjeSafhaList(SatisProje satisProje)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(satisProje, "spGetSatisProjeSafhaList");
        }
        public static string DeleteSatisProjeSafha(int projeSafhaId)
        {
            string commandText = "spDeleteSatisProjeSafha";
            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            string returnMessage = "";
            try
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter0 = new SqlParameter("@projeSafhaId", SqlDbType.Int);
                parameter0.Direction = ParameterDirection.Input;
                parameter0.Value = projeSafhaId;
                command.Parameters.Add(parameter0);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                returnMessage = DataBaseJobsGeneral.SerializeObject(ds);
            }
            catch (Exception ex)
            {
                returnMessage = "error1 : Veri tabanı hatası : " + ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return returnMessage;

        }

        public static string GetProjeAsamaTanimlari()
        {
            string commandText = "spProjeAsamaTanimlari";
            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            string returnMessage = "";
            try
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                returnMessage = DataBaseJobsGeneral.SerializeObject(ds);
            }
            catch (Exception ex)
            {
                returnMessage = "error1 : Veri tabanı hatası : " + ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return returnMessage;

        }
    }
}
