using Dapper.CRUD.Data.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Dapper.CRUD.Data.DAL
{
    public class EmployeeDataAccessLayer
    {
        public IConfiguration Configuration;
        private const string CHINOOK_DATABASE = "chinook";
        private const string SELECT_QUERY = "select * from employee";
        public EmployeeDataAccessLayer(IConfiguration configuration)
        {
            Configuration = configuration; //Inject configuration to access Connection string from appsettings.json.
        }

        public async Task<List<Employee>> GetEmployeeAsync()
        {
            try
            {

                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    IEnumerable<Employee> result = await db.QueryAsync<Employee>(SELECT_QUERY);
                    return result.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> GetEmployeeCountAsync()
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                int result = await db.ExecuteScalarAsync<int>("select count(*) from employee");
                return result;
            }
        }


        public async Task AddEmployeeAsync(Employee employee)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
                {
                    db.Open();
                    await db.ExecuteAsync("INSERT INTO employee (FirstName,LastName,Title,ReportsTo,BirthDate,HireDate,Address,City,State,Country,PostalCode,Phone,Fax,Email) " +
                        "VALUES (@FirstName,@LastName,@Title,@ReportsTo,@BirthDate,@HireDate,@Address,@City,@State,@Country,@PostalCode,@Phone,@Fax,@Email)",employee);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("update employee set FirstName=@FirstName,LastName=@LastName,Title=@Title,ReportsTo=@ReportsTo,BirthDate=@BirthDate,HireDate=@HireDate," +
                    "Address=@HireDate,City=@City,State=@State,Country=@Country,PostalCode=@PostalCode,Phone=@Phone,Fax=@Fax,Email=@Email where EmployeeId=@EmployeeId", employee);
            }
        }

        public async Task RemoveEmployeeAsync(int employeeid)
        {
            using (IDbConnection db = new SqlConnection(Configuration.GetConnectionString(CHINOOK_DATABASE)))
            {
                db.Open();
                await db.ExecuteAsync("delete from employee Where EmployeeId=@EmployeeId", new { EmployeeId = employeeid });
            }
        }
    }
}
