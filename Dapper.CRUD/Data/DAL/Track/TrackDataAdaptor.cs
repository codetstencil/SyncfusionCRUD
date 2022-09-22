using Dapper.CRUD.Data.Models;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;

namespace Dapper.CRUD.Data.DAL
{
    public class TrackDataAdaptor : DataAdaptor
    {
        private TrackDataAccessLayer _dataLayer;
        public TrackDataAdaptor(TrackDataAccessLayer albumDataAccessLayer)
        {
            _dataLayer = albumDataAccessLayer;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            List<Track> bugs = await _dataLayer.GetTrackAsync();
            int count = await _dataLayer.GetTrackCountAsync();
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = bugs, Count = count } : count;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await _dataLayer.AddTrackAsync(data as Track);
            return data;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _dataLayer.UpdateTrackAsync(data as Track);
            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
        {
            await _dataLayer.RemoveTrackAsync(Convert.ToInt32(primaryKeyValue));
            return primaryKeyValue;
        }
    }
}
