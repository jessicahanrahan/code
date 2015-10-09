using System.Linq;
using System;
using FluentMigrator;
using NHibernate.Util;

namespace code.features.catalog_browsing.migrations
{
  class SeedDepartments : Migration
  {
    public override void Up()
    {
      var departments = Enumerable.Range(1, 100).Select(x => new
      {
        name = x.ToString("Main DB Department 0"),
        id = Guid.NewGuid()
      });

      departments.ForEach(x => Insert.IntoTable("departments").Row(x));
    }

    public override void Down()
    {
    }
  }
}