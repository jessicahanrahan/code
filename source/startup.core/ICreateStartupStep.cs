using System;

namespace code.startup.core
{
  public delegate IRunAStartupStep ICreateStartupStep(Type step_type);
}