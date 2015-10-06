using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.UI.WebControls;

namespace code.prep.movies
{
    public class Movie
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public List<Movie> CreateSortList<T>(
            IEnumerable<Movie> dataSource,
            string fieldName, SortDirection sortDirection)
        {
            List<Movie> returnList = new List<Movie>();
            returnList.AddRange(dataSource);
            // get property from field name passed
            PropertyInfo propInfo = typeof(T).GetProperty(fieldName);
            Comparison<Movie> compare = delegate(Movie a, Movie b)
            {
                bool asc = sortDirection == SortDirection.Ascending;
                object valueA = asc ? propInfo.GetValue(a, null) : propInfo.GetValue(b, null);
                object valueB = asc ? propInfo.GetValue(b, null) : propInfo.GetValue(a, null);
                //comparing the items
                return valueA is IComparable ? ((IComparable) valueA).CompareTo(valueB) : 0;
            };
            returnList.Sort(compare);
            return returnList;
        }

        public List<Movie> CreateSortList<T>(
            IEnumerable<Movie> dataSource,
            string fieldName1, SortDirection sortDirection1,
            string fieldName2, SortDirection sortDirection2)
        {
            List<Movie> returnList = new List<Movie>();
            returnList.AddRange(dataSource);
            // get property from field name passed
            PropertyInfo propInfo1 = typeof(T).GetProperty(fieldName1);
            PropertyInfo propInfo2 = typeof(T).GetProperty(fieldName2);
            Comparison<Movie> compare = delegate(Movie a, Movie b)
            {
                bool asc = sortDirection1 == SortDirection.Ascending;
                object valueA = asc ? propInfo1.GetValue(a, null) : propInfo1.GetValue(b, null);
                object valueB = asc ? propInfo1.GetValue(b, null) : propInfo1.GetValue(a, null);

                if (valueA is IComparable)
                {
                    var comparison = ((IComparable) valueA).CompareTo(valueB);
                    if (comparison == 0)
                    {
                        bool asc2 = sortDirection2 == SortDirection.Ascending;
                        object valueA2 = asc2 ? propInfo2.GetValue(a, null) : propInfo2.GetValue(b, null);
                        object valueB2 = asc2 ? propInfo2.GetValue(b, null) : propInfo2.GetValue(a, null);

                        return valueA2 is IComparable ? ((IComparable) valueA2).CompareTo(valueB2) : 0;
                    }
                }
                //comparing the items
                return valueA is IComparable ? ((IComparable) valueA).CompareTo(valueB) : 0;
            };
            returnList.Sort(compare);
            return returnList;
        }
    }
}