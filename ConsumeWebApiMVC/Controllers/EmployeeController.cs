using ConsumeWebApiMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ConsumeWebApiMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult GetAllEmployee()
        {
            IEnumerable<EmployeeViewModel> employees = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7140/api/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("/Employee/List");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
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
            }
            return View(employees);
        }
        [HttpGet]
        public async Task<ActionResult> AddEmployee()
        {
            IEnumerable<CategoryViewModel> categories = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7140/api/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
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
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(EmployeeViewModel employee)
        {

            if (ModelState.IsValid)
            {

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7140/api/");
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
            }
            ModelState.AddModelError(string.Empty, "Server error try after some time.");
            return View(employee);
        }

    }
}
