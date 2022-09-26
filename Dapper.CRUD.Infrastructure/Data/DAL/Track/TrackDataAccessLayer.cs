using Dapper.CRUD.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Dapper.CRUD.Data.DAL
{
    public class TrackDataAccessLayer
    {
        public IConfiguration Configuration;
        private const string CHINOOK_DATABASE = "chinook";
        private const string SELECT_QUERY = "select * from track";
        public TrackDataAccessLayer(IConfiguration configuration)
        {
            Configuration = configuration; //Inject configuration to access Connection string from appsettings.json.
        }

        public async Task<List<Track>> GetTrackAsync()
        {
            try
            {

                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    IEnumerable<Track> result = await db.QueryAsync<Track>(SELECT_QUERY);
                    return result.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetTrackCountAsync()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                int result = await db.ExecuteScalarAsync<int>("select count(*) from track");
                return result;
            }
        }


        public async Task AddTrackAsync(Track track)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    await db.ExecuteAsync("INSERT INTO track (Name,AlbumId,MediaTypeId,GenreId,Composer,Miliseconds,Bytes,UnitPrice,PlayListTrackId) VALUES (@Name,@AlbumId,@MediaTypeId,@GenreId,@Composer,@Miliseconds,@Bytes,@UnitPrice,@PlayListTrackId)", track);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateTrackAsync(Track track)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("update track set Name=@Name,AlbumId=@AlbumId,MediaTypeId=@MediaTypeId,GenreId=@GenreId," +
                    "Composer=@Composer,Miliseconds=@Miliseconds,Bytes=@Bytes,UnitPrice=@UnitPrice,PlayListTrackId=@PlayListTrackId where TrackId=@TrackId", track);
            }
        }

        public async Task RemoveTrackAsync(int trackid)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("delete from track Where TrackId=@TrackId", new { TrackId = trackid });
            }
        }
    }
}
