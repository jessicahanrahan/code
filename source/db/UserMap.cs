using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace code.db
{
  public class UserMap : ClassMap<User>
  {
    public UserMap()
    {
      Table("users");

      Id(x => x.id).GeneratedBy.UuidHex("D");

      Map(x => x.email_address);

      Map(x => x.password_attributes);

      Map(x => x.user_name).Length(255).Not.Nullable().Unique();

      HasMany(x => x.abilities)
        .KeyColumn("user_id")
        .Not.KeyUpdate()
        .Cascade.AllDeleteOrphan();

    }
  }

  public class User
  {
    public IEnumerable<Ability> abilities;
    public string password_attributes { get; set; }
    public string user_name { get; set; }
    public Guid id { get; set; }
    public string email_address { get; set; }
  }

  public class Ability
  {
  }
}