using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace AzureSamples.AzureSQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerQuery
    {
        public OrderController(IConfiguration config, ILogger<OrderController> logger):
            base(config, logger) {}
        
        [HttpGet("/order/{orderId}")]
        public async Task<JsonElement> Get(int orderId)
        {
            return await this.Query("get", this.GetType(), orderId);
        }

        [HttpPut("/order")]
        public async Task<JsonElement> Put([FromBody]JsonElement payload)
        {
            return await this.Query("put", this.GetType(), payload: payload);
        }

        [HttpPatch("/order/{orderId}")]
        public async Task<JsonElement> Patch([FromBody]JsonElement payload, int orderId)
        {
            return await this.Query("patch", this.GetType(), orderId, payload);
        }

        [HttpDelete("/order/{orderId}")]
        public async Task<JsonElement> Delete(int orderId)
        {
            return await this.Query("delete", this.GetType(), orderId);
        }
    }
}
