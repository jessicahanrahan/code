using System;
using code.web.aspnet;
using Machine.Specifications;
using spec =
  developwithpassion.specifications.observations.Spec.isolate_with<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.matching.extended
{
  public class TypeMatchingExtensionsSpecs
  {
    public abstract class concern : spec
    {
    }

    public class matchign_for_type_assignability : concern
    {
      It matches_correctly = () =>
      {
        var target = typeof(MyWorker);

        Matches.a<Type>().is_assignable_from<IDoSomethingWith<int>>().matches(target).ShouldBeTrue();
      };
    }

    public interface IDoSomethingWith<Data>
    {
    }

    public class MyWorker : IDoSomethingWith<int>
    {
      public int run()
      {
        throw new NotImplementedException();
      }
    }
  }
}