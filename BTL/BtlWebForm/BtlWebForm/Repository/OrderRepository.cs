using BtlWebForm.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BtlWebForm.Repository
{
    public class OrderRepository
    {
        FileIO file = new FileIO();
        public List<OrderEntity> FindAllOrder()
        {
            return JsonConvert.DeserializeObject<List<OrderEntity>>(file.ReadFileJson(Constant.DATA_ORDER));
        }
        public bool SaveOrder(OrderEntity order)
        {
            List<OrderEntity> orders = FindAllOrder();
            if (orders == null)
                orders = new List<OrderEntity>();
            orders.Add(order);
            if (file.WriteFileJson(Constant.DATA_ORDER, JsonConvert.SerializeObject(orders)))
                return true;
            return false;
        }

    }
}