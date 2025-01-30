namespace Api.Business
{
    public static class DataAccessLayer
    {
        public static IDataAccesLayer dataAccesLayer = new DataAccesLayerMySql();
    }
}
