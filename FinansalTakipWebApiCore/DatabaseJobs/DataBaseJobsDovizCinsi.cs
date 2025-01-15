using Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;


namespace FinansalTakipWebApiCore.DatabaseJobs
{
    public static partial class DataBaseJobsDovizCinsi
    {
        public static string GetAllDovizCinsi()
        {
            string commandText = "spGetAllDovizCinsi";
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