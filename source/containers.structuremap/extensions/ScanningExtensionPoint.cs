using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using code.core;
using code.matching.extended;
using code.startup.core;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace code.containers.structuremap.extensions
{
  public class ScanningExtensionPoint
  {
    public IAssemblyScanner scanner { get; set; }

    public static readonly ICheckAConstraint<Type> type_is_convention = Matches.a<Type>().is_class()
      .and(x => x.is_assignable_from<IRegistrationConvention>());

    public static Func<Assembly, IEnumerable<Type>> filter_assembly_types = assembly =>
      startup.steps.Delegates.assembly_type_filter(assembly)(type_is_convention);

    public void apply_all_conventions_in(Assembly assembly)
    {
      var conventions = filter_assembly_types(assembly);

      conventions.each(add_convention);
    }

    public void add_convention(Type convention)
    {
      var convention_method_bound_to_convention = Util.open_method.MakeGenericMethod(convention);
      convention_method_bound_to_convention.Invoke(scanner, null);
    }

    class Util
    {
      class NulloConvention : IRegistrationConvention
      {
        public void Process(Type type, Registry registry)
        {
        }
      }

      internal static MethodInfo open_method = get_open_convention_method();

      static MethodInfo get_open_convention_method()
      {
        Expression<Action<IAssemblyScanner>> method = x => x.Convention<NulloConvention>();
        var inspection_method = ((MethodCallExpression) method.Body).Method;
        var open_generic_method = inspection_method.GetGenericMethodDefinition();
        return open_generic_method;
      }
    }
  }
}