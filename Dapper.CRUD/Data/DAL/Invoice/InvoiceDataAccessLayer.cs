using Dapper.CRUD.Data.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper.CRUD.Data.DAL
{
    public class InvoiceDataAccessLayer
    {
        public IConfiguration Configuration;
        private const string CHINOOK_DATABASE = "chinook";
        private const string SELECT_QUERY = "select * from invoice";
        public InvoiceDataAccessLayer(IConfiguration configuration)
        {
            Configuration = configuration; //Inject configuration to access Connection string from appsettings.json.
        }

        public async Task<List<Invoice>> GetInvoiceAsync()
        {
            try
            {

                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    IEnumerable<Invoice> result = await db.QueryAsync<Invoice>(SELECT_QUERY);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> GetInvoiceCountAsync()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                int result = await db.ExecuteScalarAsync<int>("select count(*) from invoice");
                return result;
            }
        }


        public async Task AddInvoiceAsync(Invoice invoice)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    await db.ExecuteAsync("INSERT INTO invoice (CustomerId,InvoiceDate,BillingAddress,BillingCity,BillingState,BillingCountry,BillingPostalCode,Total) " +
                        "VALUES (@CustomerId,@InvoiceDate,@BillingAddress,@BillingCity,@BillingState,@BillingCountry,@BillingPostalCode,@Total)", invoice);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateInvoiceAsync(Invoice invoice)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("update invoice set CustomerId=@CustomerId,InvoiceDate=@InvoiceDate,BillingAddress=@BillingAddress,BillingCity=@BillingCity," +
                    "BillingState=@BillingState,BillingCountry=@BillingCountry,BillingPostalCode=@BillingPostalCode,Total=@Total where InvoiceId=@InvoiceId", invoice);
            }
        }

        public async Task RemoveInvoiceAsync(int invoiceid)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("delete from invoice Where InvoiceId=@InvoiceId", new { InvoiceId = invoiceid });
            }
        }
    }
}
