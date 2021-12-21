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
    public class UserController : ControllerQuery
    {
        public UserController(IConfiguration config, ILogger<UserController> logger):
            base(config, logger) {}
        
        [HttpGet("/user/{userId}")]
        public async Task<JsonElement> Get(int userId)
        {
            return await this.Query("get", this.GetType(), userId);
        }

        [HttpPut("/user")]
        public async Task<JsonElement> Put([FromBody]JsonElement payload)
        {
            return await this.Query("put", this.GetType(), payload: payload);
        }

        [HttpPatch("/user/{userId}")]
        public async Task<JsonElement> Patch([FromBody]JsonElement payload, int userId)
        {
            return await this.Query("patch", this.GetType(), userId, payload);
        }

        [HttpDelete("{userId}")]
        public async Task<JsonElement> Delete(int userId)
        {
            return await this.Query("delete", this.GetType(), userId);
        }
    }
}
