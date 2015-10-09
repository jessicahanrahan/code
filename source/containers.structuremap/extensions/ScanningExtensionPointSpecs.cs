using System;
using System.Collections.Generic;
using System.Reflection;
using developwithpassion.specifications.assertions;
using developwithpassion.specifications.observations;
using developwithpassion.specifications.should;
using Machine.Fakes.Adapters.Rhinomocks;
using Machine.Specifications;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace code.containers.structuremap.extensions
{
  [Subject(typeof(ScanningExtensionPoint))]
  public class ScanningExtensionPointSpecs
  {
    public abstract class concern : Spec.isolate_with<RhinoFakeEngine>.observe<ScanningExtensionPoint>
    {
    }

    public class when_applying_all_the_conventions_in_an_assembly : concern
    {
      Establish c = () =>
      {
        assembly = typeof(when_applying_all_the_conventions_in_an_assembly).Assembly;
        scanner = depends.on<IAssemblyScanner>();
        Func<Assembly, IEnumerable<Type>> filter = x =>
        {
          x.ShouldEqual(assembly);
          return new List<Type>
          {
            typeof(MyConvention)
          };
        };

        spec.change(() => ScanningExtensionPoint.filter_assembly_types).to(filter);
      };

      Because b = () =>
        sut.apply_all_conventions_in(assembly);

      It registers_all_of_the_conventions_with_the_assembly_scanner = () =>
        scanner.should().have_received(x => x.Convention<MyConvention>());

      static IAssemblyScanner scanner;
      static Assembly assembly;
    }

    public class MyConvention : IRegistrationConvention
    {
      public void Process(Type type, Registry registry)
      {
      }
    }
  }
}