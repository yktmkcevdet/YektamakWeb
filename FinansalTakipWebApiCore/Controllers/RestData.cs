namespace FinansalTakipWebApiCore.Controllers
{
    [Serializable]
    /// <summary>
    /// Desktop-WebApi arasında data transferi için kullanılan byte dizisi içeren sınıf.
    /// Json serialization için byte dizisini bir nesne ile dönüştürmemiz gerekiyor
    /// </summary>    
    public class RestData
    {
        public string byteArrayString;
        public RestData(string data)
        {
            this.byteArrayString = data;
        }
    }
}
