﻿using System;
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
    public class Order_ProductController : ControllerQuery
    {
        public Order_ProductController(IConfiguration config, ILogger<Order_ProductController> logger) :
            base(config, logger)
        { }

        [HttpGet("/orderproduct")]
        public async Task<JsonElement> Get()
        {
            return await this.Query("get", this.GetType());
        }
    }
}
