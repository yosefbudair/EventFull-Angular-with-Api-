using LearningHub.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace LearningHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeocodingController : ControllerBase
    {



        [HttpGet]
        public async Task<GeocodingResponse> GetCityName(double Latitude ,double Longitude)
        {
            using (var httpClient = new HttpClient())
            {   

                 var response = await httpClient.GetAsync($"https://us1.locationiq.com/v1/reverse?key=pk.cf9e30637aec93f8bd650e916c7bf968&lat={Latitude}&lon={Longitude}&format=json");



                var stringResult = await response.Content.ReadAsStringAsync();
                var geocodingResponse = JsonConvert.DeserializeObject<GeocodingResponse>(stringResult);


                return geocodingResponse;
            }
        }
    }

   

}

    

