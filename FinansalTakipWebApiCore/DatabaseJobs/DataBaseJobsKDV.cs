using Models;
using System.Data.SqlClient;
using System.Data;
namespace FinansalTakipWebApiCore.DatabaseJobs
{
    public static partial class DataBaseJobsKDV
    {
        public static string GetAllKDV()
        {
            string commandText = "spGetAllKDV";
            string returnMessage;

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