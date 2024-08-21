using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorTicTacToe.Controllers
{
    [ApiController]
    [Route("api/files")]
    public class FileController : ControllerBase
    {
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file.Length > 0)
            {
                var uploadsDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

                // Uploads dosyası yoksa yarat
                if (!Directory.Exists(uploadsDirectory))
                {
                    Directory.CreateDirectory(uploadsDirectory);
                }
                var filePath = Path.Combine("Uploads", file.FileName);
                
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok();
            }
            return BadRequest();
        }
    }
}
