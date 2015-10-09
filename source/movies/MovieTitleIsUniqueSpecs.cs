using System.Data;
using code.core;
using developwithpassion.specification.adapters.rhino_mocks;
using developwithpassion.specifications.assertions;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.should;
using Machine.Specifications;

namespace code.movies
{  
  [Subject(typeof(MovieTitleIsUnique))]  
  public class MovieTitleIsUniqueSpecs
  {
    public abstract class concern : spec.observe<MovieTitleIsUnique>
    {
        
    }

   
    public class when_determining_if_a_movie_has_a_unique_title : concern
    {
      Establish c = () =>
      {
        connection = fake.an<IDbConnection>();
        command = fake.an<IDbCommand>();
        reader = fake.an<IDataReader>();

        the_table = new DataTable();

        the_table.Rows.Add(the_table.NewRow());

        command.setup(x => x.ExecuteReader()).Return(reader);

        depends.on<ICreateAConnectionToTheDatabase>(() => connection);

        the_movie = new Movie
        {
          title = "Blah"
        };

        depends.on<IMap<DataRow, Movie>>(row =>
        {
          mapped_the_movie = true;

          return the_movie;
        });

        depends.on<IMap<IDataReader, DataTable>>(x =>
        {
          x.ShouldEqual(reader);
          return the_table;
        });

        connection.setup(x => x.CreateCommand()).Return(command);
      };

      Because b = () =>
        result = sut.matches(new Movie
        {
          title = "Blah"
        });

      It creates_a_connection_to_the_database = () =>
        connection.should().have_received(x => x.Open());

      It creates_a_command_to_query_the_database = () =>
      {
        command.CommandType.ShouldEqual(CommandType.Text);
        command.CommandText.ShouldEqual("SELECT * FROM Movies");
      };

      It maps_each_of_the_records_into_a_movie_instance = () =>
        mapped_the_movie.ShouldBeTrue();
        
      It disposes_the_connection = () =>
        connection.should().have_received(x => x.Dispose());

      It result_is_unqiueness_value = () =>
        result.ShouldBeFalse();

      static IDbConnection connection;
      static bool result;
      static IDbCommand command;
      static bool mapped_the_movie;
      static Movie the_movie;
      static IDataReader reader;
      static DataTable the_table;
    }
  }
}
