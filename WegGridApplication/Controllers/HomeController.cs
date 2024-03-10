using System;
using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WegGridApplication.Models;
using WegGridCore.Core;
using WegGridCore.Data;
using WegGridCore.Models;

namespace WegGridApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHeightRepository _heightRepository;
        private readonly IColorRepository _colorRepository;
        private readonly ICalculateFactory _calculateFactory;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private const double LONGGRID = 2.5;

        public HomeController(ILogger<HomeController> logger, IHeightRepository heightRepository, IColorRepository colorRepository, ICalculateFactory calculateFactory, IOrderRepository orderRepository, IMapper mapper)
        {
            _logger = logger;
            _heightRepository = heightRepository;
            _colorRepository = colorRepository;
            _calculateFactory = calculateFactory;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> OrderAsync()
        {
            IEnumerable<HeightFenceModel> heights = await _heightRepository.Get();
            IEnumerable<ColorFenceModel> colors = await _colorRepository.Get();
            ViewBag.heightsList = new SelectList(heights.Select(x=>  new { x.HeightFenceId, Name = x.Name + " Mts" }), "HeightFenceId", "Name");
            ViewBag.colorsList = new SelectList(colors, "ColorFenceId", "Name");
            return View();
        }
        

        [HttpPost]
        public async Task<JsonResult> setOrder(string orderRequestJson)
        {
            OrderRequestModel result = JsonConvert.DeserializeObject<OrderRequestModel>(orderRequestJson);
            var saveProper = true;
            OrderResultModel order = new OrderResultModel();
            try
            {
                order.TotalLongFence = result.TotalLongFence;
                order.HeightFenceId = result.HeightFenceId;
                order.ColorFenceId = result.ColorFenceId;
                order.OrderDate = DateTime.Now;
                order.TotalLongGrid = _calculateFactory.GetInstanceByType(CalculateType.TotalGrid).Calculate(result.TotalLongFence, LONGGRID);
                order.DifferenceFenceGrid = _calculateFactory.GetInstanceByType(CalculateType.Difference).Calculate(result.TotalLongFence, order.TotalLongGrid);
                var entity = _mapper.Map<OrderModel>(order);
                saveProper = await _orderRepository.Save(entity);
                order.AmountGrid = _calculateFactory.GetInstanceByType(CalculateType.AmountGrid).Calculate(result.TotalLongFence, LONGGRID);
                order.OrderList = (List<WegGridCore.Dto.OrderDto>)await _orderRepository.GetOrders();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            return Json(saveProper ? order: string.Empty);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
