namespace code.matching
{
    public interface ICreateMatchers<Item, AttributeType>
    {
        IMatchAn<Item> equal_to(AttributeType value);
        IMatchAn<Item> equal_to_any(params AttributeType[] values);
        IMatchAn<Item> not_equal_to(AttributeType value);
    }
}