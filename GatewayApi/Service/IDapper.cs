using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace GatewayApi.Service
{
    public interface IDapper : IDisposable
    {
        DbConnection GetDbconnection();
        T Get<T>(long id) where T : class;
        Task<List<T>> GetAll<T>(string sp, object parms = null, CommandType commandType = CommandType.Text);
        int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
        Task<int> Insert<T>(T model) where T : class;
        Task<bool> Update<T>(T model) where T : class;
    }
}
