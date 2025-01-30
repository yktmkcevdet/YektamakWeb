using Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace Api.DatabaseJobs
{
    public partial class DataBaseJobsMarka
    {
        public static string GetAllMarkaAndAltGrup()
        {
            string commandText = "spGetAllMarkaAndAltGrup";
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
        public static string GetAllMarka()
        {
            string commandText = "spGetAllMarka";
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
