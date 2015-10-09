using System;

namespace code.containers
{
  public class Dependencies
  {
    public static IConfigureTheContainerFacade configure_the_container = delegate
    {
      throw new NotImplementedException("This needs to be configured by a starup pipeline");
    };

    public static IFetchDependencies fetch
    {
      get
      {
        return configure_the_container();
      }
    }
  }
}