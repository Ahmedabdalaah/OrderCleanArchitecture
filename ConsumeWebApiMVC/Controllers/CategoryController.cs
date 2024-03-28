using ConsumeWebApiMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeWebApiMVC.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult GetAllCategories()
        {
            IEnumerable<CategoryViewModel> categories = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7140/api/");
                var responseTask = client.GetAsync("/Category/List");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<CategoryViewModel>>();
                    readTask.Wait();
                    categories = readTask.Result;
                }
                else
                {
                    //Error response received   
                    categories = Enumerable.Empty<CategoryViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(categories);
        }
        [HttpGet]
        public async Task<ActionResult> AddCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCategory(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7140/api/");
                    var responseTask = client.PostAsJsonAsync("/Category/Add", category);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAllCategories");
                    }
                }
            }
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            CategoryViewModel category = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7140/api/");
                var responseTask = client.GetAsync("/Category/Add" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CategoryViewModel>();
                    readTask.Wait();
                    category = readTask.Result;
                }
            }
            return View(category);
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7140/api/");
                    HttpResponseMessage response = await client.PutAsJsonAsync("/Category/Update", category);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAllCategories");
                    }
                }
            }
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            CategoryViewModel category = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7140/api/");
                var responseTask = client.GetAsync("/Category/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CategoryViewModel>();
                    readTask.Wait();
                    category = readTask.Result;
                }
            }
            return View(category);
        }
        public async Task<IActionResult> DeleteCategory(CategoryViewModel category)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7140/api/");
                HttpResponseMessage response = await client.DeleteAsync("Category/Category/Delete/" + category.Id);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllCategories");
                }

            }
            return View(category);
        }
    }
}

