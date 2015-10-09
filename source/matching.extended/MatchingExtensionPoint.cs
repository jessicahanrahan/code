using System;
using code.core;

namespace code.matching.extended
{
  public class MatchingExtensionPoint<T>
  {
    public static readonly MatchingExtensionPoint<T> always_true = new MatchingExtensionPoint<T>(x => true);
    ICheckAConstraint<T> constraint;

    public MatchingExtensionPoint(ICheckAConstraint<T> constraint)
    {
      this.constraint = constraint;
    }

    public MatchingExtensionPoint<T> not(Func<MatchingExtensionPoint<T>, MatchingExtensionPoint<T>> factory)
    {
      var match = factory(always_true);
      return create_from(x => !match.constraint(x));
    }

    public MatchingExtensionPoint<T> or(ICheckAConstraint<T> other)
    {
      return new MatchingExtensionPoint<T>(x => constraint(x) || other(x));
    }

    public MatchingExtensionPoint<T> and(ICheckAConstraint<T> other)
    {
      return new MatchingExtensionPoint<T>(x => constraint(x) && other(x));
    }

    public MatchingExtensionPoint<T> or(Func<MatchingExtensionPoint<T>, MatchingExtensionPoint<T>> factory)
    {
      var match = factory(always_true);
      return or(match.constraint);
    }

    public MatchingExtensionPoint<T> and(Func<MatchingExtensionPoint<T>, MatchingExtensionPoint<T>> factory)
    {
      var match = factory(always_true);
      return and(match.constraint);
    }

    public static implicit operator ICheckAConstraint<T>(MatchingExtensionPoint<T> extension)
    {
      return extension.constraint;
    }

    public static implicit operator Func<T, bool>(MatchingExtensionPoint<T> extension)
    {
      return extension.constraint.Invoke;
    }

    public static MatchingExtensionPoint<T> create_from(ICheckAConstraint<T> constraint)
    {
      return new MatchingExtensionPoint<T>(constraint);
    }

    public bool matches(T value)
    {
      return constraint(value);
    }
  }
}