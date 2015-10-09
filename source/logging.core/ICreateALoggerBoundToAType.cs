using System;

namespace code.logging.core
{
  public delegate ILogMessages ICreateALoggerBoundToAType(Type type_that_requested_logging);
}