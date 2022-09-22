using Dapper.CRUD.Data.Models;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;

namespace Dapper.CRUD.Data.DAL
{
    public class EmployeeDataAdaptor : DataAdaptor
    {
        private EmployeeDataAccessLayer _dataLayer;
        public EmployeeDataAdaptor(EmployeeDataAccessLayer albumDataAccessLayer)
        {
            _dataLayer = albumDataAccessLayer;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            List<Employee> bugs = await _dataLayer.GetEmployeeAsync();
            int count = await _dataLayer.GetEmployeeCountAsync();
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = bugs, Count = count } : count;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await _dataLayer.AddEmployeeAsync(data as Employee);
            return data;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await _dataLayer.UpdateEmployeeAsync(data as Employee);
            return data;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object primaryKeyValue, string keyField, string key)
        {
            await _dataLayer.RemoveEmployeeAsync(Convert.ToInt32(primaryKeyValue));
            return primaryKeyValue;
        }
    }
}
