using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text;

namespace Dream.Web.Controllers
{
    public class UploadFilesController : Controller
    {
        public UploadFilesController(IHostingEnvironment environment)
        {
            Environment = environment;
        }
        public IHostingEnvironment Environment { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();
            //��վ���ϴ���Ŀ¼           
            var uploads = Path.Combine(Environment.WebRootPath, "upload");
            Directory.CreateDirectory(uploads);

            //���ļ�
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    //��ȡ�ļ���չ��
                    var uploadFileExtention = file.FileName.Split('\\').Last();
                    //��Ҫ�����վ��ȫ·��
                    var serverPath = uploads + "/" + uploadFileExtention;
                    using (FileStream fs = new FileStream(serverPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fs);
                    }
                }
            }
            
            return Ok(new { count = files.Count, size, filePath });
        }
    }
}