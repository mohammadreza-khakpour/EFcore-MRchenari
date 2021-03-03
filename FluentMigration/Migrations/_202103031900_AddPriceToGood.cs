using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentMigration.Migrations
{
    [Migration(202103031900)]
    public class _202103031900_AddPriceToGood : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.Column("Price").FromTable("Goods");
        }

        public override void Up()
        {
            Alter.Table("Goods")
                .AddColumn("Price").AsInt32().NotNullable().WithDefaultValue(0);
            
            
        }
    }
}
