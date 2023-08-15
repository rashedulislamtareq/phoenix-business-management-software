using System.Data.Common;
using System.Data;
using Dapper;

namespace Phoenix.BusinessManagement.Repository.Core
{
    public interface IDapperContext : IDisposable
    {
        DbConnection GetDbconnection();
        T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<T> GetBySingleParamAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        Task<IEnumerable<dynamic>> GetReportData(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);

        Task<IEnumerable<T>> GetAllAsync<T>(string sp, CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<T>> GetAllAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<(T, List<TT>)> GetAsyncMultiple<T, TT>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<(T, List<TT>, List<TTT>)> GetAsyncMultiple<T, TT, TTT>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<(T, List<TT>, List<TTT>, List<TTTT>)> GetAsyncMultiple<T, TT, TTT, TTTT>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<IEnumerable<T>> GetDropdownList<T>(string sp);
        Task<object> Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        Task<int> ExecuteAsync<T>(string sp, T entity);
        T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure);
        T Delete<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.Text);
    }
}
