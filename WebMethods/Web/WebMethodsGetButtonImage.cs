using Models;

namespace Requests
{
    public partial class WebMethods
    {
        public static string GetButtonImage(ButtonImage buttonImage)
        {
            return Post(buttonImage, "GetButtonImage");
        }
    }
}
