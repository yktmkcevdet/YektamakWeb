using Models;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Reflection.Metadata;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Data.Common;

namespace Api.DatabaseJobs
{
    public static class DataBaseJobsSatisTahsilatPlan
    {
        public static string GetTahsilatPlanDesign(int siparisId)
        {
            string commandText = "spGetTahsilatPlanData";
            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            SqlCommand command = new SqlCommand(commandText, connection);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter parameter = new SqlParameter("@siparisId", SqlDbType.Int);
                parameter.Value = siparisId;
                command.Parameters.Add(parameter);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);

                return DataBaseJobsGeneral.SerializeObject(dataSet);
            } 
            catch (Exception ex)
            {
                return "Error 1: Database error :" + ex.Message;
            }
            finally
            {
                connection.Close();
            }
        }
        public static string GetTahsilatPlaniBySiparisId(int siparisId)
        {
            string commandText = "spGetTahsilatPlaniBySiparisId";
            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            SqlCommand command = new SqlCommand(commandText, connection);
            command.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter parameter = new SqlParameter("@siparisId", SqlDbType.Int);
                parameter.Value = siparisId;
                command.Parameters.Add(parameter);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                return DataBaseJobsGeneral.SerializeObject(dataSet);
            }   
            catch (Exception ex)
            {
                return "Error 1: Veritabanı hatası :" + ex.Message;
            }
            finally
            {
                connection.Close();
            }
        }
        public static string SaveTahsilatPlani(TahsilatPlani tahsilatPlani)
        {
            string returnMessage = "";
            string sqlCommandText = "spSaveTahsilatPlani";
            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(sqlCommandText, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                SqlParameter parameter0 = new SqlParameter("@tahsilatPlaniId", SqlDbType.Int);
                parameter0.Direction = ParameterDirection.Input;
                parameter0.Value = tahsilatPlani.tahsilatPlaniId;
                sqlCommand.Parameters.Add(parameter0);

                SqlParameter parameter1 = new SqlParameter("@siparisId", SqlDbType.Int);
                parameter1.Direction = ParameterDirection.Input;
                parameter1.Value = tahsilatPlani.siparisId;
                sqlCommand.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter("@kdvDahilMi", SqlDbType.Bit);
                parameter2.Direction = ParameterDirection.Input;
                parameter2.Value = tahsilatPlani.kdvDahilMi;
                sqlCommand.Parameters.Add(parameter2);

                SqlParameter parameter3 = new SqlParameter("@aciklamalar", SqlDbType.NVarChar,500);
                parameter3.Direction = ParameterDirection.Input;
                parameter3.Value = tahsilatPlani.aciklamalar;
                sqlCommand.Parameters.Add(parameter3);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet dataSet= new DataSet();
                sqlDataAdapter.Fill(dataSet);
                
                returnMessage= DataBaseJobsGeneral.SerializeObject(dataSet);

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
        public static string UpdatePlanOdeme(List<PlanOdeme> planOdemeList)
        {
            string returnMessage = "";
            string sqlCommandText = "spSavePlanOdeme";
            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(sqlCommandText, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                DataTable planOdemeTable = new DataTable();
                planOdemeTable.Columns.Add("planOdemeId", typeof(int));
                planOdemeTable.Columns.Add("KDVMi", typeof(bool));
                planOdemeTable.Columns.Add("kalanMiktar", typeof(decimal));
                planOdemeTable.Columns.Add("gerceklesmeTarihi", typeof(DateTime));
                planOdemeTable.Columns.Add("odemeOrani", typeof(int));
                planOdemeTable.Columns.Add("odemeSekli", typeof(int));
                planOdemeTable.Columns.Add("odenenMiktar", typeof(decimal));
                planOdemeTable.Columns.Add("projeSafhaId", typeof(int));
                planOdemeTable.Columns.Add("tahsilatGerceklestiMi", typeof(bool));
                planOdemeTable.Columns.Add("vade", typeof(int));
                planOdemeTable.Columns.Add("tahsilatPlaniId", typeof(int));
                foreach (PlanOdeme planOdeme in planOdemeList)
                {
                    DataRow row = planOdemeTable.NewRow();
                    row["planOdemeId"] = planOdeme.planOdemeId;
                    row["KDVMi"] = planOdeme.KDVMi;
                    row["kalanMiktar"] = planOdeme.kalanMiktar;
                    row["gerceklesmeTarihi"] = planOdeme.gerceklesmeTarihi;
                    row["odemeOrani"] = planOdeme.odemeOrani;
                    row["odemeSekli"] = (int)Convert.ChangeType(planOdeme.odemeSekli, typeof(int));
                    row["odenenMiktar"] = planOdeme.odenenMiktar;
                    row["projeSafhaId"] = planOdeme.projeSafhaId;
                    row["tahsilatGerceklestiMi"] = planOdeme.tahsilatGerceklestiMi;
                    row["vade"] = planOdeme.vade;
                    row["tahsilatPlaniId"] = planOdeme.tahsilatPlaniId;
                    planOdemeTable.Rows.Add(row);
                }
               
                SqlParameter parameter = new SqlParameter("@planOdemeTable", SqlDbType.Structured);
                parameter.Direction = ParameterDirection.Input;
                parameter.Value = planOdemeTable;
                sqlCommand.Parameters.Add(parameter);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);

                returnMessage=DataBaseJobsGeneral.SerializeObject(dataSet);
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
        public static string GetPlanOdemeBySiparisId(int siparisId)
        {
            string commandText = "spGetPlanOdemeBySiparisId";
            SqlConnection connection = DataBaseJobsGeneral.GetConnection();
            SqlCommand sqlCommand = new SqlCommand(commandText, connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                string returnMessage = "";
                

                SqlParameter parameter = new SqlParameter("@siparisId", SqlDbType.Int);
                parameter.Value= siparisId;
                parameter.Direction=ParameterDirection.Input;
                sqlCommand.Parameters.Add (parameter);

                SqlDataAdapter sqlDataAdapter=new SqlDataAdapter(sqlCommand);
                DataSet dataSet=new DataSet();
                sqlDataAdapter.Fill(dataSet);

                returnMessage = DataBaseJobsGeneral.SerializeObject(dataSet);
                
                return returnMessage;
            }
            catch (Exception ex)
            {
                return "Error 1: Database erro : " + ex.Message;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
