using Dapper.CRUD.Data.Models;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;

namespace Dapper.CRUD.Data.DAL
{
    public class InvoiceLineDataAdaptor : DataAdaptor
    {
        private InvoiceLineDataAccessLayer _dataLayer;
        public InvoiceLineDataAdaptor(InvoiceLineDataAccessLayer albumDataAccessLayer)
        {
            _dataLayer = albumDataAccessLayer;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            List<InvoiceLine> bugs = await _dataLayer.GetInvoiceLineAsync();
            int count = await _dataLayer.GetInvoiceLineCountAsync();
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = bugs, Count = count } : count;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await _dataLayer.AddInvoiceLineAsync(data as InvoiceLine);
            return data;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _dataLayer.UpdateInvoiceLineAsync(data as InvoiceLine);
            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
        {
            await _dataLayer.RemoveInvoiceLineAsync(Convert.ToInt32(primaryKeyValue));
            return primaryKeyValue;
        }
    }
}
