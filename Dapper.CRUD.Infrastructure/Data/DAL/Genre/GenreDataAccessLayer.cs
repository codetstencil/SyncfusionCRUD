using Dapper.CRUD.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Dapper.CRUD.Data.DAL
{
    public class GenreDataAccessLayer
    {
        public IConfiguration Configuration;
        private const string CHINOOK_DATABASE = "chinook";
        private const string SELECT_QUERY = "select * from genre";
        public GenreDataAccessLayer(IConfiguration configuration)
        {
            Configuration = configuration; //Inject configuration to access Connection string from appsettings.json.
        }

        public async Task<List<Genre>> GetGenreAsync()
        {
            try
            {

                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    IEnumerable<Genre> result = await db.QueryAsync<Genre>(SELECT_QUERY);
                    return result.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetGenreCountAsync()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                int result = await db.ExecuteScalarAsync<int>("select count(*) from genre");
                return result;
            }
        }


        public async Task AddGenreAsync(Genre genre)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    await db.ExecuteAsync("insert into genre (Name) values (@Name)",genre);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateGenreAsync(Genre genre)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("update genre set Name=@Name where GenreId=@GenreId", genre);
            }
        }

        public async Task RemoveGenreAsync(int genreid)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("delete from genre Where GenreId=@GenreId", new { GenreId = genreid });
            }
        }
    }
}
