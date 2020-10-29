using POSMvcapp.Models;
using POSMvcapp.Repository;
using POSMvcapp.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POSMvcapp.Controllers
{
    public class HomeController : Controller
    {
        private InventoryEntities objInventoryEntities;
        public HomeController()
        {
            objInventoryEntities = new InventoryEntities();
        }
        // GET: Home
        public ActionResult Index()
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentTypeRepository objPaymentTypeRepository = new PaymentTypeRepository();
            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
            (objCustomerRepository.GetAllCustomers(), objItemRepository.GetAllItems(), objPaymentTypeRepository.GetAllPaymentType());
            return View(objMultipleModels);
        }
        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = (decimal)objInventoryEntities.Items.Single(model => model.Itemsid == itemId).ItemPrice;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewModel)
        {
            OrderRepository objOrderRepository = new OrderRepository();
            objOrderRepository.AddOrder(objOrderViewModel);
            return Json(data: "Your Order has been Sucessfully Placed", JsonRequestBehavior.AllowGet);
        }
    }
}