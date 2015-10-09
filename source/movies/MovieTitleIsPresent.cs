using code.matching.core;

namespace code.movies
{
  public class MovieTitleIsPresent : IMatchAn<Movie>
  {
    public bool matches(Movie movie)
    {
      var empty_string = Match<string>.attribute(x => x)
        .create_from_criteria(x => string.IsNullOrEmpty(x));

      return Match<Movie>.attribute(x => x.title)
        .not.create_from_match(empty_string).matches(movie);
    } 
  }
}