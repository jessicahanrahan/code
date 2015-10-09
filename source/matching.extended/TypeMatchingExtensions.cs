using System;
using System.Linq;

namespace code.matching.extended
{
  public static class TypeMatchingExtensions
  {
    public static MatchingExtensionPoint<Type> is_class(this MatchingExtensionPoint<Type> extension)
    {
      return MatchingExtensionPoint<Type>.create_from(x => x.IsClass);
    }

    public static MatchingExtensionPoint<Type> is_assignable_from<Target>(this MatchingExtensionPoint<Type> extension)
    {
      return MatchingExtensionPoint<Type>.create_from(x => typeof(Target).IsAssignableFrom(x));
    }

    public static MatchingExtensionPoint<Type> is_assignable_from(this MatchingExtensionPoint<Type> extension, Type type)
    {
      return MatchingExtensionPoint<Type>.create_from(x => x.GetGenericArguments().Any() &&
             x.GetGenericTypeDefinition().IsAssignableFrom(type));
    }

    public static MatchingExtensionPoint<Type> implements_generic_contract(this MatchingExtensionPoint<Type> extension,
      Type type)
    {
      return MatchingExtensionPoint<Type>.create_from(x =>
        x.GetInterfaces().Any(extension.is_assignable_from(type).matches));
    }

    public static MatchingExtensionPoint<Type> has_property(
      this MatchingExtensionPoint<Type> extension, string name)
    {
      return MatchingExtensionPoint<Type>.create_from(x =>x.GetProperty(name) != null);
    }

    public static MatchingExtensionPoint<Type> implements_generic_contract<Target>(
      this MatchingExtensionPoint<Type> extension)
    {
      return extension.implements_generic_contract(typeof(Target));
    }
  }
}