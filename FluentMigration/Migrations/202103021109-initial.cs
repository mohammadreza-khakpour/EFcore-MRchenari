using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentMigration.Migrations
{
    [Migration(202103021109)]
    public class _202103021109_initial : FluentMigrator.Migration
    {
        public override void Down()
        {
            Delete.ForeignKey("FK_Goods_Category");
            Delete.Table("Goods");
            Delete.Table("GoodCategories");
        }

        public override void Up()
        {
            Create.Table("GoodCategories")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable();

            Create.Table("Goods")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Title").AsString(50).NotNullable()
                .WithColumn("Code").AsString(10).NotNullable()
                .WithColumn("CategoryId").AsInt32().NotNullable()
                .ForeignKey("FK_Goods_Category", "GoodCategories", "Id")
                .OnDelete(System.Data.Rule.Cascade);

            /*Create.ForeignKey("FK_Goods_Category")
                .FromTable("Goods").ForeignColumn("CategoryId")
                .ToTable("GoodCategories").PrimaryColumn("Id");*/
        }
    }
}
