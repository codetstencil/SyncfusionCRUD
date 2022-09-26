using Dapper.CRUD.Data.Models;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;

namespace Dapper.CRUD.Data.DAL
{
    public class GenreDataAdaptor : DataAdaptor
    {
        private GenreDataAccessLayer _dataLayer;
        public GenreDataAdaptor(GenreDataAccessLayer albumDataAccessLayer)
        {
            _dataLayer = albumDataAccessLayer;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            List<Genre> bugs = await _dataLayer.GetGenreAsync();
            int count = await _dataLayer.GetGenreCountAsync();
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = bugs, Count = count } : count;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await _dataLayer.AddGenreAsync(data as Genre);
            return data;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _dataLayer.UpdateGenreAsync(data as Genre);
            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
        {
            await _dataLayer.RemoveGenreAsync(Convert.ToInt32(primaryKeyValue));
            return primaryKeyValue;
        }
    }
}
