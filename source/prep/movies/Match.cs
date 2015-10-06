using System;
using System.Collections.Generic;
using System.Linq;
using code.matching;
using code.prep.movies;

namespace code.prep.movies
{

  public delegate ProductionStudio IGetAMoviesProductionStudio(Movie movie);

  public class Match<Item>
  {
    public static IGetAMoviesProductionStudio attribute(IGetAMoviesProductionStudio acc)
    {
        return acc;
    }
  }


    public static class AccessorExtensions
    {
    public static IMatchAn<Movie> equal_to(this IGetAMoviesProductionStudio accessor, ProductionStudio value)
    {
        return new AnonymousMatch<Movie>(x => x.production_studio == value);
    }
    }
}
