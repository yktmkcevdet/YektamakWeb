namespace ApiService
{
    public interface IWebMethods
    {
        public Task<string> GetAsyncMethod(string apiAdres);
        public string Get(string apiAdres);
        public Task<string> GetMenu();
    }
}
