using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurant_App.Data;
using Restaurant_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_App.Repositories
{
    public class CustomerRepository
    {
        private RestaurantContext _Context;
        public CustomerRepository(RestaurantContext context)
        {
            _Context = context;
        }

        public async Task<List<SelectListItem>> GetAll()
        {
            List<Customer> customers;
            List<SelectListItem> Outputcustomers = new List<SelectListItem>();

            customers = await _Context.Customers.ToListAsync();
            foreach(var a in customers)
            {
                Outputcustomers.Add(new SelectListItem()
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                    Selected = true
                });
            }

            return Outputcustomers;
        }
    }
}
