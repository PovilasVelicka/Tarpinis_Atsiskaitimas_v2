using Dapper;
using System.Data;

namespace StudentInformationSystem.DAL.DataProviders.Dapper.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        private readonly IDbConnection _connection;
        protected IDbConnection Connection { get { return _connection; } }
        protected BaseRepository (IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }

        protected IQueryable<TEntity> Get (string sql, object parametrs = null!, CommandType commandType = CommandType.Text)
        {
            return _connection.Query<TEntity>(sql, parametrs, commandType: commandType).AsQueryable<TEntity>();
        }
        protected SqlMapper.GridReader GetMultiple (string sql, object parametrs = null!, CommandType commandType = CommandType.Text)
        {
            return _connection.QueryMultiple(sql, parametrs, commandType: commandType);
        }

        protected void Execute (string sql, object parametrs = null!, CommandType commandType = CommandType.StoredProcedure)
        {
             _connection.Query<TEntity>(sql, parametrs, commandType: commandType);
        }
    }
}
