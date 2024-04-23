using Manlika_WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace Manlika_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : Controller
    {
        //-----------------------------------------------------------------//
        //-----------------3. ทำ Web API โดยใช้ .net and C# -----------------//
        //-----------------------------------------------------------------//

        private readonly RestClient client;
        private const string URL = "https://api.nbp.pl/api/exchangerates/rates/c/jpy/2024-04-22/?format=json";
        public CurrencyController()
        {
            client = new RestClient();
            client.Timeout = -1;
        }
        [Authorize]
        [Route("GetCurrency")]
        [HttpGet]
        public IActionResult GetCustomerOrderSummary()
        {
            string strError = "";
            try
            {
                Uri uri = new Uri(URL);
                client.BaseUrl = uri;

                Response returnResp = new Response();

                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);

                returnResp.IsSuccessful = response.IsSuccessful;
                returnResp.Content = response.Content;
                returnResp.ErrorMessage = response.ErrorMessage;

                if (returnResp.IsSuccessful)
                {
                    var currencyResponseData = JsonConvert.DeserializeObject<CurrencyResponseData>(returnResp.Content, new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), Formatting = Formatting.Indented });
                    Currency currency = new Currency();
                    currency.url = URL;
                    currency.method = "GET";
                    currency.response = currencyResponseData;

                    return Ok(currency);
                }

            }
            catch
            {
                throw;
            }
            

            return Ok(strError);
        }

        
    }
}
