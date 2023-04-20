using Horeca.DataBaseLibrary.Data.Interfaces;
using Horeca.DataBaseLibrary.DataAcces;
using Horeca.DataBaseLibrary.Models;
using Horeca.DataBaseLibrary.Models.CustomModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Horeca.DataBaseLibrary.Data
{
    public class DaAuthentificationDataService : IDaAuthentificationDataService
    {
        private readonly ISqlDataAcces _dataAccess;
        public DaAuthentificationDataService(ISqlDataAcces dataAccess)
        {
            _dataAccess = dataAccess;
        }


        public async Task<AuthentificationModel> SelectAccount(AuthentificationModel selectAccount)
        {
            string sql = $"select * from [HorecaApp].[dbo].[Authentification] " +
            $"where [HorecaApp].[dbo].[Authentification].[Email] = '{selectAccount.Email}' AND" +
            $"[HorecaApp].[dbo].[Authentification].[Password] ='{selectAccount.Password}' ;";
            return await _dataAccess.LoadDataSingle<AuthentificationModel, dynamic>(sql, new { }, "Default");
        }


        public async Task RegisterAccount(AuthentificationModel newAccount)
        {
            string sql = $"insert into [HorecaApp].[dbo].[Authentification] " +
            $"(Id_Acces,Name , Email, Password, Active) " +
            $"values ('2','{newAccount.Email}','{newAccount.Password}','1');";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }
        public async Task InsertAccount(AuthentificationModel employeeAccount)
        {
            string sql = $"insert into [HorecaApp].[dbo].[Authentification] " +
            $"(Id_Acces,Name, Email, Password, Active) " +
            $"values ('1','{employeeAccount.Email}','{employeeAccount.Password}','1');";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }

        public async Task<AccesToAuthentificationModel> SelectDataAcces(AccesToAuthentificationModel selectDataAcces)
        {
            string sql = $"select [HorecaApp].[dbo].[Authentification].[Id], " +
            $"[HorecaApp].[dbo].[Acces].[NameAcces], " +
            $"[HorecaApp].[dbo].[Authentification].[Name], " +
            $"[HorecaApp].[dbo].[Authentification].[Email], " +
            $"[HorecaApp].[dbo].[Authentification].[Password] " +
            $"from [HorecaApp].[dbo].[Authentification] " +
            $"join [HorecaApp].[dbo].[Acces] " +
            $"on [HorecaApp].[dbo].[Acces].[Id] = [HorecaApp].[dbo].[Authentification].[Id_Acces] " +
            $"where [HorecaApp].[dbo].[Authentification].[Email] = '{selectDataAcces.Email}' AND" +
            $"[HorecaApp].[dbo].[Authentification].[Password] ='{selectDataAcces.Password}' ;";
            return await _dataAccess.LoadDataSingle<AccesToAuthentificationModel, dynamic>(sql, new { }, "Default");
        }

        public async Task<List<AuthentificationModel>> ViewAccounts()
        {
            string sql = $"select * from [HorecaApp].[dbo].[Authentification] " +
            $"where [HorecaApp].[dbo].[Authentification].[Active] = 1 ";
            return await _dataAccess.LoadData<AuthentificationModel, dynamic>(sql, new { }, "Default");
        }

        public async Task<AuthentificationModel> SelectUserById(int Id)
        {
            string sql = $"select * from [HorecaApp].[dbo].[Authentification] " +
            $"where [HorecaApp].[dbo].[Authentification].[Id] = '{Id}' ;";
            return await _dataAccess.LoadDataSingle<AuthentificationModel, dynamic>(sql, new { }, "Default");
        }

        public async Task DeleteUser(AuthentificationModel setInnactive)
        {
            string sql = $"update [HorecaApp].[dbo].[Authentification] set " +
            $"[HorecaApp].[dbo].[Authentification].[Active] = '0' " +
            $"where [HorecaApp].[dbo].[Authentification].[Id] = '{setInnactive.Id}';";
            await _dataAccess.SaveData(sql, new { }, "Default");
        }
    }
}
