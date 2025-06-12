using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace OBAFramework.Repository.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        SqlTransaction BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        SqlConnection GetConnection();
        SqlTransaction GetTransaction();
        void SaveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;
        private readonly string _connectionString;

        private SqlTransaction sqlTransaction;
        private SqlConnection sqlConnection;

        public UnitOfWork(IConfiguration configuration, IHostingEnvironment env)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
            sqlConnection = new SqlConnection(_connectionString);
        }

        public SqlTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
                sqlTransaction = sqlConnection.BeginTransaction(isolationLevel);
            }

            return sqlTransaction;
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }

        public SqlTransaction GetTransaction()
        {
            return sqlTransaction;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    sqlTransaction?.Dispose();
                    sqlConnection?.Dispose();
                }

                disposed = true;
            }
        }

        public void SaveChanges()
        {
            try
            {
                sqlTransaction?.Commit();
            }
            catch
            {
                sqlTransaction?.Rollback();
                throw;
            }
            finally
            {
                sqlTransaction?.Dispose();
                sqlTransaction = null;

                if (sqlConnection?.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
        }

        ~UnitOfWork() { Dispose(false); }
    }
}
