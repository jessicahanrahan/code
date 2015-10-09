using System;
using System.Linq.Expressions;
using developwithpassion.specification.adapters.rhino_mocks;
using Machine.Specifications;

namespace code.spikes
{
  public class ExpressionsSpike
  {
    public abstract class concern : spec
    {
    }

    public class when_messing_around_with_expression : concern
    {
      It can_create_an_expression_tree_on_the_fly = () =>
      {
        Func<int, bool> even_number = x => x % 2 == 0;

        even_number(2).ShouldBeTrue();

        var number_2 = Expression.Constant(2);

        var zero = Expression.Constant(0);

        Func<int, bool> generated = x =>
        {
            Expression exp = zero.Equals(x.)
            return false;
        };

        generated(2).ShouldBeTrue();
      };
    }
  }
}