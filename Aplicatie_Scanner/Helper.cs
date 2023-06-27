using System.Configuration;

namespace Azel_Raportare_Balkani
{

    public static class Helper
    {
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
