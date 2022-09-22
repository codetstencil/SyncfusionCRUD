using Dapper.CRUD.Data.Models;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;

namespace Dapper.CRUD.Data.DAL
{
    public class MediaTypeDataAdaptor : DataAdaptor
    {
        private MediaTypeDataAccessLayer _dataLayer;
        public MediaTypeDataAdaptor(MediaTypeDataAccessLayer albumDataAccessLayer)
        {
            _dataLayer = albumDataAccessLayer;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            List<MediaType> bugs = await _dataLayer.GetMediaTypeAsync();
            int count = await _dataLayer.GetMediaTypeCountAsync();
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = bugs, Count = count } : count;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await _dataLayer.AddMediaTypeAsync(data as MediaType);
            return data;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _dataLayer.UpdateMediaTypeAsync(data as MediaType);
            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
        {
            await _dataLayer.RemoveMediaTypeAsync(Convert.ToInt32(primaryKeyValue));
            return primaryKeyValue;
        }
    }
}
