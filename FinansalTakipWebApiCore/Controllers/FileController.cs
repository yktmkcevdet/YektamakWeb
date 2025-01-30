using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/File")]
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public FileController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost("ProcessDirectory")]
        public IActionResult ProcessDirectory([FromForm] IFormFile file)
        {
            // 1. Dosyanın geçici bir dizine kaydedilmesi
            var uploadsPath = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }

            var filePath = Path.Combine(uploadsPath, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            // 2. Dosyanın bulunduğu dizin ve alt dizinlerde PDF'leri tarama
            var directory = Path.GetDirectoryName(filePath); // Dosyanın bulunduğu dizin
            var pdfFiles = Directory.GetFiles(directory, "*.pdf", SearchOption.AllDirectories);

            // 3. PDF dosyalarını veritabanına kaydetme (Örnek)
            foreach (var pdfFile in pdfFiles)
            {
                Console.WriteLine($"Found PDF: {pdfFile}");
                // Burada PDF dosyasıyla ilgili işlemleri gerçekleştirebilirsiniz
                // Örneğin, dosya adı ve yolu gibi bilgileri veritabanına kaydedebilirsiniz.
            }

            return Ok(new { message = "PDF files processed successfully.", pdfCount = pdfFiles.Length });
        }
    }
}
