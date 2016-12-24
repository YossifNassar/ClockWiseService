using System;
using Metrics.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Swashbuckle.Swagger.Annotations;

namespace ContactList.Controllers
{
    public class MetricsController : ApiController
    {
        public MetricsController()
        {
            MetricsLogic.CreateMetricsTable();
        }

        /// <summary>
        /// Gets the list of contacts
        /// </summary>
        /// <returns>The contacts</returns>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK,
            Type = typeof(IEnumerable<Metric>))]
        [Route("~/metrics")]
        public IEnumerable<Metric> Get()
        {
            return MetricsLogic.GetMetrics();
        }

        /// <summary>
        /// Creates a new contact
        /// </summary>
        /// <param name="contact">The new contact</param>
        /// <returns>The saved contact</returns>
        [HttpPost]
        [SwaggerResponse(HttpStatusCode.Created,
            Description = "Created",
            Type = typeof(Metric))]
        [Route("~/metrics")]
        public Metric Post([FromBody] Metric metric)
        {
            MetricsLogic.AddMetric(metric);
            return metric;
        }
    }
}
