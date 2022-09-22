using Dapper.CRUD.Data.Models;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;

namespace Dapper.CRUD.Data.DAL
{ 
    public class CustomerDataAdaptor : DataAdaptor
    {
        private CustomerDataAccessLayer _dataLayer;
        public CustomerDataAdaptor(CustomerDataAccessLayer albumDataAccessLayer)
        {
            _dataLayer = albumDataAccessLayer;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            List<Customer> bugs = await _dataLayer.GetCustomerAsync();
            int count = await _dataLayer.GetCustomerCountAsync();
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = bugs, Count = count } : count;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await _dataLayer.AddCustomerAsync(data as Customer);
            return data;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _dataLayer.UpdateCustomerAsync(data as Customer);
            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
        {
            await _dataLayer.RemoveCustomerAsync(Convert.ToInt32(primaryKeyValue));
            return primaryKeyValue;
        }
    }
}
