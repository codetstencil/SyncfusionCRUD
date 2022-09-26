using Dapper.CRUD.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Dapper.CRUD.Data.DAL
{
    public class MediaTypeDataAccessLayer
    {
        public IConfiguration Configuration;
        private const string CHINOOK_DATABASE = "chinook";
        private const string SELECT_QUERY = "select * from mediatype";
        public MediaTypeDataAccessLayer(IConfiguration configuration)
        {
            Configuration = configuration; //Inject configuration to access Connection string from appsettings.json.
        }

        public async Task<List<MediaType>> GetMediaTypeAsync()
        {
            try
            {

                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    IEnumerable<MediaType> result = await db.QueryAsync<MediaType>(SELECT_QUERY);
                    return result.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetMediaTypeCountAsync()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                int result = await db.ExecuteScalarAsync<int>("select count(*) from mediatype");
                return result;
            }
        }


        public async Task AddMediaTypeAsync(MediaType mediatype)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    await db.ExecuteAsync("insert into mediatype (Name) values (@Name)",mediatype);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateMediaTypeAsync(MediaType mediatype)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("update mediatype set Name=@Name where MediaTypeId=@MediaTypeId", mediatype);
            }
        }

        public async Task RemoveMediaTypeAsync(int mediatypeid)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("delete from mediatype Where MediaTypeId=@MediaTypeId", new { MediaTypeId = mediatypeid });
            }
        }
    }
}
