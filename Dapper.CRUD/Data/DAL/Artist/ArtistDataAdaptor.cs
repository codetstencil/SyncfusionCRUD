using Dapper.CRUD.Data.Models;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;

namespace Dapper.CRUD.Data.DAL
{
    public class ArtistDataAdaptor : DataAdaptor
    {
        private ArtistDataAccessLayer _dataLayer;
        public ArtistDataAdaptor(ArtistDataAccessLayer albumDataAccessLayer)
        {
            _dataLayer = albumDataAccessLayer;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            List<Artist> bugs = await _dataLayer.GetArtistAsync();
            int count = await _dataLayer.GetArtistCountAsync();
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = bugs, Count = count } : count;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await _dataLayer.AddArtistAsync(data as Artist);
            return data;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _dataLayer.UpdateArtistAsync(data as Artist);
            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
        {
            await _dataLayer.RemoveArtistAsync(Convert.ToInt32(primaryKeyValue));
            return primaryKeyValue;
        }
    }
}
