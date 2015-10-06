using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using code.enumerables;
using code.matching;


namespace code.prep.movies
{
    public class IsCriteria<Item> : IMatchAn<Item>
    {
        Criteria<Item> criteria;

        public IsCriteria(Criteria<Item> criteria)
        {
            this.criteria = criteria;
        }

        public bool matches(Item item)
        {
            return criteria.Invoke(item);
        }
    }

    public class OrMatch<Item> : IMatchAn<Item>
    {
        IMatchAn<Item> left;
        IMatchAn<Item> right;

        public OrMatch(IMatchAn<Item> left, IMatchAn<Item> right)
        {
            this.left = left;
            this.right = right;
        }

        public bool matches(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
