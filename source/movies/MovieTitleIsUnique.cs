using System.Data;
using code.core;
using code.matching.core;

namespace code.movies
{
  public delegate IDbConnection ICreateAConnectionToTheDatabase();

  public class MovieTitleIsUnique : IMatchAn<Movie>
  {
    ICreateAConnectionToTheDatabase connection_builder;
    IMap<IDataReader, DataTable> table_mapper;
    IMap<DataRow, Movie> row_mapper;

    public MovieTitleIsUnique(ICreateAConnectionToTheDatabase connection_builder, 
      IMap<IDataReader, DataTable> table_mapper, IMap<DataRow, Movie> row_mapper)
    {
      this.connection_builder = connection_builder;
      this.table_mapper = table_mapper;
      this.row_mapper = row_mapper;
    }

    public bool matches(Movie item)
    {
      using (var connection = connection_builder())
      using (var command = connection.CreateCommand())
      {
        command.CommandType = CommandType.Text;
        command.CommandText = "SELECT * FROM Movies";
        connection.Open();

        using (var reader = command.ExecuteReader())
        {
          var raw_data = table_mapper(reader);

          foreach (DataRow row in raw_data.Rows)
          {

            var movie = row_mapper(row);
            if (movie.title.Equals(item.title)) return false;
          }
        }
      }
      return true;
    }
  }
}