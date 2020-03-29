using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WosGeatOnline.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly ILogger<ImageController> _logger;

        public ImageController(ILogger<ImageController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/image/{guid}")]
        public IActionResult GetImage(Guid guid)
        {
            var json = System.IO.File.ReadAllText("resources/events.json");
            var eventDto = JsonConvert.DeserializeObject<IEnumerable<EventDto>>(json).FirstOrDefault( e => e.Id == guid);

            if (eventDto == null || string.IsNullOrEmpty(eventDto.Image))
            {
                return NotFound();
            }

            var stream = new FileStream("resources/"+eventDto.Image, FileMode.Open);
            return new FileStreamResult(stream, "image/jpeg");
        }
    }
}
