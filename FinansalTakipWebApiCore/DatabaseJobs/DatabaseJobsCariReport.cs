using System.Data;
using System.Data.SqlClient;

namespace Api.DatabaseJobs
{
    public class DatabaseJobsCariReport
    {
        public static string GetCariHesapEkstresi()
        {
            SqlConnection sqlConnection = DataBaseJobsGeneral.GetConnection();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("spGetCariHareketListesi",sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet ds = new DataSet();
                sqlDataAdapter.Fill(ds);

                string returnValue=DataBaseJobsGeneral.SerializeObject(ds);
                return returnValue;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                sqlConnection.Close();
            }
        }
    }
}
