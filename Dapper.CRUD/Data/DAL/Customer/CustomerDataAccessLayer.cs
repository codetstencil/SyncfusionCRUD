using Dapper.CRUD.Data.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper.CRUD.Data.DAL
{
    public class CustomerDataAccessLayer
    {
        public IConfiguration Configuration;
        private const string CHINOOK_DATABASE = "chinook";
        private const string SELECT_QUERY = "select * from customer";
        public CustomerDataAccessLayer(IConfiguration configuration)
        {
            Configuration = configuration; //Inject configuration to access Connection string from appsettings.json.
        }

        public async Task<List<Customer>> GetCustomerAsync()
        {
            try
            {

                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    IEnumerable<Customer> result = await db.QueryAsync<Customer>(SELECT_QUERY);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> GetCustomerCountAsync()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                int result = await db.ExecuteScalarAsync<int>("select count(*) from customer");
                return result;
            }
        }


        public async Task AddCustomerAsync(Customer customer)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    await db.ExecuteAsync("INSERT INTO customer (FirstName,LastName,Company,Address,City,State,Country,PostalCode,Phone,Fax,Email,SupportRepId)" +
                        " VALUES (@FirstName,@LastName,@Company,@Address,@City,@State,@Country,@PostalCode,@Phone,@Fax,@Email,@SupportRepId)",customer);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("update customer set FirstName=@FirstName,LastName=@LastName,Company=@Company,Address=@Address,City=@City,State=@State," +
                    "Country=@Country,PostalCode=@PostalCode,Phone=@Phone,Fax=@Fax,Email=@Email,SupportRepId=@SupportRepId where CustomerId=@CustomerId", customer);
            }
        }

        public async Task RemoveCustomerAsync(int customerid)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("delete from customer Where CustomerId=@CustomerId", new { CustomerId = customerid });
            }
        }
    }
}
