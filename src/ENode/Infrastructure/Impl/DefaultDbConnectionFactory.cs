﻿using System.Data;
using System.Data.SqlClient;
using ENode.Infrastructure;

namespace ENode.Messaging {
    public class DefaultDbConnectionFactory : IDbConnectionFactory {
        public IDbConnection CreateConnection(string connectionString) {
            return new SqlConnection(connectionString);
        }
    }
}