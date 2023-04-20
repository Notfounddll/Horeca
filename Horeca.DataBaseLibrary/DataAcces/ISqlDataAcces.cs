using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.DataAcces
{
    public interface ISqlDataAcces
    {
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task<T> LoadDataSingle<T, U>(string sql, U parameters, string connectionStringName); Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
    }
}
