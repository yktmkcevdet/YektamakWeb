using Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using Api.Business;


namespace Api.DatabaseJobs
{
    public static partial class DataBaseJobsProjeKod
    {
        public static string GetMaxProjeNo(int markaId)
        {
            string commandText = "spGetMaxProjeNo";
            string returnMessage = "";

            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            try
            {
                SqlParameter parameter1 = new SqlParameter("@markaId", SqlDbType.Int);
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = markaId;
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.Add(parameter1);
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

        public static string SaveProjeKod(Proje projeKod)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject(projeKod, "spCreateProjeKod");
        }

        public static string UnassignedProjeKod()
        {
            return DataAccessLayer.dataAccesLayer.GetObject("spGetAllUnassignedProjeKod");
        }

        public static string GetAllAssignedProjeKod()
        {
            return DataAccessLayer.dataAccesLayer.GetObject("spGetAllAssignedProjeKod");
        }
        public static string GetProjeKodByUserId(Proje proje)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(proje,"spGetProjeKodByUserId");
        }
        public static string GetProje(Proje proje)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(proje, "spGetProje");
        }
        public static string GetProjeKodById(int projeKodID)
        {
            string commandText = "spGetProjeKodById";
            string returnMessage = "";

            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            try
            {
                SqlCommand command = new SqlCommand(commandText, connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter0=new SqlParameter("@projeKodID",SqlDbType.Int);
                parameter0.Value = projeKodID;
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
        public static string GetAllOrderedProjeKod()
        {
            string commandText = "spGetAllOrderedProjeKod";
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