using MongoDB.Driver;
using S13_DPAMongoDB.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S13_DPAMongoDB.API.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerService(ICustomerDatabaseSetting setting)
        {
            var client = new MongoClient(setting.ConnectionString);
            var database = client.GetDatabase(setting.DatabaseName);

            _customers = database
                .GetCollection<Customer>(setting.CustomerCollectionName);
        }
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customers.Find(cust => true).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(string id)
        {
            return await _customers
                .Find<Customer>(cust => cust.Id == id).FirstOrDefaultAsync();
        }



    }
}
