using System;

namespace code.containers
{
  public interface IFetchDependencies
  {
    Dependency an<Dependency>();
    object an(Type dependency);
  }

}