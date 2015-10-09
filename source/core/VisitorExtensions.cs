using System.Collections.Generic;
using code.core.visitors;
using code.enumerables;

namespace code.core
{
  public static class VisitorExtensions
  {
    public static void each<Element>(this IEnumerable<Element> items,
      IProcessAn<Element> visitor)
    {
      foreach (var item in items) visitor(item);
    }

    public static void each<Element>(this IEnumerable<Element> items,
      IProcess<Element> visitor)
    {
      items.each(visitor.process);
    }

    public static Result get_the_result_of_processing_all_items<Result, Item>(this IEnumerable<Item> items,
      IProcessAndMaintainState<Item, Result> visitor)
    {
      items.each(visitor);

      return visitor.result;
    }

    public class CombinedVisitor<Item> : IProcess<Item>
    {
      IProcess<Item> first;
      IProcess<Item> second;

      public CombinedVisitor(IProcess<Item> first, IProcess<Item> second)
      {
        this.first = first;
        this.second = second;
      }

      public void process(Item node)
      {
        first.process(node);
        second.process(node);
      }
    }

    public class LoggingVisitor<Item> : IProcess<Item>
    {
      IProcess<Item> original;

      public LoggingVisitor(IProcess<Item> original)
      {
        this.original = original;
      }

      public void process(Item node)
      {
        //log
        original.process(node);
      }
    }

    public static Result get_the_result_of_processing_all_items<Result, Item, Visitor>(this IEnumerable<Item> items)
      where Visitor : IProcessAndMaintainState<Item, Result>, new()
    {
      var visitor = new Visitor();
      return items.get_the_result_of_processing_all_items(visitor);
    }

    public static Item first_or_default<Item>(this IEnumerable<Item> items, Criteria<Item> constraint)
    {
      var visitor = new FirstOrDefault<Item>(constraint);
      return items.get_the_result_of_processing_all_items(visitor);
    }
  }

  public class ConstrainedVisitor<Item> : IProcess<Item>
  {
    Criteria<Item> constraint;
    IProcess<Item> original;

    public ConstrainedVisitor(Criteria<Item> constraint, IProcess<Item> original)
    {
      this.constraint = constraint;
      this.original = original;
    }

    public void process(Item node)
    {
      if (constraint(node))
        original.process(node);
    }

  }
}