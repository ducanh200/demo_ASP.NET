using Microsoft.AspNetCore.Mvc;

namespace T2207A_MVC.Controllers
{
    public class UploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile image)
        {
            if (image == null)
            {
                return BadRequest("Vui lòng chọn file");
            }
            string path = "wwwroot/uploads";
            string filename = Guid.NewGuid().ToString() 
                + Path.GetExtension(image.FileName);
            var upload = Path.Combine(Directory.GetCurrentDirectory(),path, filename);
            image.CopyTo(new FileStream(upload,FileMode.Create));
            string url = $"{Request.Scheme}://{Request.Host}/uploads/{filename}";
            return Ok(url);
        }
    }
}
