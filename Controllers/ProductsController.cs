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
    public class ProductsController : ControllerQuery
    {
        public ProductsController(IConfiguration config, ILogger<ProductsController> logger):
            base(config, logger) {}

        [HttpGet]
        public async Task<JsonElement> Get()
        {
           return await this.Query("get", this.GetType());
        }
    }
}
