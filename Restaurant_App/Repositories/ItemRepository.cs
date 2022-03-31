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
    public class ItemRepository
    {
        private RestaurantContext _Context;
        public ItemRepository(RestaurantContext context)
        {
            _Context = context;
        }

        public async Task<List<SelectListItem>> GetAll()
        {
            List<Item> items;
            List<SelectListItem> OuputItems = new List<SelectListItem>();

            items = await _Context.Items.ToListAsync();
            foreach (var a in items)
            {
                OuputItems.Add(new SelectListItem()
                {
                    Text = a.Name,
                    Value = a.Id.ToString(),
                    Selected = true
                });
            }

            return OuputItems;
        }

        public Item GetItem(int id)
        {
            var item = _Context.Items.Where(i => i.Id == id).SingleOrDefault();
            return item;
        }

    }
}
