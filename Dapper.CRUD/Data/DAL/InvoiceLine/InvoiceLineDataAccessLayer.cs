using Dapper.CRUD.Data.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper.CRUD.Data.DAL
{
    public class InvoiceLineDataAccessLayer
    {
        public IConfiguration Configuration;
        private const string CHINOOK_DATABASE = "chinook";
        private const string SELECT_QUERY = "select * from invoiceline";
        public InvoiceLineDataAccessLayer(IConfiguration configuration)
        {
            Configuration = configuration; //Inject configuration to access Connection string from appsettings.json.
        }

        public async Task<List<InvoiceLine>> GetInvoiceLineAsync()
        {
            try
            {

                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    IEnumerable<InvoiceLine> result = await db.QueryAsync<InvoiceLine>(SELECT_QUERY);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> GetInvoiceLineCountAsync()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                int result = await db.ExecuteScalarAsync<int>("select count(*) from invoiceline");
                return result;
            }
        }


        public async Task AddInvoiceLineAsync(InvoiceLine invoiceline)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    await db.ExecuteAsync("INSERT INTO invoiceline (InvoiceId,TrackId,UnitPrice,Quantity) " +
                        "VALUES (@InvoiceId,@TrackId,@UnitPrice,@Quantity)",invoiceline);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateInvoiceLineAsync(InvoiceLine invoiceline)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("update invoiceline set InvoiceId=@InvoiceId,TrackId=@TrackId,UnitPrice=@UnitPrice,Quantity=@Quantity where InvoiceLineId=@InvoiceLineId", invoiceline);
            }
        }

        public async Task RemoveInvoiceLineAsync(int invoicelineid)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("delete from invoiceline Where InvoiceLine=@InvoiceLineId", new { InvoiceLineId = invoicelineid });
            }
        }
    }
}
