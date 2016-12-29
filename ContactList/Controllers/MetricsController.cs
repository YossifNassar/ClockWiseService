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
        /// Gets the list of metrics
        /// </summary>
        /// <returns>The metrics</returns>
        [HttpGet]
        [SwaggerResponse(HttpStatusCode.OK,
            Type = typeof(IEnumerable<Metric>))]
        [Route("~/metrics")]
        public IEnumerable<Metric> Get()
        {
            return MetricsLogic.GetMetrics();
        }

        /// <summary>
        /// Creates a new metric
        /// </summary>
        /// <param name="contact">The new metric</param>
        /// <returns>The saved metric</returns>
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

        /// <summary>
        /// Deletes the metrics table
        /// </summary>
        /// <param name="contact">The new metric</param>
        /// <returns>The saved metric</returns>
        [HttpDelete]
        [SwaggerResponse(HttpStatusCode.OK,
            Description = "Deleted",
            Type = typeof(String))]
        [Route("~/metrics/table")]
        public String Delete([FromBody] Secret secret)
        {
            if(secret.UserName.Equals("clockWise") && secret.Password.Equals("SCSC123"))
            {
                MetricsLogic.DeleteTable();
                return "Table Deleted!";
            }
            return "No Authentication!";
        }
    }
}
