using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace FinansalTakipWebApiCore.Business
{
    public interface IDataAccesLayer
    {
        string SaveObject<T>(T model, string sqlCommandName) where T : class;
        string GetObject<T>(T model, string sqlCommandName) where T : class;
        string GetObject(string sqlCommandName);
        string DeleteObject<T>(T model, string sqlCommandName) where T : class;
        //void GetStoredProcedureParameters<T>(T cmd) where T : DbCommand;
        //void AddParameters<T, U>(T model, U cmd, string parameterPrefix) where T : class where U : DbCommand;
        DataTable ListToDataTable<T>(List<T> list, Type type) where T : class;
    }
}
