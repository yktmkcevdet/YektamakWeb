namespace FinansalTakipWebApiCore.Business
{
    public static class DataAccessLayer
    {
        public static IDataAccesLayer dataAccesLayer = new DataAccesLayerMySql();
    }
}
