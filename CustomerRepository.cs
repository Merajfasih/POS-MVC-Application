using POSMvcapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POSMvcapp.Repository
{
    public class CustomerRepository
    {
        private InventoryEntities objInventoryEntities;
        public CustomerRepository()
        {
            objInventoryEntities = new InventoryEntities();
        }
        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objInventoryEntities.Customers
                                  select new SelectListItem()
                                  {
                                      Text = obj.CustomerName,
                                      Value = obj.Customerid.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
}