using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.prep.movies
{
    public interface IMatch<in Item>
    {
        bool matches(Item movie);
    }

    public class IsPublishedBy : IMatch<Movie>
    {
        ProductionStudio studio;

        public IsPublishedBy(ProductionStudio studio)
        {
            this.studio = studio;
        }

        public bool matches(Movie movie)
        {
            return movie.production_studio == studio;
        }
    }

    public class IsInGenre : IMatch<Movie>
    {
        Genre genre;

        public IsInGenre(Genre g)
        {
            this.genre = g;
        }

        public bool matches(Movie movie)
        {
            return movie.genre == genre;
        }
    }
}
