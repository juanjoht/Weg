using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WegGridCore.Core;
using WegGridCore.Data;
using WegGridCore.Models;

namespace WegGridTest
{
    public class OrderTest
    {
        private readonly IOrderRepository _orderRepository;

        public OrderTest(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository; 
        }

        [Fact]
        public async void SaveOrderOK()
        {
            OrderModel order = new OrderModel();
            order.TotalLongFence = 45.7; 
            order.HeightFenceId = 1;
            order.ColorFenceId = 2;
            order.OrderDate = DateTime.Now;
            order.DifferenceFenceGrid = 0.3;
            order.TotalLongGrid = 42.5;


            var saveProper = await this._orderRepository.Save(order);
            Assert.True(saveProper);
        }



    }
}
