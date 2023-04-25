using Horeca.DataBaseLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Data.Interfaces
{
    public interface IDaHistoryDataService
    {
        public Task InsertSell(HistoryModel newHis);
    }
}
