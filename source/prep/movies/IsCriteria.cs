using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using code.enumerables;
using code.matching;


namespace code.prep.movies
{
    class IsCriteria : IMatchAn<Movie>
    {
        Criteria<Movie> criteria;

        public IsCriteria(Criteria<Movie> criteria)
        {
            this.criteria = criteria;
        }

        public bool matches(Movie item)
        {
            return criteria.Invoke(item);
        }
    }
}
