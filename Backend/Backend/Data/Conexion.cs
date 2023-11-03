namespace Backend.Data
{
    public class Conexion
    {
        public static string sqlCon = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("sqlCon");
    }
}
