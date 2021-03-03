using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using FluentMigrator;

namespace FluentMigration.Migrations
{
    [Migration(202103031915)]
    public class _202103031915_ExecuteSqlMethod : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Execute.Sql(File.ReadAllText(@"C:\Users\rezaKh\source\repos\EFcore-MRchenari\FluentMigration\acac.sql"));
        }
    }
    // 
}
