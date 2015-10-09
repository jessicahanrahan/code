using System.Collections.Generic;
using System.Linq;
using code.core.visitors;
using code.startup.steps;
using developwithpassion.specification.adapters.rhino_mocks;
using Machine.Specifications;

namespace code.core
{
  public class VisitorExtensionSpecs
  {
    public abstract class concern : spec
    {
    }

    public class when_visiting_items_using_an_iterator : concern
    {
      Because b = () =>
        Enumerable.Range(1, 10).each(x => items_visited++);

      It processes_each_item_in_the_iterator_using_the_visitor = () =>
        items_visited.ShouldEqual(10);

      static int items_visited;
    }

    public class when_getting_the_max_value_from_a_set_of_numbers : concern
    {
      Establish c = () =>
      {
        items = Enumerable.Range(1, 10);
      };

      Because b = () =>
        result = items.get_the_result_of_processing_all_items(new MaxValue<int>());

      It gets_the_max_value = () =>
        result.ShouldEqual(10);

      static IEnumerable<int> items;
      static int result;
    }

    public class when_getting_the_first_item_that_matches_a_condition : concern
    {
      Establish c = () =>
      {
        items = Enumerable.Range(1, 10);
        visitor = new FirstOrDefault<int>(x => x % 2 == 0);
        decorated = new ConstrainedVisitor<int>(x => x != 2, visitor);
        StartTheApp.run();
      };

      Because b = () =>
        items.each(decorated);

      It get_the_first_item_that_matches_the_constraint = () =>
        visitor.result.ShouldEqual(4);

      static IEnumerable<int> items;
      static IProcessAndMaintainState<int,int> visitor;
      static ConstrainedVisitor<int> decorated;
    }
  }
}
