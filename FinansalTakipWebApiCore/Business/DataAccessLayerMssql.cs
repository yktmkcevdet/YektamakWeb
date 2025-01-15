using FinansalTakipWebApiCore.DatabaseJobs;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Data.SqlTypes;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Collections;
using Npgsql;
using NpgsqlTypes;
using MySql.Data.MySqlClient;
using System.Data.Common;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace FinansalTakipWebApiCore.Business
{
    public class DataAccessLayerMssql:IDataAccesLayer
	{
		/// <summary>
		/// Verilen nesne modelinin içindeki verileri verilen sql komutu ile veritabanına kayıt eder.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="model"></param>
		/// <param name="sqlCommandName"></param>
		/// <returns></returns>
		public string SaveObject<T>(T model, string sqlCommandName) where T : class
		{
			SqlConnection conn = DataBaseJobsGeneral.GetConnection();
			SqlCommand cmd=new SqlCommand(sqlCommandName, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			try
			{
				AddParameters(model, cmd, "");

				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				string returnValue = DataBaseJobsGeneral.SerializeObject(dataSet);
				return returnValue;
			}
			catch (Exception ex)
			{
				return "error 1 : veritabanı hatası " + ex.Message;
			}
			finally
			{
				conn.Close();
			}
		}
		/// <summary>
		/// Verilen sql komutuna gönderilen filtre nesnesine göre dönen verileri json string olarak verir.
		/// </summary>
		/// <typeparam name="T">Filtre parametrelerini içeren nesne tipi</typeparam>
		/// <param name="model">Filtre parametrelerini içeren nesne adı</param>
		/// <param name="sqlCommandName">Sql komut nesnesi, genelde bir stored procedure'dür.</param>
		/// <returns></returns>
		public string GetObject<T>(T model, string sqlCommandName) where T : class
		{
            SqlConnection conn = DataBaseJobsGeneral.GetConnection();
			SqlCommand cmd = new SqlCommand(sqlCommandName, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			try
			{
				AddParameters(model, cmd, "");

				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				string returnValue = DataBaseJobsGeneral.SerializeObject(dataSet);
				return returnValue;
			}
			catch (Exception ex)
			{
				return "error 1 : veritabanı hatası " + ex.Message;
			}
			finally
			{
				conn.Close();
			}
		}
		/// <summary>
		/// Verilen sql komutundan dönen verileri json string olarak verir.
		/// </summary>
		/// <param name="sqlCommandName">Sql komut nesnesi, genelde bir stored procedure'dür.</param>
		/// <returns></returns>
		public string GetObject(string sqlCommandName)
		{
			SqlConnection conn = DataBaseJobsGeneral.GetConnection();
			SqlCommand cmd = new SqlCommand(sqlCommandName, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			try
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				string returnValue = DataBaseJobsGeneral.SerializeObject(dataSet);
				return returnValue;
			}
			catch (Exception ex)
			{
				return "error 1 : veritabanı hatası " + ex.Message;
			}
			finally
			{
				conn.Close();
			}
		}
		public string DeleteObject<T>(T model, string sqlCommandName) where T : class
		{
			SqlConnection conn = DataBaseJobsGeneral.GetConnection();
			SqlCommand cmd = new SqlCommand(sqlCommandName, conn);
			cmd.CommandType = CommandType.StoredProcedure;
			try
			{
				AddParameters(model, cmd, "");

				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
				DataSet dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
				return "Silme işlemi başarılı";
			}
			catch (Exception ex)
			{
				return "error 1 : veritabanı hatası " + ex.Message;
			}
			finally
			{
				conn.Close();
			}
		}
		/// <summary>
		/// Sotored procedure'ün parametrelerini veritabanından alarak liste şeklinde verir.
		/// </summary>
		/// <param name="cmd">Parametreleri alınacak SqlCommand nesnesi</param>
		public void GetStoredProcedureParameters(SqlCommand cmd)
		{
			SqlCommandBuilder.DeriveParameters(cmd);
			List<SqlParameter> parameters = new List<SqlParameter>();
			foreach (SqlParameter parameter in cmd.Parameters)
			{
				SqlParameter sqlParameter = new SqlParameter();
				sqlParameter.ParameterName = parameter.ParameterName;
				sqlParameter.SqlDbType = parameter.SqlDbType;
				sqlParameter.Direction = parameter.Direction;
				if (parameter.SqlDbType == SqlDbType.NVarChar)
				{
					sqlParameter.Size = parameter.Size;
				}
				parameters.Add(sqlParameter);
			}
		}
		/// <summary>
		/// Stored procedure'un parametrelerinin değerleri, verilen modeldeki değerlere göre atanır.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="model">Parametre değerlerinin alınacağı veri modeli nesnesi</param>
		/// <param name="cmd">Parametrelerin ekleneceği stored procedure adı</param>
		/// <param name="parameterPrefix">Eğer model içinde model varsa üst model adı önek olarak parametreye eklenir.</param>
		public void AddParameters<T>(T model,  SqlCommand cmd,string parameterPrefix) where T : class
		{
			if (model == null) return;
			if (cmd.Parameters.Count == 0)
			{
				GetStoredProcedureParameters(cmd);
			}
			var memberList = model.GetType().GetMembers().Where(x => x.MemberType == MemberTypes.Property || x.MemberType == MemberTypes.Field).ToList();
			foreach (var member in memberList)
			{
				object field;
				string nnn=member.Name;
				if(member is FieldInfo fieldInfo)
				{
					field = fieldInfo.GetValue(model);

                }
				else if(member is PropertyInfo propertyInfo)
				{
					field = propertyInfo.GetValue(model);
				}
				else
				{
					field = null;
				}
				if (field != null && field.GetType().IsClass && field.GetType() != typeof(string) && field.GetType() != typeof(byte[]))
				{
					if (field.GetType().Name.Contains("List", StringComparison.OrdinalIgnoreCase))
					{
						//object value = field;
						if (field is IEnumerable enumerable)
						{
							List<object> list = new List<object>();
							foreach (var item in enumerable)
							{
								list.Add(item);
							}
                            Type listType = field.GetType();
                            Type itemType = listType.GetGenericArguments()[0];
                            DataTable dataTable = ListToDataTable(list, itemType);
							foreach (SqlParameter parameter in cmd.Parameters)
							{
								string parameterName = member.Name;
								if (parameter.ParameterName.Substring(1, parameter.ParameterName.Length - 1).Equals(parameterName, StringComparison.OrdinalIgnoreCase))
								{
									if (parameter.Value == null || parameter.Value.ToString() == "0" || parameter.Value.ToString() == "")
									{
										cmd.Parameters.RemoveAt(parameter.ParameterName);
										parameter.ParameterName = parameterName;
										parameter.Value = dataTable;
										parameter.TypeName = "[dbo]." + parameterName;
										cmd.Parameters.Add(parameter);
									}
									break;
								}
							}
						}
					}
					else
					{
						AddParameters(field, cmd, parameterPrefix+member.Name);//memberInfo class tipinde ise terkrar döngüye gir
					}
				}
				foreach (SqlParameter parameter in cmd.Parameters)
				{
					string namem= member.Name;	
					string parameterName = parameterPrefix + member.Name;
					if (parameter.ParameterName.Substring(1, parameter.ParameterName.Length - 1).Equals(parameterName, StringComparison.OrdinalIgnoreCase))
					{
						if (parameter.Value == null || parameter.Value.ToString() == "0" || parameter.Value.ToString() == "")
						{
							cmd.Parameters.RemoveAt(parameter.ParameterName);
							parameter.ParameterName = parameterName;
							parameter.Value = field;
							cmd.Parameters.Add(parameter);
						}
						break;
					}
				}
			}
			

		}
        /// <summary>
        /// Liste şeklinde olan veri kümesini datatable nesnesine dönüştürür.
        /// </summary>
        /// <typeparam name="T">Dönüştürülecek nesne modeli.</typeparam>
        /// <param name="list">Datatable nesnesine dönüştürülecek veri listesi</param>
        /// <param name="sampleObject">Nesne modelinin elemanlarının okunabilmesi için listenin birinci elemanı nesne örneği olarak verilir.</param>
        /// <returns></returns>
        public DataTable ListToDataTable<T>(List<T> list, Type type) where T : class
        {
			DataTable table = new DataTable();
			//Eğer liste verisi değer tipinde ise(int,string gibi tek sütunlu değerler barındırıyorsa)
			if (type.IsValueType)
			{
                table.Columns.Add("Value");
                foreach (T item in list)
                {
                    DataRow row = table.NewRow();
                    row["Value"] = item;
                    table.Rows.Add(row);
                }
            }
			//Eğer liste verisi sınıf türünde değerler içeren liste ise
			else
			{
            foreach (MemberInfo memberInfo in type.GetMembers())
            {
					if (memberInfo.MemberType == MemberTypes.Field || memberInfo.MemberType == MemberTypes.Property)
					{
						Type columnType = ((FieldInfo)memberInfo).FieldType;
						table.Columns.Add(memberInfo.Name, columnType);
					}
				}
                foreach (T item in list)
                {
                    if (item == null) continue;
                    DataRow row = table.NewRow();
                    foreach (DataColumn column in table.Columns)
                    {
                        FieldInfo fieldInfo = item.GetType().GetField(column.ColumnName);
                        if (fieldInfo != null)
                        {
                            object value = fieldInfo.GetValue(item);
                            row[column.ColumnName] = Convert.ChangeType(value,fieldInfo.FieldType) ?? DBNull.Value;
                        }
                    }

                    table.Rows.Add(row);
                }
            }
			return table;
		}
    }
    public class DataAccessLayerPostgresql : IDataAccesLayer
    {
        /// <summary>
        /// Verilen nesne modelinin içindeki verileri verilen sql komutu ile veritabanına kayıt eder.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="sqlCommandName"></param>
        /// <returns></returns>
        public string SaveObject<T>(T model, string sqlCommandName) where T : class
        {
            NpgsqlConnection conn = DataBaseJobsGeneral.PostgreSqlConnection();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                AddParametersPostgresql(model, cmd, "");

                NpgsqlDataAdapter sqlDataAdapter = new NpgsqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                string returnValue = DataBaseJobsGeneral.SerializeObject(dataSet);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "error 1 : veritabanı hatası " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// Verilen sql komutuna gönderilen filtre nesnesine göre dönen verileri json string olarak verir.
        /// </summary>
        /// <typeparam name="T">Filtre parametrelerini içeren nesne tipi</typeparam>
        /// <param name="model">Filtre parametrelerini içeren nesne adı</param>
        /// <param name="sqlCommandName">Sql komut nesnesi, genelde bir stored procedure'dür.</param>
        /// <returns></returns>
        public string GetObject<T>(T model, string sqlCommandName) where T : class
        {
            NpgsqlConnection conn = DataBaseJobsGeneral.PostgreSqlConnection();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.Text;
            try
            {
                AddParametersPostgresql(model, cmd, "");
                List<NpgsqlParameter> parameters = GetFunctionParameters(conn, sqlCommandName);

                cmd.CommandText= $"SELECT * FROM {sqlCommandName}({string.Join(", ", parameters.ConvertAll(p => "@" + p.ParameterName))})";

                NpgsqlDataAdapter sqlDataAdapter = new NpgsqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                string returnValue = DataBaseJobsGeneral.SerializeObject(dataSet);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "error 1 : veritabanı hatası " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// Verilen sql komutundan dönen verileri json string olarak verir.
        /// </summary>
        /// <param name="sqlCommandName">Sql komut nesnesi, genelde bir stored procedure'dür.</param>
        /// <returns></returns>
        public string GetObject(string sqlCommandName)
        {
            NpgsqlConnection conn = DataBaseJobsGeneral.PostgreSqlConnection();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                NpgsqlDataAdapter sqlDataAdapter = new NpgsqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                string returnValue = DataBaseJobsGeneral.SerializeObject(dataSet);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "error 1 : veritabanı hatası " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        public string DeleteObject<T>(T model, string sqlCommandName) where T : class
        {
            NpgsqlConnection conn = DataBaseJobsGeneral.PostgreSqlConnection();
            NpgsqlCommand cmd = new NpgsqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                AddParametersPostgresql(model, cmd, "");

                NpgsqlDataAdapter sqlDataAdapter = new NpgsqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                return "Silme işlemi başarılı";
            }
            catch (Exception ex)
            {
                return "error 1 : veritabanı hatası " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// Sotored procedure'ün parametrelerini veritabanından alarak liste şeklinde verir.
        /// </summary>
        /// <param name="cmd">Parametreleri alınacak SqlCommand nesnesi</param>
        public void GetStoredProcedureParameters(SqlCommand cmd)
        {
            SqlCommandBuilder.DeriveParameters(cmd);
            List<SqlParameter> parameters = new List<SqlParameter>();
            foreach (SqlParameter parameter in cmd.Parameters)
            {
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = parameter.ParameterName;
                sqlParameter.SqlDbType = parameter.SqlDbType;
                sqlParameter.Direction = parameter.Direction;
                if (parameter.SqlDbType == SqlDbType.NVarChar)
                {
                    sqlParameter.Size = parameter.Size;
                }
                parameters.Add(sqlParameter);
            }
        }
        /// <summary>
        /// Sotored procedure'ün parametrelerini veritabanından alarak liste şeklinde verir.
        /// </summary>
        /// <param name="cmd">Parametreleri alınacak SqlCommand nesnesi</param>
        public void GetStoredProcedureParametersPostgresql(NpgsqlCommand cmd)
        {
            List<NpgsqlParameter> parameters = GetFunctionParameters(DataBaseJobsGeneral.PostgreSqlConnection(), cmd.CommandText);

            // inputParameters listesindeki parametreleri cmd.Parameters'a ekle
            foreach (var inputParam in parameters)
            {
                cmd.Parameters.Add(inputParam);
            }
        }
        /// <summary>
        /// Stored procedure'un parametrelerinin değerleri, verilen modeldeki değerlere göre atanır.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">Parametre değerlerinin alınacağı veri modeli nesnesi</param>
        /// <param name="cmd">Parametrelerin ekleneceği stored procedure adı</param>
        /// <param name="parameterPrefix">Eğer model içinde model varsa üst model adı önek olarak parametreye eklenir.</param>
        public void AddParameters<T>(T model, SqlCommand cmd, string parameterPrefix) where T : class
        {
            if (model == null) return;
            if (cmd.Parameters.Count == 0)
            {
                GetStoredProcedureParameters(cmd);
            }
            var memberList = model.GetType().GetMembers().Where(x => x.MemberType == MemberTypes.Property || x.MemberType == MemberTypes.Field).ToList();
            foreach (var member in memberList)
            {
                object field;
                string nnn = member.Name;
                if (member is FieldInfo fieldInfo)
                {
                    field = fieldInfo.GetValue(model);

                }
                else if (member is PropertyInfo propertyInfo)
                {
                    field = propertyInfo.GetValue(model);
                }
                else
                {
                    field = null;
                }
                if (field != null && field.GetType().IsClass && field.GetType() != typeof(string) && field.GetType() != typeof(byte[]))
                {
                    if (field.GetType().Name.Contains("List", StringComparison.OrdinalIgnoreCase))
                    {
                        //object value = field;
                        if (field is IEnumerable enumerable)
                        {
                            List<object> list = new List<object>();
                            foreach (var item in enumerable)
                            {
                                list.Add(item);
                            }
                            Type listType = field.GetType();
                            Type itemType = listType.GetGenericArguments()[0];
                            DataTable dataTable = ListToDataTable(list, itemType);
                            foreach (SqlParameter parameter in cmd.Parameters)
                            {
                                string parameterName = member.Name;
                                if (parameter.ParameterName.Substring(1, parameter.ParameterName.Length - 1).Equals(parameterName, StringComparison.OrdinalIgnoreCase))
                                {
                                    if (parameter.Value == null || parameter.Value.ToString() == "0" || parameter.Value.ToString() == "")
                                    {
                                        cmd.Parameters.RemoveAt(parameter.ParameterName);
                                        parameter.ParameterName = parameterName;
                                        parameter.Value = dataTable;
                                        parameter.TypeName = "[dbo]." + parameterName;
                                        cmd.Parameters.Add(parameter);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        AddParameters(field, cmd, parameterPrefix + member.Name);//memberInfo class tipinde ise terkrar döngüye gir
                    }
                }
                foreach (SqlParameter parameter in cmd.Parameters)
                {
                    string namem = member.Name;
                    string parameterName = parameterPrefix + member.Name;
                    if (parameter.ParameterName.Substring(1, parameter.ParameterName.Length - 1).Equals(parameterName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (parameter.Value == null || parameter.Value.ToString() == "0" || parameter.Value.ToString() == "")
                        {
                            cmd.Parameters.RemoveAt(parameter.ParameterName);
                            parameter.ParameterName = parameterName;
                            parameter.Value = field;
                            cmd.Parameters.Add(parameter);
                        }
                        break;
                    }
                }
            }


        }
        /// <summary>
        /// Stored procedure'un parametrelerinin değerleri, verilen modeldeki değerlere göre atanır.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">Parametre değerlerinin alınacağı veri modeli nesnesi</param>
        /// <param name="cmd">Parametrelerin ekleneceği stored procedure adı</param>
        /// <param name="parameterPrefix">Eğer model içinde model varsa üst model adı önek olarak parametreye eklenir.</param>
        public void AddParametersPostgresql<T>(T model, NpgsqlCommand cmd, string parameterPrefix) where T : class
        {
            if (model == null) return;
            if (cmd.Parameters.Count == 0)
            {
                GetStoredProcedureParametersPostgresql(cmd);
            }
            var memberList = model.GetType().GetMembers().Where(x => x.MemberType == MemberTypes.Property || x.MemberType == MemberTypes.Field).ToList();
            foreach (var member in memberList)
            {
                object field;
                string nnn = member.Name;
                if (member is FieldInfo fieldInfo)
                {
                    field = fieldInfo.GetValue(model);

                }
                else if (member is PropertyInfo propertyInfo)
                {
                    field = propertyInfo.GetValue(model);
                }
                else
                {
                    field = null;
                }
                if (field != null && field.GetType().IsClass && field.GetType() != typeof(string) && field.GetType() != typeof(byte[]))
                {
                    if (field.GetType().Name.Contains("List", StringComparison.OrdinalIgnoreCase))
                    {
                        //object value = field;
                        if (field is IEnumerable enumerable)
                        {
                            List<object> list = new List<object>();
                            foreach (var item in enumerable)
                            {
                                list.Add(item);
                            }
                            Type listType = field.GetType();
                            Type itemType = listType.GetGenericArguments()[0];
                            DataTable dataTable = ListToDataTable(list, itemType);
                            foreach (NpgsqlParameter parameter in cmd.Parameters)
                            {
                                string parameterName = member.Name;
                                if (parameter.ParameterName.Substring(0, parameter.ParameterName.Length - 0).Equals(parameterName, StringComparison.OrdinalIgnoreCase))
                                {
                                    if (parameter.Value == null || parameter.Value.ToString() == "0" || parameter.Value.ToString() == "")
                                    {
                                        cmd.Parameters.RemoveAt(parameter.ParameterName);
                                        parameter.ParameterName = parameterName;
                                        parameter.Value = dataTable;
                                        parameter.DataTypeName = "public." + parameterName;
                                        cmd.Parameters.Add(parameter);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        AddParametersPostgresql(field, cmd, parameterPrefix + member.Name);//memberInfo class tipinde ise terkrar döngüye gir
                    }
                }
                foreach (NpgsqlParameter parameter in cmd.Parameters)
                {
                    string namem = member.Name;
                    string parameterName = parameterPrefix + member.Name;
                    if (parameter.ParameterName.Substring(0, parameter.ParameterName.Length - 0).Equals(parameterName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (parameter.Value == null || parameter.Value.ToString() == "0" || parameter.Value.ToString() == "")
                        {
                            cmd.Parameters.RemoveAt(parameter.ParameterName);
                            parameter.ParameterName = parameterName;
                            parameter.Value = field;
                            cmd.Parameters.Add(parameter);
                        }
                        break;
                    }
                }
            }


        }
        /// <summary>
        /// Liste şeklinde olan veri kümesini datatable nesnesine dönüştürür.
        /// </summary>
        /// <typeparam name="T">Dönüştürülecek nesne modeli.</typeparam>
        /// <param name="list">Datatable nesnesine dönüştürülecek veri listesi</param>
        /// <param name="sampleObject">Nesne modelinin elemanlarının okunabilmesi için listenin birinci elemanı nesne örneği olarak verilir.</param>
        /// <returns></returns>
        public DataTable ListToDataTable<T>(List<T> list, Type type) where T : class
        {
            DataTable table = new DataTable();
            //Eğer liste verisi değer tipinde ise(int,string gibi tek sütunlu değerler barındırıyorsa)
            if (type.IsValueType)
            {
                table.Columns.Add("Value");
                foreach (T item in list)
                {
                    DataRow row = table.NewRow();
                    row["Value"] = item;
                    table.Rows.Add(row);
                }
            }
            //Eğer liste verisi sınıf türünde değerler içeren liste ise
            else
            {
                foreach (MemberInfo memberInfo in type.GetMembers())
                {
                    if (memberInfo.MemberType == MemberTypes.Field || memberInfo.MemberType == MemberTypes.Property)
                    {
                        Type columnType = ((FieldInfo)memberInfo).FieldType;
                        table.Columns.Add(memberInfo.Name, columnType);
                    }
                }
                foreach (T item in list)
                {
                    if (item == null) continue;
                    DataRow row = table.NewRow();
                    foreach (DataColumn column in table.Columns)
                    {
                        FieldInfo fieldInfo = item.GetType().GetField(column.ColumnName);
                        if (fieldInfo != null)
                        {
                            object value = fieldInfo.GetValue(item);
                            row[column.ColumnName] = Convert.ChangeType(value, fieldInfo.FieldType) ?? DBNull.Value;
                        }
                    }

                    table.Rows.Add(row);
                }
            }
            return table;
        }
        static List<NpgsqlParameter> GetFunctionParameters(NpgsqlConnection conn, string functionName)
        {
            var parameters = new List<NpgsqlParameter>();

            string query = @"
            SELECT parameter_name, data_type
            FROM information_schema.parameters
            WHERE specific_name LIKE @functionName || '%' AND parameter_mode='IN'
            ORDER BY ordinal_position;";

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@functionName", functionName.ToLower());

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string paramName = reader.GetString(0);
                        string dataType = reader.GetString(1);

                        NpgsqlParameter parameter = new NpgsqlParameter(paramName, GetNpgsqlDbType(dataType));
                        parameters.Add(parameter);
                    }
                }
            }

            return parameters;
        }

        static NpgsqlTypes.NpgsqlDbType GetNpgsqlDbType(string dataType)
        {
            switch (dataType.ToLower())
            {
                case "bigint":
                    return NpgsqlTypes.NpgsqlDbType.Integer;
                case "character varying":
                    return NpgsqlTypes.NpgsqlDbType.Varchar;
                case "boolean":
                    return NpgsqlTypes.NpgsqlDbType.Boolean;
                // Diğer veri tiplerini ekleyin
                default:
                    throw new NotSupportedException($"Unsupported data type: {dataType}");
            }
        }
    }
    public class DataAccesLayerMySql:IDataAccesLayer
    {
        /// <summary>
		/// Verilen nesne modelinin içindeki verileri verilen sql komutu ile veritabanına kayıt eder.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="model"></param>
		/// <param name="sqlCommandName"></param>
		/// <returns></returns>
		public string SaveObject<T>(T model, string sqlCommandName) where T : class
        {
            MySqlConnection conn = DataBaseJobsGeneral.MySqlConnection();
            MySqlCommand cmd = new MySqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                AddParameters(model, cmd, "");

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                string returnValue = DataBaseJobsGeneral.SerializeObject(dataSet);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "error 1 : veritabanı hatası " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// Verilen sql komutuna gönderilen filtre nesnesine göre dönen verileri json string olarak verir.
        /// </summary>
        /// <typeparam name="T">Filtre parametrelerini içeren nesne tipi</typeparam>
        /// <param name="model">Filtre parametrelerini içeren nesne adı</param>
        /// <param name="sqlCommandName">Sql komut nesnesi, genelde bir stored procedure'dür.</param>
        /// <returns></returns>
        public string GetObject<T>(T model, string sqlCommandName) where T : class
        {
            MySqlConnection conn = DataBaseJobsGeneral.MySqlConnection();
            MySqlCommand cmd = new MySqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                AddParameters(model, cmd, "");

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                string returnValue = DataBaseJobsGeneral.SerializeObject(dataSet);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "error 1 : veritabanı hatası " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// Verilen sql komutundan dönen verileri json string olarak verir.
        /// </summary>
        /// <param name="sqlCommandName">Sql komut nesnesi, genelde bir stored procedure'dür.</param>
        /// <returns></returns>
        public string GetObject(string sqlCommandName)
        {
            MySqlConnection conn = DataBaseJobsGeneral.MySqlConnection();
            MySqlCommand cmd = new MySqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                GetStoredProcedureParameters(cmd);
                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                string returnValue = DataBaseJobsGeneral.SerializeObject(dataSet);
                return returnValue;
            }
            catch (Exception ex)
            {
                return "error 1 : veritabanı hatası " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        public string DeleteObject<T>(T model, string sqlCommandName) where T : class
        {
            MySqlConnection conn = DataBaseJobsGeneral.MySqlConnection();
            MySqlCommand cmd = new MySqlCommand(sqlCommandName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                AddParameters(model, cmd, "");

                MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                return "Silme işlemi başarılı";
            }
            catch (Exception ex)
            {
                return "error 1 : veritabanı hatası " + ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// Sotored procedure'ün parametrelerini veritabanından alarak liste şeklinde verir.
        /// </summary>
        /// <param name="cmd">Parametreleri alınacak SqlCommand nesnesi</param>
        public void GetStoredProcedureParameters(MySqlCommand cmd)
        {
            MySqlCommandBuilder.DeriveParameters(cmd);
            List<MySqlParameter> parameters = new List<MySqlParameter>();
            foreach (MySqlParameter parameter in cmd.Parameters)
            {
                MySqlParameter sqlParameter = new MySqlParameter();
                sqlParameter.ParameterName = parameter.ParameterName;
                sqlParameter.MySqlDbType = parameter.MySqlDbType;
                sqlParameter.Direction = parameter.Direction;
                if (parameter.MySqlDbType == MySqlDbType.VarChar)
                {
                    sqlParameter.Size = parameter.Size;
                }
                parameters.Add(sqlParameter);
            }
        }
        /// <summary>
        /// Stored procedure'un parametrelerinin değerleri, verilen modeldeki değerlere göre atanır.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">Parametre değerlerinin alınacağı veri modeli nesnesi</param>
        /// <param name="cmd">Parametrelerin ekleneceği stored procedure adı</param>
        /// <param name="parameterPrefix">Eğer model içinde model varsa üst model adı önek olarak parametreye eklenir.</param>
        public void AddParameters<T>(T model, MySqlCommand cmd, string parameterPrefix) where T : class
        {
            if (model == null) return;
            if (cmd.Parameters.Count == 0)
            {
                if(cmd is DbCommand)
                {
                    GetStoredProcedureParameters(cmd);
                };
            }
            var memberList = model.GetType().GetMembers().Where(x => x.MemberType == MemberTypes.Property || x.MemberType == MemberTypes.Field).ToList();
            
            
            foreach (var member in memberList)
            {
                object field;
                string nnn = member.Name;
                if (member is FieldInfo fieldInfo)
                {
                    field = fieldInfo.GetValue(model);

                }
                else if (member is PropertyInfo propertyInfo)
                {
                    field = propertyInfo.GetValue(model);
                }
                else
                {
                    field = null;
                }
                if (field != null && field.GetType().IsClass && field.GetType() != typeof(string) && field.GetType() != typeof(byte[]))
                {
                    if (field.GetType().Name.Contains("List", StringComparison.OrdinalIgnoreCase))
                    {
                        //object value = field;
                        if (field is IEnumerable enumerable)
                        {
                            List<object> list = new List<object>();
                            foreach (var item in enumerable)
                            {
                                list.Add(item);
                            }
                            Type listType = field.GetType();
                            Type itemType = listType.GetGenericArguments()[0];
                            string jsonList = ListToJson(list, itemType);
                            foreach (MySqlParameter parameter in cmd.Parameters)
                            {
                                string parameterName = member.Name;
                                if (parameter.ParameterName.Substring(1, parameter.ParameterName.Length - 1).Equals(parameterName, StringComparison.OrdinalIgnoreCase))
                                {
                                    if (parameter.Value == null || parameter.Value.ToString() == "0" || parameter.Value.ToString() == "")
                                    {
                                        cmd.Parameters.RemoveAt(parameter.ParameterName);
                                        parameter.ParameterName = parameterName;
                                        parameter.Value = jsonList;
                                        //parameter.TypeName = "[dbo]." + parameterName;
                                        cmd.Parameters.Add(parameter);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        AddParameters(field, cmd, parameterPrefix + member.Name);//memberInfo class tipinde ise terkrar döngüye gir
                    }
                }
                foreach (MySqlParameter parameter in cmd.Parameters)
                {
                    string namem = member.Name;
                    string parameterName = parameterPrefix + member.Name;
                    if (parameter.ParameterName.Substring(1, parameter.ParameterName.Length - 1).Equals(parameterName, StringComparison.OrdinalIgnoreCase))
                    {
                        if (parameter.Value == null || parameter.Value.ToString() == "0" || parameter.Value.ToString() == "")
                        {
                            cmd.Parameters.RemoveAt(parameter.ParameterName);
                            parameter.ParameterName = parameterName;
                            parameter.Value = field;
                            cmd.Parameters.Add(parameter);
                        }
                        break;
                    }
                }
            }


        }
        /// <summary>
        /// Liste şeklinde olan veri kümesini datatable nesnesine dönüştürür.
        /// </summary>
        /// <typeparam name="T">Dönüştürülecek nesne modeli.</typeparam>
        /// <param name="list">Datatable nesnesine dönüştürülecek veri listesi</param>
        /// <param name="sampleObject">Nesne modelinin elemanlarının okunabilmesi için listenin birinci elemanı nesne örneği olarak verilir.</param>
        /// <returns></returns>
        public DataTable ListToDataTable<T>(List<T> list, Type type) where T : class
        {
            DataTable table = new DataTable();
            //Eğer liste verisi değer tipinde ise(int,string gibi tek sütunlu değerler barındırıyorsa)
            if (type.IsValueType)
            {
                table.Columns.Add("Value");
                foreach (T item in list)
                {
                    DataRow row = table.NewRow();
                    row["Value"] = item;
                    table.Rows.Add(row);
                }
            }
            //Eğer liste verisi sınıf türünde değerler içeren liste ise
            else
            {
                foreach (MemberInfo memberInfo in type.GetMembers())
                {
                    if (memberInfo.MemberType == MemberTypes.Field || memberInfo.MemberType == MemberTypes.Property)
                    {
                        Type columnType = ((FieldInfo)memberInfo).FieldType;
                        table.Columns.Add(memberInfo.Name, columnType);
                    }
                }
                foreach (T item in list)
                {
                    if (item == null) continue;
                    DataRow row = table.NewRow();
                    foreach (DataColumn column in table.Columns)
                    {
                        FieldInfo fieldInfo = item.GetType().GetField(column.ColumnName);
                        if (fieldInfo != null)
                        {
                            object value = fieldInfo.GetValue(item);
                            row[column.ColumnName] = Convert.ChangeType(value, fieldInfo.FieldType) ?? DBNull.Value;
                        }
                    }

                    table.Rows.Add(row);
                }
            }
            return table;
        }
        public string ListToJson<T>(List<T> list, Type type) where T : class
        {
            if (list == null || list.Count == 0)
                return "[]"; // Boş bir JSON dizisi döner

            // Eğer liste verisi değer tipinde ise (int, string gibi)
            if (type.IsValueType || type == typeof(string))
            {
                var simpleList = list.Select(item => new { Value = item }).ToList();
                return JsonConvert.SerializeObject(simpleList); // Newtonsoft.Json kullanıyorsanız JsonConvert.SerializeObject
            }
            // Eğer liste sınıf türünde değerler içeriyorsa
            else
            {
                // Listeyi doğrudan JSON'a dönüştür
                return JsonConvert.SerializeObject(list); // Newtonsoft.Json alternatifi: JsonConvert.SerializeObject
            }
        }

    }

}
