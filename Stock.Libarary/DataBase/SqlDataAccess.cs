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
    public class SqlDataAccess : ISqlDataAccess ,IDisposable
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
                   // conn.QueryAsync<T>(str, Parmater, null, conn.ConnectionTimeout, CommandType.StoredProcedure).to
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
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool IsClosed = false;
       

        public void starttransaction()
        {
            string connectionstring = connection();
            _connection = new SqlConnection(connectionstring);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            IsClosed = true;
        }
        public void commitrasaction()
        {
            _transaction?.Commit();
            _connection?.Close();
            IsClosed = false;
        }
        public void rollbacktrasaction()
        {
            _transaction?.Rollback();
            _connection?.Close();
            IsClosed = false;
        }
        public  int SaveTrans<T,U>(string storedproc, U parameter)
        {
            int output;
           output= _connection.Execute(storedproc, parameter,
                commandType: CommandType.StoredProcedure, transaction: _transaction);
            return output;
        }
        public void ExecuteTrans<T, U>(string storedproc, U parameter)
        {
            
             _connection.Execute(storedproc, parameter,
                 commandType: CommandType.StoredProcedure, transaction: _transaction);
            
        }
        public List<T> ReadingTrans<T, U>(string storedproc, U parameter)
        {
            List<T> row = _connection.Query<T>
                (storedproc, parameter, commandType: CommandType.StoredProcedure, transaction: _transaction).ToList();
            return row;
        }
        public void Dispose()
        {
            if (IsClosed == true)
            {
                try
                {
                    commitrasaction();
                }
                catch
                {
                }
            }
            _transaction = null;
            _connection = null;
        }
    }
}
