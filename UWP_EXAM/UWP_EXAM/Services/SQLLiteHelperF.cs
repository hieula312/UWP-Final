using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace UWP_EXAM.Services
{
    public class SQLLiteHelperF
    {
        private static SQLLiteHelperF _instance;

        public SQLiteConnection SQLiteConnection { get; set; }

        private static string DatabaseName = "finalExam.db";

        public static SQLLiteHelperF CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new SQLLiteHelperF();
            }
            return _instance;
        }

        public SQLLiteHelperF()
        {
            SQLiteConnection = new SQLiteConnection(DatabaseName);
            CreateTables();
        }

        private void CreateTables()
        {
            CreateContactTable();
        }

        private void CreateContactTable()
        {
            var sql = @"Create table if not exists Contacts (Id integer primary key AUTOINCREMENT, Name varchar(200), PhoneNumber varchar(50) UNIQUE)";
            using (var statement = SQLiteConnection.Prepare(sql))
            {
                statement.Step();
            }
            Debug.WriteLine("Create DB success");
        }
    }
}
