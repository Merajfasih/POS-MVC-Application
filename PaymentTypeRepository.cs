using POSMvcapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace POSMvcapp.Repository
{
    public class PaymentTypeRepository
    {
        private InventoryEntities objInventoryEntities;
        public PaymentTypeRepository()
        {
            objInventoryEntities = new InventoryEntities();
        }
        public IEnumerable<SelectListItem> GetAllPaymentType()
        {
            var objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objInventoryEntities.PaymentTypes
                                  select new SelectListItem()
                                  {
                                      Text = obj.PaymentType1,
                                      Value = obj.PaymentTypeId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
}