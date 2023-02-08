using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Models;
using ProductManagementSystem.Services;

namespace ProductManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        private IproductRepository productRepository;
        private IFileUpload fileUpload;

        public ProductController(IproductRepository productRepository)
        {
            this.productRepository = productRepository;
            this.fileUpload = new FileUpload();
        }
        //http get request
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            var newproduct = new Product();
            newproduct.Id = productRepository.GetMaxId();
            return View(newproduct);
        }
        public IActionResult About()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Product obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (await fileUpload.UploadFile(file))
                {
                    obj.ImageName = fileUpload.FileName;
                    productRepository.AddProduct(obj);
                    return RedirectToRoute(new { Action = "Index", Controller = "Product" });
                }
                else
                {
                    ViewBag.ErrorMessage = "File upload failed";
                    return View(obj);
                }
            }
            else
            {
                ViewBag.Message = "Error adding employee to the database.";
                return View(obj);
            }
        }
        [Authorize(Roles = "Customer")]
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.Products = productRepository.GetProducts();
            return View(model);
        }
        [Authorize(Roles = "Customer")]
        public IActionResult DisplayAll(int? id)
        {
            var prod=productRepository.GetProduct(id);
            if(prod==null)
            {
                return NotFound();
            }
            return View(prod);

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var prod = productRepository.GetProduct(id);
            return View(prod);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                productRepository.UpdateProduct(obj);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Error editing product";
                return View(obj);
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            productRepository.DeleteProduct(id);
            return RedirectToAction("Index");
        }
        
    }
}
