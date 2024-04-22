using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using OracleProjectMiedterm.Models;
using OracleProjectMiedterm.Service;

namespace OracleProjectMiedterm.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;
        private readonly IWebHostEnvironment _environment;
        public CustomerController(ICustomerService service, IWebHostEnvironment environment)
        {
            _service = service;
            _environment = environment;

        }
        public async Task<IActionResult> Index(string? searchtext = null)
        {
            var cuts = await _service.GetAll(searchtext);

            return View("Index", cuts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Store(Customer customer, IFormFile images)
        {

            if (images != null && images.Length > 0)
            {


                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(images.FileName)}";
                string imagesFullPath = _environment.WebRootPath + "/Customer/" + fileName;

                using (var stream = new FileStream(imagesFullPath, FileMode.Create))
                {
                    await images.CopyToAsync(stream);
                }

                // Save the byte array to the customer object
                customer.Images = fileName; // Assuming "ImageData" is the property in your Customer model to store the image data

            }


            if (!ModelState.IsValid)
            {
                return View("Create", customer);
            }
            if (await _service.Create(customer))
            {

                return RedirectToAction("Index", customer);
            }
            return View("Create", customer);
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int CustomerId)
        {
           
            var cus = await _service.Get(CustomerId);

            return View("Edit", cus);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Customer customer, IFormFile images)
        {




            

            if (images != null)
            {
                // File is uploaded and has content
                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(images.FileName)}";
                string imagesFullPath = Path.Combine(_environment.WebRootPath, "Customer", fileName);

                using (var stream = new FileStream(imagesFullPath, FileMode.Create))
                {
                    await images.CopyToAsync(stream);
                }

                // Save the file name to the customer object
                customer.Images = fileName;
            }
            
            if (!ModelState.IsValid)
            {

                return View("Edit", customer);
            }

            if (await _service.Update(customer))
            {
               
                return RedirectToAction("Index", customer);
            }

            return View("Edit", customer);
        }





        [HttpGet]
        public async Task<IActionResult> Delete(int CustomerId)
        {
            var cus = await _service.Get(CustomerId);
            return View("Delete", cus);
        }

        [HttpPost]
        public async Task<IActionResult> Destroy(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);

            }
            if (await _service.Delete(customer))
            {
                return RedirectToAction("Index");
            }
            return View(customer);
        }


    }


}

