
namespace ApiControllers.Data
{
    public interface IDbDataAccess
    {
        Task<IEnumerable<T>> GetDataAsync<T, P>(string storedProcedure, P parameters, string connection = "default");
        Task SaveDataAsync<T>(string storedProcedure, T parameters, string connection = "default");
        Task<IEnumerable<T>> GetDataForeignAsync<T, U, V, P>(string storedProcedure, P parameters, Func<T, U, V, T>? map = null, 
                                                             string connection = "default",
                                                             string splitOn = "Id");
    }
}