using Dapper;
using Microsoft.Extensions.Configuration;
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
        
        public SqlDataAccess()
        {
            
        }
        private string connection(string id = "DefaultConnection")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
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
