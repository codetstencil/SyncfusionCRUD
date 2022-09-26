using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper.CRUD.Data.Models;

namespace Dapper.CRUD.Data.DAL
{
    public class AlbumDataAccessLayer
    {
        public IConfiguration Configuration;
        private const string CHINOOK_DATABASE = "chinook";
        private const string SELECT_QUERY = "select * from album";
        public AlbumDataAccessLayer(IConfiguration configuration)
        {
            Configuration = configuration; //Inject configuration to access Connection string from appsettings.json.
        }

        public async Task<List<Album>> GetAlbumAsync()
        {
            try
            {

            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                IEnumerable<Album> result = await db.QueryAsync<Album>(SELECT_QUERY);
                return result.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetAlbumCountAsync()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                int result = await db.ExecuteScalarAsync<int>("select count(*) from album");
                return result;
            }
        }


        public async Task AddAlbumAsync(Album album)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    await db.ExecuteAsync("insert into album (Title, ArtistId) values (@Title,@ArtistId)", album);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAlbumAsync(Album album)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("update album set Title=@Title, ArtistId=@ArtistId where AlbumId=@AlbumId", album);
            }
        }

        public async Task RemoveAlbumAsync(int albumid)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("delete from album Where AlbumId=@AlbumId", new { AlbumId = albumid });
            }
        }
    }
}
