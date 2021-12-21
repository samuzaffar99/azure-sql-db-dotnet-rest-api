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
    public class ProductController : ControllerQuery
    {
        public ProductController(IConfiguration config, ILogger<ProductController> logger):
            base(config, logger) {}

        
        [HttpGet("/product/{productId}")]
        public async Task<JsonElement> Get(int productId)
        {
            return await this.Query("get", this.GetType(), productId);
        }

        [HttpPut("/product/")]
        public async Task<JsonElement> Put([FromBody]JsonElement payload)
        {
            return await this.Query("put", this.GetType(), payload: payload);
        }

        [HttpPatch("/product/{productId}")]
        public async Task<JsonElement> Patch([FromBody]JsonElement payload, int productId)
        {
            return await this.Query("patch", this.GetType(), productId, payload);
        }

        [HttpDelete("/product/{productId}")]
        public async Task<JsonElement> Delete(int productId)
        {
            return await this.Query("delete", this.GetType(), productId);
        }
    }
}
