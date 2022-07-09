﻿using Dapper;
using System.Data;

namespace StudentInformationSystem.DAL.DataProviders.Dapper.Repositories
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        private readonly IDbConnection _connection;
        protected BaseRepository (IDbConnection dbConnection)
        {
            _connection = dbConnection;
        }

        protected IEnumerable<TEntity> Get (string sql, object parametrs = null!, CommandType commandType = CommandType.Text)
        {
            return _connection.Query<TEntity>(sql, parametrs, commandType: commandType).ToList( );
        }

        protected void Execute (string sql, object parametrs = null!, CommandType commandType = CommandType.StoredProcedure)
        {
            _connection.Query<TEntity>(sql, parametrs, commandType: commandType);
        }
    }
}
