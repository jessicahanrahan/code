using System.Linq;
using code.startup.core;

namespace code.startup.steps
{
  public class Delegates
  {
    public static readonly ICreateAnAssemblyTypeFilter assembly_type_filter = assembly =>
      spec => assembly.GetTypes().Where(spec.Invoke);
  }
}