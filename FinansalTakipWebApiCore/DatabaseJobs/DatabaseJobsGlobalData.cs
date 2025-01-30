using System.Data.SqlClient;
using System.Data;
using Api.Business;

namespace Api.DatabaseJobs
{
    public static class DatabaseJobsGlobalData
    {
        public static string GetGlobalData()
        {
            return DataAccessLayer.dataAccesLayer.GetObject("spGetGlobalData");
            string commandText = "spGetGlobalData";
            string returnMessage = "";

            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
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
