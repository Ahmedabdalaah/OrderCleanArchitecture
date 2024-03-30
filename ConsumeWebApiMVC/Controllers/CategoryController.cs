using ConsumeWebApiMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeWebApiMVC.Controllers
{
    public class CategoryController : Controller
    {
        private ILogger<CategoryController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(ILogger<CategoryController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult GetAllCategories()
        {
            IEnumerable<CategoryViewModel> categories = null;
            var client = _httpClientFactory.CreateClient("OrderApi");
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
                var client = _httpClientFactory.CreateClient("OrderApi");
                var responseTask = client.PostAsJsonAsync("/Category/Add", category);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllCategories");
                }
            }
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> EditCategory(int id)
        {
            CategoryViewModel category = null;
            var client = _httpClientFactory.CreateClient("OrderApi");
            var responseTask = client.GetAsync("/Category/Add" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<CategoryViewModel>();
                readTask.Wait();
                category = readTask.Result;
            }
            return View(category);
        }
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient("OrderApi");
                HttpResponseMessage response = await client.PutAsJsonAsync("/Category/Update", category);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAllCategories");
                }
            }
            return View(category);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            CategoryViewModel category = null;
            var client = _httpClientFactory.CreateClient("OrderApi");
            var responseTask = client.GetAsync("/Category/" + id);
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<CategoryViewModel>();
                readTask.Wait();
                category = readTask.Result;
            }
            return View(category);
        }
        public async Task<IActionResult> DeleteCategory(CategoryViewModel category)
        {
            var client = _httpClientFactory.CreateClient("OrderApi");
            HttpResponseMessage response = await client.DeleteAsync("Category/Category/Delete/" + category.Id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllCategories");
            }
            return View(category);
        }
    }
}

