using ConsumeWebApiMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeWebApiMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult GetAllEmployee()
        {
            IEnumerable<EmployeeViewModel> members = null;

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

                    members = readTask.Result;
                }
                else
                {
                    //Error response received   
                    members = Enumerable.Empty<EmployeeViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(members);
        }

    }
}
