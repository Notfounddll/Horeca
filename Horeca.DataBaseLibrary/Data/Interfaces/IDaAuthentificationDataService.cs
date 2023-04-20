using Horeca.DataBaseLibrary.Models;
using Horeca.DataBaseLibrary.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Data.Interfaces
{
    public interface IDaAuthentificationDataService
    {
        public Task<AuthentificationModel> SelectAccount(AuthentificationModel selectAccount);
        public Task RegisterAccount(AuthentificationModel newAccount);
        public Task InsertAccount(AuthentificationModel newAccount);
        public Task<AccesToAuthentificationModel> SelectDataAcces(AccesToAuthentificationModel selectDataAcces);
        public Task<List<AuthentificationModel>> ViewAccounts();
        public Task<AuthentificationModel> SelectUserById(int id);
        public Task DeleteUser(AuthentificationModel setInnactive);
    }
}
