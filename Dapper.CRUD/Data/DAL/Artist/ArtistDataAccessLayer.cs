using Dapper.CRUD.Data.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper.CRUD.Data.DAL
{
    public class ArtistDataAccessLayer
    {
        public IConfiguration Configuration;
        private const string CHINOOK_DATABASE = "chinook";
        private const string SELECT_QUERY = "select * from artist";
        public ArtistDataAccessLayer(IConfiguration configuration)
        {
            Configuration = configuration; //Inject configuration to access Connection string from appsettings.json.
        }

        public async Task<List<Artist>> GetArtistAsync()
        {
            try
            {

                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    IEnumerable<Artist> result = await db.QueryAsync<Artist>(SELECT_QUERY);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> GetArtistCountAsync()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                int result = await db.ExecuteScalarAsync<int>("select count(*) from artist");
                return result;
            }
        }


        public async Task AddArtistAsync(Artist artist)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    await db.ExecuteAsync("insert into artist (Name) values (@Name)",artist);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateArtistAsync(Artist artist)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("update artist set Name=@Name where ArtistId=@ArtistId", artist);
            }
        }

        public async Task RemoveArtistAsync(int artistid)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("delete from artist Where ArtistId=@ArtistId", new { ArtistId = artistid });
            }
        }
    }
}
