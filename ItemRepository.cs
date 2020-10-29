using POSMvcapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POSMvcapp.Repository
{
    public class ItemRepository
    {
        private InventoryEntities objInventoryEntities;
        public ItemRepository()
        {
            objInventoryEntities = new InventoryEntities();
        }
        public IEnumerable<SelectListItem> GetAllItems()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objInventoryEntities.Items
                                  select new SelectListItem()
                                  {
                                      Text = obj.ItemsName,
                                      Value = obj.Itemsid.ToString(),
                                      Selected = false
                                  }).ToList();
            return objSelectListItems;
        }
    }
}