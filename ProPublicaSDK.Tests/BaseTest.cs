using ProPublicaSDK.Interfaces;

namespace ProPublicaSDK.Tests
{
    public class BaseTest
    {
        private const string API_KEY = "YOUR_API_KEY";
        protected const string SENATE = "senate";
        protected const string HOUSE = "house";
        protected const string DEFAULT_CONGRESS = "116";
        protected ProPublica ProPublica;
        public BaseTest()
        {
            if(ProPublica == null)
            {
                ProPublica = new ProPublica(API_KEY);
            }
        }
    }
}
