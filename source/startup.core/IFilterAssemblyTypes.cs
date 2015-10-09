using System;
using System.Collections.Generic;
using System.Reflection;
using code.core;

namespace code.startup.core
{
  public delegate IEnumerable<Type> IFilterAssemblyTypes(ICheckAConstraint<Type> specification);

  public delegate IFilterAssemblyTypes ICreateAnAssemblyTypeFilter(Assembly assembly);
}