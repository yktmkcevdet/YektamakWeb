using Models;

namespace ApiService
{
    public partial class WebMethods
    {
        public static string GetButtonImage(ButtonImage buttonImage)
        {
            return Post(buttonImage, "GetButtonImage");
        }
    }
}
