using System;
using System.Collections.Generic;
using code.enumerables;
using code.matching;

namespace code.prep.movies
{
  public class MovieLibrary
  {
    readonly IList<Movie> movies;

    public MovieLibrary(IList<Movie> list_of_movies)
    {
      this.movies = list_of_movies;
    }

    public IEnumerable<Movie> all_movies()
    {
      return movies.one_at_a_time();
    }

    public void add(Movie movie)
    {
      if (already_contains(movie)) return;

      movies.Add(movie);
    }

    bool already_contains(Movie movie)
    {
      return movies.Contains(movie);
    }

    public delegate bool MovieCriteria(Movie movie);

    public IEnumerable<Movie> all_matching_criteria(MovieCriteria criteria)
    {
      //return movies.all_items_matching(criteria.Invoke);
        return movies.all_items_matching(new IsCriteria(criteria.Invoke));
    }

    public IEnumerable<Movie> all_movies_published_by_pixar()
    {
      return all_matching_criteria(movie => movie.production_studio == ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
    {
      return all_matching_criteria(m => m.production_studio == ProductionStudio.Pixar
                                        || m.production_studio == ProductionStudio.Disney);
    }

    public IEnumerable<Movie> all_movies_not_published_by_pixar()
    {
      return all_matching_criteria(m => m.production_studio != ProductionStudio.Pixar);
    }

    public IEnumerable<Movie> all_movies_published_after(int year)
    {
      return all_matching_criteria(m => m.date_published.Year > year);
    }

    public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
    {
      return all_matching_criteria(m => m.date_published.Year >= startingYear
                                        && m.date_published.Year <= endingYear);
    }

    public IEnumerable<Movie> all_kid_movies()
    {
      return all_matching_criteria(m => m.genre == Genre.kids);
    }

    public IEnumerable<Movie> all_action_movies()
    {
      foreach (var m in all_movies())
      {
        if (m.genre == Genre.action)
          yield return m;
      }
    }

    public IEnumerable<Movie> sort_all_movies_by_title_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_title_ascending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
    {
      throw new NotImplementedException();
    }
  }
}
