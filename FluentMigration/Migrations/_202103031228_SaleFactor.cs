using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentMigration.Migrations
{
    [Migration(202103031228)]
    public class _202103031228_SaleFactor : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Table("SaleFactors");
        }

        public override void Up()
        {

            Create.Table("SaleFactors")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("GoodCode").AsString(10).NotNullable()
                .WithColumn("SalesDate").AsDateTime()
                .WithColumn("GoodCount").AsInt32().NotNullable();
        }
    }
}
