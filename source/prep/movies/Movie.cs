using System;
using code.enumerables;
using code.matching;

namespace code.prep.movies
{
  public class Movie : IEquatable<Movie>
  {
    public string title { get; set; }
    public ProductionStudio production_studio { get; set; }
    public Genre genre { get; set; }
    public int rating { get; set; }

    public DateTime date_published { get; set; }

    public override bool Equals(object obj)
    {
      return Equals(obj as Movie);
    }

    public override int GetHashCode()
    {
      return title.GetHashCode();
    }

    public bool Equals(Movie other)
    {
      if (other == null) return false;

      return ReferenceEquals(this, other) || equal_to_non_null(other);
    }

    bool equal_to_non_null(Movie other)
    {
      return title.Equals(other.title);
    }

    public static IMatchAn<Movie> is_published_by(ProductionStudio studio)
    {
      return new IsPublishedBy(studio);
    }

    public static IMatchAn<Movie> is_in_genre(Genre genre)
    {
      return new IsInGenre(genre);
    }

    public static IMatchAn<Movie> is_published_by_pixar_or_disney()
    {
      throw new NotImplementedException();
//      return x => is_published_by(ProductionStudio.Pixar)(x) ||
//                  is_published_by(ProductionStudio.Disney)(x);
    }
  }
}
