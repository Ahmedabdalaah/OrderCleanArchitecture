using ConsumeWebApiMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConsumeWebApiMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private ILogger<EmployeeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public EmployeeController(ILogger<EmployeeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        public ActionResult GetAllEmployee()
        {
            IEnumerable<EmployeeViewModel> employees = null;
            var client = _httpClientFactory.CreateClient("OrderApi");
            var responseTask = client.GetAsync("/Employee/List");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<EmployeeViewModel>>();
                readTask.Wait();

                employees = readTask.Result;
            }
            else
            {
                //Error response received   
                employees = Enumerable.Empty<EmployeeViewModel>();
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return View(employees);
        }
        [HttpGet]
        public async Task<ActionResult> AddEmployee()
        {
            IEnumerable<CategoryViewModel> categories = null;
            var client = _httpClientFactory.CreateClient("OrderApi");
            var responseTaskk = client.GetAsync("/Category/List");
            responseTaskk.Wait();

            //To store result of web api response.   
            var resultt = responseTaskk.Result;
            //If success received   
            if (resultt.IsSuccessStatusCode)
            {
                var readTask = resultt.Content.ReadAsAsync<IList<CategoryViewModel>>();
                readTask.Wait();

                categories = readTask.Result;
                SelectList catItem = new SelectList(categories, "Id", "Name", 1);
                ViewBag.catItem = catItem;
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("OrderApi");
                var responseTask = client.PostAsJsonAsync("/Employee/Add", employee);
                responseTask.Wait();
                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllEmployee");
                }
            }
            return View(employee);
        }

        [HttpGet]
        public async Task<ActionResult> EditEmployee(int id)
        {
            EmployeeViewModel employee = null;
            IEnumerable<CategoryViewModel> categories = null;
            var client = _httpClientFactory.CreateClient("OrderApi");
            var responseTask = client.GetAsync("/Employee/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            // category
            var responseTaskk = client.GetAsync("/Category/List");
            responseTaskk.Wait();

            var resultt = responseTaskk.Result;

            //If success received   
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<EmployeeViewModel>();
                readTask.Wait();

                employee = readTask.Result;
                /// category
                /// 
                var readTask2 = resultt.Content.ReadAsAsync<IList<CategoryViewModel>>();
                readTask2.Wait();
                categories = readTask2.Result;
                SelectList catItem = new SelectList(categories, "Id", "Name", employee.CategoryId);
                ViewBag.catItem = catItem;
            }
            else
            {
                //Error response received   
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return View(employee);
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmployee(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("OrderApi");
                HttpResponseMessage response = await client.PutAsJsonAsync("/Employee/Update", employee);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllEmployee");
                }
            }
            return View(employee);
        }
        [HttpGet]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            EmployeeViewModel employee = null;
            var client = _httpClientFactory.CreateClient("OrderApi");
            var responseTask = client.GetAsync("/Employee/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            //If success received   
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<EmployeeViewModel>();
                readTask.Wait();

                employee = readTask.Result;
            }
            else
            {
                //Error response received   
                ModelState.AddModelError(string.Empty, "Server error try after some time.");
            }
            return View(employee);
        }
        public async Task<IActionResult> DeleteEmployee(EmployeeViewModel employee)
        {
            var client = _httpClientFactory.CreateClient("OrderApi");
            HttpResponseMessage response = await client.DeleteAsync("/Employee/Delete/" + employee.Id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllEmployee");
            }
            return View();
        }
    }
}