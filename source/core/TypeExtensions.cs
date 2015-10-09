namespace code.core
{
  public static class TypeExtensions
  {
    public static DesiredType cast_to<DesiredType>(this object item)
    {
      return (DesiredType) item;
    }
  }
}