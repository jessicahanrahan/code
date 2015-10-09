using System;
using code.containers;
using code.containers.structuremap;
using code.containers.structuremap.extensions;
using code.startup.core;
using StructureMap;

namespace code.startup.steps
{
  public class MinimalInitialConfiguration
  {
    public static Action<ConfigurationExpression> base_config = cfg =>
    {
      cfg.Scan(scan =>
      {
        var assembly = typeof(MinimalInitialConfiguration).Assembly;
        scan.Assembly(assembly);
        scan.LookForRegistries();
        scan.enhanced().apply_all_conventions_in(assembly);
      });
    };

    public static void run()
    {
      var container = create_container();

      Start.create_startup_step = (type) => (IRunAStartupStep) container.an(type);

      Dependencies.configure_the_container = () => container;
    }

    static IFetchDependencies create_container()
    {
      var structure_map_container = new Container(base_config);
      var container = new StructureMapContainer(structure_map_container);

      structure_map_container.Configure(x =>
      {
        x.ForSingletonOf<IFetchDependencies>().Add(context => container);
        x.ForSingletonOf<IContainer>().Add(context => structure_map_container);
      });

      return container;
    }
  }
}