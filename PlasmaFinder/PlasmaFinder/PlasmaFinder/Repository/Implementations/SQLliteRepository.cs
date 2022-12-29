using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using System.Linq;
using Xamarin.Forms.Xaml;
using System;
using PlasmaFinder.Repository.Contracts;
using PlasmaFinder.DB;

namespace PlasmaFinder.Repository.Implementations
{
    public class SQLliteRepository : ISQLliteRepository
    {
        SQLiteAsyncConnection database;
        public SQLliteRepository()
        {
            database = PlasmaFinderLocalDB.GetDBInstance();
        }

        //#region Login Methods
        ////public async Task<bool> LogoutUser()
        ////{
        ////    try
        ////    {
        ////        await database.DropTableAsync<Login>();
        ////        await database.CreateTableAsync<Login>();
        ////        return true;
        ////    }
        ////    catch
        ////    {
        ////        return false;
        ////    }
        ////}

        ////public async Task<bool> LoginUser(Login user)
        ////{
        ////    bool isSuccess = false;

        ////        try
        ////        {
        ////            if (user.Key != 0)
        ////            {
        ////                await database.UpdateAsync(user);
        ////            }
        ////            else
        ////            {
        ////                await database.InsertAsync(user);
        ////            }
        ////            isSuccess = true;
        ////        }
        ////        catch
        ////        {
        ////            isSuccess = false;
        ////        }

        ////    return isSuccess;
        ////}

        ////public async Task<Login> GetLoggedInUser()
        ////{
        ////    return await database.Table<Login>().FirstOrDefaultAsync();
        ////}


        //public async Task<UserData> GetUserData()
        //{
        //    var record = await database.Table<UserData>().ToListAsync();
        //   return record.FirstOrDefault();
        //}

        //public async Task<bool> UpdateDataSyncTimestamp()
        //{
        //    var record = await database.Table<UserData>().ToListAsync();
        //    record.FirstOrDefault().LastLoginDate = DateTime.Now;
        //    await database.UpdateAsync(record.FirstOrDefault());
        //    return true;
        //}

        //public async Task<bool> DeleteUserData()
        //{
        //    try
        //    {
        //        await database.DropTableAsync<UserData>();
        //        await database.CreateTableAsync<UserData>();
        //        return true;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public async Task<bool> SaveUserData(UserData user)
        //{
        //    bool isSaved = true;

        //        try
        //        {
        //            await database.InsertAsync(user);
        //            isSaved = true;
        //        }
        //        catch
        //        {
        //            isSaved = false;
        //        }
            
        //    return isSaved;
        //}

        //public async Task<List<UserPermissions>> GetUserPermissions()
        //{
        //    return await database.Table<UserPermissions>().ToListAsync();
        //}

        //public async Task<bool> DeleteUserPermissions()
        //{
        //    try
        //    {
        //        await database.DropTableAsync<UserPermissions>();
        //        await database.CreateTableAsync<UserPermissions>();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public async Task<bool> SaveUserPermissions(List<UserPermissions> list)
        //{
        //    bool isSaved = true;
        //    foreach (UserPermissions record in list)
        //    {
        //        try
        //        {
        //            await database.InsertAsync(record);
        //            isSaved = true;
        //        }
        //        catch
        //        {
        //            isSaved = false;
        //            break;
        //        }
        //    }
        //    return isSaved;
        //}
        //#endregion

    }
}
