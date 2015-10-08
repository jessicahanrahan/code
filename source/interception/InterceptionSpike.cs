namespace code.interception
{
  public class InterceptionSpike
  {
    public delegate bool IConstrainAMethod();

    public class ConstrainedMethodInterceptor : IAddBehaviourToAMethod
    {
      IConstrainAMethod constraint;

      public ConstrainedMethodInterceptor(IConstrainAMethod constraint)
      {
        this.constraint = constraint;
      }

      public void apply_to(IInvokeAMethod method)
      {
        if (constraint()) method.proceed();
      }
    }

    public class TimedMethodInterceptor : IAddBehaviourToAMethod
    {
      ITimeStuff timer;

      public TimedMethodInterceptor(ITimeStuff timer)
      {
        this.timer = timer;
      }

      public void apply_to(IInvokeAMethod method)
      {
        timer.start();
        var result = method.proceed();
        timer.end();
      }
    }

    public interface ITimeStuff
    {
      void start();
      void end();
    }

    public interface IAddBehaviourToAMethod
    {
      void apply_to(IInvokeAMethod method);
    }

    public interface IInvokeAMethod
    {
      IProvideInvocationResultDetails proceed();
    }

    public interface IProvideInvocationResultDetails
    {
    }
  }
}