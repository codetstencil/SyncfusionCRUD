using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;
using Dapper.CRUD.Data.Models;

namespace Dapper.CRUD.Data.DAL
{
    public class AlbumDataAdaptor : DataAdaptor
    {
        private AlbumDataAccessLayer _dataLayer;
        public AlbumDataAdaptor(AlbumDataAccessLayer albumDataAccessLayer)
        {
            _dataLayer = albumDataAccessLayer;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            List<Album> bugs = await _dataLayer.GetAlbumAsync();
            int count = await _dataLayer.GetAlbumCountAsync();
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = bugs, Count = count } : count;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await _dataLayer.AddAlbumAsync((Album)data);
            return data;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _dataLayer.UpdateAlbumAsync((Album)data);
            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
        {
            await _dataLayer.RemoveAlbumAsync(Convert.ToInt32(primaryKeyValue));
            return primaryKeyValue;
        }
    }
}
