using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;


namespace PlasmaFinder.DB
{
    public class PlasmaFinderLocalDB
    {
        private static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(SQLiteConstants.DatabasePath, SQLiteConstants.Flags);
        });

        SQLiteAsyncConnection Database => lazyInitializer.Value;

        private bool isDBInitialized { get; set; } = false;
        private static PlasmaFinderLocalDB instance = null;

        private PlasmaFinderLocalDB()
        {
         //   InitializeAsync().SafeFireAndForget(false);
        }

        private async Task InitializeAsync()
        {
            if (!isDBInitialized)
            {
                //if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(ScannedItems).Name))
                //{
                //    await Database.CreateTablesAsync(CreateFlags.None, typeof(ScannedItems)).ConfigureAwait(false);
                //}

                isDBInitialized = true;
            }
        }

        private static PlasmaFinderLocalDB GetInstance()
        {
            if(instance == null)
            {
                instance = new PlasmaFinderLocalDB();
            }

            return instance;
        }

        public static SQLiteAsyncConnection GetDBInstance()
        {
            return GetInstance().Database;
        }

    }
}
