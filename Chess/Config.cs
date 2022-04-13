using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class Config
    {
        public static String GetConnection()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsetting.json").Build();
            string ConnectionStr = config.GetConnectionString("ApDbConStr");
            return ConnectionStr;
        }
    }
}
