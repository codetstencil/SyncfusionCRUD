using Dapper.CRUD.Data.Models;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;

namespace Dapper.CRUD.Data.DAL
{
    public class InvoiceDataAdaptor : DataAdaptor
    {
        private InvoiceDataAccessLayer _dataLayer;
        public InvoiceDataAdaptor(InvoiceDataAccessLayer albumDataAccessLayer)
        {
            _dataLayer = albumDataAccessLayer;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            List<Invoice> bugs = await _dataLayer.GetInvoiceAsync();
            int count = await _dataLayer.GetInvoiceCountAsync();
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = bugs, Count = count } : count;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await _dataLayer.AddInvoiceAsync(data as Invoice);
            return data;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _dataLayer.UpdateInvoiceAsync(data as Invoice);
            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
        {
            await _dataLayer.RemoveInvoiceAsync(Convert.ToInt32(primaryKeyValue));
            return primaryKeyValue;
        }
    }
}
