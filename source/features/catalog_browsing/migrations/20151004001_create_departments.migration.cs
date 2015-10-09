using FluentMigrator;

namespace code.features.catalog_browsing.migrations
{
  [Migration(20150118001)]
  public class CreateDepartments : Migration
  {

    string table_name{
      get{ return "departments"; }
    }

    public override void Up()
    {
      Create.Table(table_name)
        .WithColumn("id").AsGuid().PrimaryKey()
        .WithColumn("name").AsString(255).NotNullable();
    }

    public override void Down()
    {
      Delete.Table(table_name);
    }
  }
}
