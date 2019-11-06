using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace Kiemtra.model
{
    class Model
    {
        private const string DatabaseName = "khaiho.db";

        private static Model _instance;
        public SQLiteConnection Connection { get; }

        public static Model GetIntances()
        {
            if (_instance == null)
            {
                _instance = new Model();
            }
            return _instance;
        }

        private Model
            ()
        {
            Connection = new SQLiteConnection(DatabaseName);
            CreateTables();
        }

        private void CreateTables()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS Customer (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,Name VARCHAR( 140 ),PhoneNumber VARCHAR( 140 ));";
            using (var statement = Connection.Prepare(sql))
            {
                statement.Step();
            }
            sql = @"CREATE TABLE IF NOT EXISTS Student (Id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,Name VARCHAR( 140 ));";
            using (var statement = Connection.Prepare(sql))
            {
                statement.Step();
            }
        }

        public void InsertDemo()
        {
            try
            {
                using (var custstmt = Connection.Prepare("INSERT INTO Customer (Name, PhoneNumber) VALUES (?, ?)"))
                {
                    custstmt.Bind(1, "Tung");
                    custstmt.Bind(2, "091777777");
                    custstmt.Step();
                }

            }
            catch (Exception ex)
            {
                // TODO: Handle error}

            }
        }
    }
}
