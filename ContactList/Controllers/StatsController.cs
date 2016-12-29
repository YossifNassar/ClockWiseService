using System;
using Stats.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace ContactList.Controllers
{
    public class StatsController : ApiController
    {
        /// <summary>
        /// Gets the stats
        /// </summary>
        /// <returns>The stats</returns>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK,
            Type = typeof(IEnumerable<Stat>))]
        [Route("~/stats")]
        public IEnumerable<Stat> Get()
        {
            List<Stat> stats = new List<Stat>();
            for(int i=0; i < 10; i++)
            {
                stats.Add(new Stat { SleepHours = i });
            }
            return stats;
        }

    }
}
