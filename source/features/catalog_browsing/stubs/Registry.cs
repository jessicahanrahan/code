namespace code.features.catalog_browsing.stubs
{
  public class Registry : StructureMap.Configuration.DSL.Registry
  {
    public Registry()
    {
      ForSingletonOf<IGetDepartments>().Add<StubDepartments>();
    }
  }
}