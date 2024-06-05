﻿namespace ParcialCesanelli.Datos
{
    public class ConexionDB
    {
        private string cadenaSQL = string.Empty;

        public ConexionDB()
        {


            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;
        }

        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}
