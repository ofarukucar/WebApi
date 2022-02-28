using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(string id)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = context.Customers.SingleOrDefault(c => c.CustomerId == id);

                return result.ContactName + "&" + result.Country;
            }                           
        }

        // POST api/values
        public void Post( string customerId, string contractName, string country)
        {
            Customer entity = new Customer { 
                CustomerId = customerId, ContactName = contractName, Country = country };
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
            
        }

        // PUT api/values/5
        public void Put(string customerId, string contractName, string country)
        {
            Customer entity = new Customer
            {
                CustomerId = customerId,
                ContactName = contractName,
                Country = country
            };
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void Delete(string customerId)
        {
               
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(context.Customers.FirstOrDefault(c => c.CustomerId == customerId));
                deletedEntity.State = EntityState.Deleted;                
                context.SaveChanges();
            }
        }
    }
}
