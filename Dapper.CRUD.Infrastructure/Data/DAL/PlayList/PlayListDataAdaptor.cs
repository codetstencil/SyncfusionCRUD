using Dapper.CRUD.Data.Models;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;

namespace Dapper.CRUD.Data.DAL
{
    public class PlayListDataAdaptor : DataAdaptor
    {
        private PlayListDataAccessLayer _dataLayer;
        public PlayListDataAdaptor(PlayListDataAccessLayer albumDataAccessLayer)
        {
            _dataLayer = albumDataAccessLayer;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            List<PlayList> bugs = await _dataLayer.GetPlayListAsync();
            int count = await _dataLayer.GetPlayListCountAsync();
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = bugs, Count = count } : count;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await _dataLayer.AddPlayListAsync(data as PlayList);
            return data;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _dataLayer.UpdatePlayListAsync(data as PlayList);
            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
        {
            await _dataLayer.RemovePlayListAsync(Convert.ToInt32(primaryKeyValue));
            return primaryKeyValue;
        }
    }
}
