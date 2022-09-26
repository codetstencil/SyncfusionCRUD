using Dapper.CRUD.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Dapper.CRUD.Data.DAL
{
    public class PlayListDataAccessLayer
    {
        public IConfiguration Configuration;
        private const string CHINOOK_DATABASE = "chinook";
        private const string SELECT_QUERY = "select * from playlist";
        public PlayListDataAccessLayer(IConfiguration configuration)
        {
            Configuration = configuration; //Inject configuration to access Connection string from appsettings.json.
        }

        public async Task<List<PlayList>> GetPlayListAsync()
        {
            try
            {

                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    IEnumerable<PlayList> result = await db.QueryAsync<PlayList>(SELECT_QUERY);
                    return result.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetPlayListCountAsync()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                int result = await db.ExecuteScalarAsync<int>("select count(*) from playlist");
                return result;
            }
        }


        public async Task AddPlayListAsync(PlayList playlist)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    await db.ExecuteAsync("insert into playlist (Name, PlayListTrackId) values (@Name, @PlayListTrackId)", playlist);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdatePlayListAsync(PlayList playlist)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("update playlist set Name=@Name, PlayListTrackId=@PlayListTrackId where PlayListId=@PlayListId", playlist);
            }
        }

        public async Task RemovePlayListAsync(int playlistid)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("delete from playlist Where PlayListId=@PlayListId", new { PlayListId = playlistid });
            }
        }
    }
}
