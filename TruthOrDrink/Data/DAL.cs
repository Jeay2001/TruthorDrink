using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TruthOrDrink.Data
{
    public static class Constants
    {
        public const string DBFilename = "TruthOrDrink.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;
        public static string DatabasePath
            {
                get
                {
                    return Path.Combine(FileSystem.AppDataDirectory, DBFilename);
                }
            }
    }
}
