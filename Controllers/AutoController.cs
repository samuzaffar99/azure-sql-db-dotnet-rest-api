using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace AzureSamples.AzureSQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoController : ControllerQuery
    {
        public AutoController(IConfiguration config, ILogger<AutoController> logger):
            base(config, logger) {}

        [HttpPost("/auth/login")]
        public async Task<JsonElement> Login([FromBody]JsonElement payload)
        {
            return await this.CustomQuery("login", payload: payload);
        }

        [HttpPost("/auth/register")]
        public async Task<JsonElement> Register([FromBody]JsonElement payload)
        {
            return await this.CustomQuery("register", payload: payload);
        }

        [HttpPost("/order/confirm")]
        public async Task<JsonElement> ConfirmOrder([FromBody]JsonElement payload, int customerId)
        {
            return await this.CustomQuery("confirm_order", customerId, payload: payload);
        }

        [HttpGet("/customer/{customerId}/orders")]
        public async Task<JsonElement> GetCustomerOrders(int customerId)
        {
            return await this.CustomQuery("get_customer_orders", customerId);
        }

        [HttpGet("/product/{productId}/reviews")]
        public async Task<JsonElement> GetProductReviews(int productId)
        {
            return await this.CustomQuery("get_productreviews", productId);
        }

        [HttpPost("/product/{productId}/reviews")]
        public async Task<JsonElement> AddProductReview([FromBody]JsonElement payload, int productId)
        {
            return await this.CustomQuery("add_productreview", productId, payload:payload);
        }

        // [HttpPatch("/customer/{customerId}")]
        // public async Task<JsonElement> Patch([FromBody]JsonElement payload, int customerId)
        // {
        //     return await this.Query("patch", this.GetType(), customerId, payload);
        // }
    }
}
