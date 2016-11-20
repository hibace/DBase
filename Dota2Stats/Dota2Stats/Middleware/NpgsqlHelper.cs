using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace Dota2Stats.Middleware
{
    public class NpgsqlHelper
    {
        const string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=213;Database=Dota2Stats";
        public static NpgsqlConnection Connection { get; private set; }

        static NpgsqlHelper()
        {
            Connection = new NpgsqlConnection(connectionString);
        }
    }
}