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
    public class PaymentTypeRepository
    {
        private RestaurantContext _Context;
        public PaymentTypeRepository(RestaurantContext context)
        {
            _Context = context;
        }

        public async Task<List<SelectListItem>> GetAll()
        {
            List<PaymentType> paymentTypes;
            List<SelectListItem> OuputpaymentTypes = new List<SelectListItem>();

            paymentTypes = await _Context.PaymentTypes.ToListAsync();
            foreach (var a in paymentTypes)
            {
                OuputpaymentTypes.Add(new SelectListItem()
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                    Selected = true
                });
            }

            return OuputpaymentTypes;
        }
    }
}
