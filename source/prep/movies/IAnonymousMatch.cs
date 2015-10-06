namespace code.prep.movies
{
    public interface IAnonymousMatch<Item>
    {
        bool matches(Item item);
    }
}