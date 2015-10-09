using System;

namespace code.matching.core
{
  public static class DateMatchCreationExtensions
  {
    public static IMatchAn<Item> year_is_between<Item>(
      this IProvideAccessToCreateMatchers<Item, DateTime> extension_point, int start, int end)

    {
      return extension_point.create_from_match(
        Match<DateTime>.attribute(x => x.Year).between(start, end));
    }
  }
}
