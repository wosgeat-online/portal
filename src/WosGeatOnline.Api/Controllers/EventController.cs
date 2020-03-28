using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WosGeatOnline.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        [HttpGet("/events")]
        public EventListDto Get(
            [FromQuery(Name = "category")] string category,
            [FromQuery(Name = "q")] string query,
            [FromQuery(Name = "limit")] int limit  = 20
        ) {
            var events = JsonConvert.DeserializeObject<IEnumerable<EventDto>>(System.IO.File.ReadAllText("resources/events.json"));
            if (!string.IsNullOrEmpty(category))
            {
                events = events.Where(e => e.Category == category);
            }
            if (!string.IsNullOrEmpty(query))
            {
                events = events.Where(e => e.Title.Contains(query, StringComparison.OrdinalIgnoreCase) || e.Description.Contains(query, StringComparison.OrdinalIgnoreCase));
            }

            var list = new EventListDto()
            {
                Events = events.OrderByDescending(e => e.TimestampStart).Take(limit)
            };
            return list;
        }

        [HttpGet("/event/{guid}")]
        public EventDto Get(Guid guid)
        {
            return JsonConvert.DeserializeObject<IEnumerable<EventDto>>(System.IO.File.ReadAllText("resources/events.json")).First( e => e.Id == guid);
        }
    }

    public static class StringExtensions
    {
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}
