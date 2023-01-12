using System.ComponentModel.Design;
using FluentMigrator;
using FluentMigrator.Builders;
using FluentMigrator.Expressions;

namespace Mc2.CrudTest.Migrations.Migrations
{
    [Migration(202208202202)]
    public class _202208202202_IntializedDatabase : Migration
    {
        public override void Up()
        {
            CreateCustomersTable();
        }

        public override void Down()
        {
            Delete.UniqueConstraint("CustomerNameAndDateOfBirth")
                .FromTable("Customers");
            Delete.Table("Customers");
        }

        private void CreateCustomersTable()
        {
            Create.Table("Customers")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString().NotNullable()
                .WithColumn("LastName").AsString().NotNullable()
                .WithColumn("DateOfBirth").AsDate().NotNullable()
                .WithColumn("PhoneNumber").AsString(15).NotNullable()
                .WithColumn("Email").AsString(50).NotNullable()
                .WithColumn("BankAccountNumber").AsString(50).NotNullable();

            Create.UniqueConstraint("CustomerNameAndDateOfBirth")
                .OnTable("Customers")
                .Columns("FirstName", "LastName", "DateOfBirth");
        }
    }
}