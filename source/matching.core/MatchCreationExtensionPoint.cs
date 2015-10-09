namespace code.matching.core
{
  public class MatchCreationExtensionPoint<ItemToMatch, AttributeType> : IProvideAccessToCreateMatchers<ItemToMatch, AttributeType>
  {
    IGetAnAttributeValue<ItemToMatch, AttributeType> accessor;

    public MatchCreationExtensionPoint(IGetAnAttributeValue<ItemToMatch, AttributeType> accessor)
    {
      this.accessor = accessor;
    }

    public IMatchAn<ItemToMatch> create_matcher(IMatchAn<AttributeType> value_matcher)
    {
      return new AttributeMatch<ItemToMatch, AttributeType>(accessor,
        value_matcher);
    }

    public IProvideAccessToCreateMatchers<ItemToMatch, AttributeType> not
    {
      get
      {
        return new NegatingMatchCreationExtensionPoint(this);
      }
    }

    class NegatingMatchCreationExtensionPoint : IProvideAccessToCreateMatchers<ItemToMatch, AttributeType>
    {
      IProvideAccessToCreateMatchers<ItemToMatch, AttributeType> original;

      public NegatingMatchCreationExtensionPoint(IProvideAccessToCreateMatchers<ItemToMatch, AttributeType> original)
      {
        this.original = original;
      }

      public IMatchAn<ItemToMatch> create_matcher(IMatchAn<AttributeType> value_matcher)
      {
        return original.create_matcher(value_matcher).negate();
      }
    }

  }
}