using POSMvcapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using POSMvcapp.ViewModel;
using System.Data.Entity;
using System.Web.Util;

namespace POSMvcapp.Repository
{

    public class OrderRepository
    {
        private InventoryEntities objInventoryEntities;
        public OrderRepository()
        {
            objInventoryEntities = new InventoryEntities();
        }

        public object Transaction { get; private set; }

        public bool AddOrder(OrderViewModel objOrderViewModel)
        {
            Order objOrder = new Order();
            objOrder.CustomerID = objOrderViewModel.CustomerID;
            objOrder.FinalTotal = objOrderViewModel.FinalTotal;
            objOrder.OrderDate = DateTime.Now;
            objOrder.PaymentType = objOrderViewModel.PaymentType;
            objInventoryEntities.Orders.Add(objOrder);
            objInventoryEntities.SaveChanges();
            int OrderId = objOrder.OrderId;

            foreach (var item in objOrderViewModel.ListOfOrderDetailViewModel)
            {
                OrderDetail objOrderDetail = new OrderDetail();
                objOrderDetail.OrderId = OrderId;
                objOrderDetail.Discount = item.Discount;
                objOrderDetail.ItemId = item.ItemId;
                objOrderDetail.Total = item.Total;
                objOrderDetail.UnitPrice = item.UnitPrice;
                objOrderDetail.Quantity = item.Quantity;
                objInventoryEntities.OrderDetails.Add(objOrderDetail);
                objInventoryEntities.SaveChanges();

                Transition objTransition = new Transition();
                objTransition.ItemId = item.ItemId;
                objTransition.Quantity = (-1)*item.Quantity;
                objTransition.TransactionDate = DateTime.Now;
                objTransition.Type = 2;
                objInventoryEntities.Transitions.Add(objTransition);
                objInventoryEntities.SaveChanges();

            }
            return true;
        }
    }
}