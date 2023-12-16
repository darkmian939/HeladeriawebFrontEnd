using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Heladeria.Models.DTO;
using Heladeria.Repository;
using Heladeria.Repository.Interfaces;
using Heladeria.Utilities;
using Heladeriag.Repository;
using global::Heladeria.Utilities;

namespace Heladeria.Controllers
{
    public class OrdersController : Controller
    {

        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            this._orderRepository = orderRepository;
        }
        // GET: OrdersController
        public ActionResult Index()
        {
            return View(new OrderDTO() { });
        }

        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                //Llama al repositorio
                var data = await _orderRepository.GetAllAsync(UrlResources.UrlBase + UrlResources.UrlOrders);
                return Json(new { data });
            }
            catch (Exception ex)
            {
                // Log the exception, handle it, or return an error message as needed
                return StatusCode(500, "Internal Server Error. Please try again later.");
            }
        }


        // GET: OrdersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrdersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderDTO order)
        {
            try
            {
                await _orderRepository.PostAsync(UrlResources.UrlBase + UrlResources.UrlOrders, order);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var order = new OrderDTO();

            order = await _orderRepository.GetByIdAsync(UrlResources.UrlBase + UrlResources.UrlOrders, id.GetValueOrDefault());
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OrderDTO order)
        {
            if (ModelState.IsValid)
            {
                await _orderRepository.UpdateAsync(UrlResources.UrlBase + UrlResources.UrlCustomers + order.Id, order);
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        // GET: OrdersController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderRepository.GetByIdAsync(UrlResources.UrlBase + UrlResources.UrlOrders, id);
            if (order == null)
            {
                return Json(new { success = false, message = "Orden no encontrada." });
            }

            var deleteResult = await _orderRepository.DeleteAsync(UrlResources.UrlBase + UrlResources.UrlOrders, id);
            if (deleteResult)
            {
                return Json(new { success = true, message = "Orden eliminado correctamente." });
            }
            else
            {
                return Json(new { success = false, message = "Error al eliminar la orden." });
            }
        }
    }
}