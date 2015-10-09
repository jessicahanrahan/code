namespace code.core
{
  public class Delegates
  {
    public static ICombineActions combine_actions = (first, second) =>
      new CombinedAction(first, second).run;
  }
}