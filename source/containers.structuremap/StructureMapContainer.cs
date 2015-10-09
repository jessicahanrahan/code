using System;
using StructureMap;

namespace code.containers.structuremap
{
  public class StructureMapContainer : IFetchDependencies
  {
    public IContainer container;

    public StructureMapContainer(IContainer container)
    {
      this.container = container;
    }

    public Dependency an<Dependency>()
    {
      return container.GetInstance<Dependency>();
    }

    public object an(Type dependency)
    {
      return container.GetInstance(dependency);
    }
  }
}