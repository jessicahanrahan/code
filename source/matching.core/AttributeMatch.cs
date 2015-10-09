namespace code.matching.core
{
  public class AttributeMatch<Item, AttributeType> : IMatchAn<Item>
  {
    IGetAnAttributeValue<Item, AttributeType> get_the_value;
    IMatchAn<AttributeType> criteria;

    public AttributeMatch(IGetAnAttributeValue<Item, AttributeType> get_the_value, IMatchAn<AttributeType> criteria)
    {
      this.get_the_value = get_the_value;
      this.criteria = criteria;
    }

    public bool matches(Item item)
    {
      var value = get_the_value(item);

      return criteria.matches(value);
    }
  }
}