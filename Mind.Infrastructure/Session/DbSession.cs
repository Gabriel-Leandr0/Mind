using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Mind.Infrastructure.Session
{
public class DbSession : IDisposable
    {
        IConfiguration _configuracao;

        public DbSession(IConfiguration configuration, IConfiguration configuracao)
        {
            _configuracao = configuracao;
            Connection = new SqlConnection(configuration.GetConnectionString("MindConnection"));
        }

        public IDbConnection Connection
        {
            get { return this.Connection = new SqlConnection(_configuracao.GetConnectionString("MindConnection"));}
            set { }
        }

        public void Dispose() => Connection?.Dispose();

    }
}