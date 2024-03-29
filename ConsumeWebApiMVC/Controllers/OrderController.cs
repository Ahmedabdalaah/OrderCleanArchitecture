using ConsumeWebApiMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConsumeWebApiMVC.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult GetAllOrders()
        {
            IEnumerable<OrderViewModel> orders = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7140/api/");
                var responseTask = client.GetAsync("/Order/List/");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<OrderViewModel>>();
                    readTask.Wait();
                    orders = readTask.Result;
                }
                else
                {
                    //Error response received   
                    orders = Enumerable.Empty<OrderViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(orders);
        }
        [HttpGet]
        public async Task<ActionResult> AddOrder()
        {
            IEnumerable<EmployeeViewModel> employees = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7140/api/");
                var responseTaskk = client.GetAsync("/Employee/List");
                responseTaskk.Wait();
                var resultt = responseTaskk.Result;
                if (resultt.IsSuccessStatusCode)
                {
                    var readTask = resultt.Content.ReadAsAsync<IList<EmployeeViewModel>>();
                    readTask.Wait();

                    employees = readTask.Result;
                    SelectList catItem = new SelectList(employees, "Id", "Name", 1);
                    ViewBag.catItem = catItem;
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrder(OrderViewModel order)
        {

            if (ModelState.IsValid)
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7140/api/");
                    var responseTask = client.PostAsJsonAsync("/Order/Add/", order);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAllOrders");
                    }
                }
            }
            return View(order);
        }

        [HttpGet]
        public async Task<ActionResult> EditOrder(int id)
        {
            OrderViewModel order = null;
            IEnumerable<EmployeeViewModel> employees = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7140/api/");
                var responseTask = client.GetAsync("/Order/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                // Employee
                var responseTaskk = client.GetAsync("/Employee/List");
                responseTaskk.Wait();

                var resultt = responseTaskk.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<OrderViewModel>();
                    readTask.Wait();

                    order = readTask.Result;
                    /// Employee
                    /// 
                    var readTask2 = resultt.Content.ReadAsAsync<IList<EmployeeViewModel>>();
                    readTask2.Wait();
                    employees = readTask2.Result;
                    SelectList catItem = new SelectList(employees, "Id", "Name", order.EmployeeId);
                    ViewBag.catItem = catItem;
                }
                else
                {
                    //Error response received   
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(order);
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOrder(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7140/api/");
                    HttpResponseMessage response = await client.PutAsJsonAsync("/Order/Update", order);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAllOrders");
                    }
                }
            }
            return View(order);
        }
        [HttpGet]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            OrderViewModel order = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7140/api/");
                var responseTask = client.GetAsync("/Order/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<OrderViewModel>();
                    readTask.Wait();

                    order = readTask.Result;
                }
                else
                {
                    //Error response received   
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(order);
        }
        public async Task<IActionResult> DeleteOrder(OrderViewModel order)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7140/api/");
                HttpResponseMessage response = await client.DeleteAsync("/Order/Delete/" + order.Id);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllOrders");
                }
            }
            return View();
        }
        public async Task<IActionResult> Search()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Search(int? id)
        {
            OrderViewModel order = null;
            using (var client = new HttpClient())
            {
                id = Int32.Parse(HttpContext.Request.Form["code"].ToString());
                client.BaseAddress = new Uri("https://localhost:7140/api/");
                var responseTask = client.GetAsync("/Order/Search/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<OrderViewModel>();
                    readTask.Wait();
                    order = readTask.Result;
                    ViewBag.Message = order;
                    if (order != null)
                    {

                    }
                }
                else
                {
                    //Error response received   
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(order);
        }
    }
}
