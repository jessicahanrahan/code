using System;
using code.core;
using code.features.catalog_browsing;
using code.matching.extended;
using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using StructureMap.Configuration.DSL;

namespace code.db
{
  public class DatabaseRegistry : Registry
  {
    public DatabaseRegistry()
    {
      ForSingletonOf<ISessionFactory>().Use(() => Fluently.Configure()
        .Mappings(create_mapping_configuration())
        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(c =>
          c.FromConnectionStringWithKey("code")))
        .BuildSessionFactory());
    }

    Action<FluentNHibernate.Cfg.MappingConfiguration> create_mapping_configuration()
    {
      return mappings =>
      {
        mappings.FluentMappings.AddFromAssemblyOf<Department>();

        mappings.AutoMappings.Add(AutoMap.AssemblyOf<Department>(
          new MappingConfiguration()));
      };
    }

    class MappingConfiguration : DefaultAutomappingConfiguration
    {
      public override bool ShouldMap(Type type)
      {
        return Matches.a<Type>().is_class().and(x => x.is_assignable_from<ICanBePersisted>())
          .matches(type);
      }

      public override bool IsId(Member member)
      {
        return member.Name == "id";
      }
    }
  }
}