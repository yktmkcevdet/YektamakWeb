using Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using static Api.Business.DataAccessLayerMssql;
using Api.Business;

namespace Api.DatabaseJobs
{
    public static partial class DataBaseJobsFirma
    {
        public static string GetAllSektors()
        {
            string commandText = "select * FROM[dbo].[Sektor]";
            string returnMessage = "";

            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(commandText, connection);
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

        public static string SaveFirma(Firma firma)
        {
			return DataAccessLayer.dataAccesLayer.SaveObject<Firma>(firma, "spSaveFirma");
        }

        public static string UpdateFirma(Firma firma)
        {
            return DataAccessLayer.dataAccesLayer.SaveObject<Firma>(firma, "spUpdateFirma");
        }
        public static string GetFilteredFirma(Firma firma)
        {
            return DataAccessLayer.dataAccesLayer.GetObject(firma,"spGetFilteredFirma");
		}

        public static string DeleteFirma(Firma firma)
        {
            return DataAccessLayer.dataAccesLayer.DeleteObject<Firma>(firma, "spDeleteFirma");
        }

        public static string GetDetailedFirmaFromFirmaId(Firma firma)
        {
			return DataAccessLayer.dataAccesLayer.GetObject(firma, "spGetDetailedFirmaFromFirmaId");
		}

        public static string GetAllFirmaUnvan()
        {
            string commandText = "spGetAllFirmaUnvan";
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
        public static string GetFirmaById(int firmaId)
        {
            string sqlCommandText = "spGetFirmaByID";
            string returnMessage = "";
            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(sqlCommandText, connection);
            SqlParameter parameter0 = new SqlParameter("@firmaId", SqlDbType.Int);
            try
            {
                parameter0.Value = firmaId;
                connection.Open();
                sqlCommand.Parameters.Add(parameter0);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
                DataSet ds=new DataSet();
                adapter.Fill(ds);
                returnMessage=DataBaseJobsGeneral.SerializeObject(ds);
            }
            catch (Exception ex)
            {
                returnMessage = "Error1 veritabanı hatası : "+ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return returnMessage;
        }
    }
}