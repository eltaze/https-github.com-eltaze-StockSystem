using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSystem.Libarary.DataBase
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly Configuration configuration;

        public SqlDataAccess(Configuration configuration)
        {
            this.configuration = configuration;
        }
        private string connection()
        {
            return configuration.ConnectionStrings.ToString();
        }
        public List<T> ReadingData<T, U>(string str, U Parmater)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connection()))
                {
                    List<T> output = conn.Query<T>(str, Parmater, null, true, null, CommandType.StoredProcedure).ToList();
                    return output;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public void Execute<T, U>(string str, U Parameter)
        {
            try
            {
                using (IDbConnection conn = new SqlConnection(connection()))
                {
                    conn.Execute(str, Parameter, null, null, CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
