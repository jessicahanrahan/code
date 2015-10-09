namespace code.matching.core
{
  public delegate AttributeType IGetAnAttributeValue<in Item, out AttributeType>(Item item);
}