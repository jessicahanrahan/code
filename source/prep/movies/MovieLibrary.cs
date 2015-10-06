using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.UI.WebControls;

namespace code.prep.movies
{
    public class MovieLibrary
    {
        readonly IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            //Iterator Design Pattern
            //Coding to contracts, not implementation
            //To pass trying_to_violate_encapsulation_of_the_movie_libraries_data
            //Put in Enumerable extension class
            foreach (var movie in movies)
            {
                yield return movie;
            }
        }

        public void add(Movie movie)
        {
            if (already_contains(movie)) return;
            // shouldn't check for equality here, should only check in Movie
            movies.Add(movie);
        }

        private bool already_contains(Movie movie)
        {
            return movies.Contains(movie);
        }

        public IEnumerable<Movie> all_matching_criteria(MovieCriteria criteria)
        {
            foreach (var movie in movies)
            {
                if (criteria(movie))
                {
                    yield return movie;
                }
            }
        }

        public delegate bool MovieCriteria(Movie movie);

        //public void delegate_host()
        //{
        //    MovieCriteria first = new MovieCriteria(is_pixar_movie);
        //    MovieCriteria second = is_pixar_movie;
        //    MovieCriteria third = delegate(Movie movie)
        //    {
        //        return false;
        //    };
        //    MovieCriteria fourth = (Movie movie) =>
        //    {
        //        return false;
        //    };
        //    MovieCriteria fifth = (movie) =>
        //    {
        //        return false;
        //    };

        //    MovieCriteria sixth = movie => true;
        //    Expression<MovieCriteria> seventh = movie => true;

        //    //LINQ converts to expression tree structure from lambda syntax, you can walk it yourself

        //    var the_number_2 = Expression.Constant(2);

        //    var eigth = seventh.Compile();
        //}

        //public static bool is_pixar_movie(Movie movie)
        //{
        //    return movie.production_studio == ProductionStudio.Pixar;
        //}

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
            return all_matching_criteria(m => m.genre == Genre.action);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending()
        {
            IEnumerable<Movie> stMovies = all_movies();
            List<Movie> retMovies = Movie.CreateSortList<Movie>(stMovies, "title", SortDirection.Descending);
            return retMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending()
        {
            IEnumerable<Movie> stMovies = all_movies();
            List<Movie> retMovies = Movie.CreateSortList<Movie>(stMovies, "title", SortDirection.Ascending);
            return retMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            IEnumerable<Movie> stMovies = all_movies();
            List<Movie> retMovies = Movie.CreateSortList<Movie>(stMovies, "production_studio", SortDirection.Ascending,
                "date_published", SortDirection.Ascending);
            return retMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            IEnumerable<Movie> stMovies = all_movies();
            List<Movie> retMovies = Movie.CreateSortList<Movie>(stMovies, "date_published", SortDirection.Descending);
            return retMovies;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            IEnumerable<Movie> stMovies = all_movies();
            List<Movie> retMovies = Movie.CreateSortList<Movie>(stMovies, "date_published", SortDirection.Ascending);
            return retMovies;
        }

    }
}
