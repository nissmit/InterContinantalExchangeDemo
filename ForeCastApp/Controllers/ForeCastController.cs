using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForeCast.API;
using ForeCastApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ForeCast.Common;

namespace ForeCastApp.Controllers
{
    [Route("/forecast")]
    public class ForeCastController : Controller
    {
        private readonly IForeCastService _foreCastService;

        public ForeCastController(IForeCastServiceFactory foreCastServiceFactory,IDownloadCache downloadCache,IWgribCache wgribCache, IConfiguration configuration)
        {
            var accessData = new AccessData
            {
                Folder = configuration["FilePath"],
                Address = configuration["BucketPath"],
                AccessKey = configuration["AccessKey"],
                PrivateKey = configuration["SecretKey"]
            };
            _foreCastService = foreCastServiceFactory.CreateForeCastService(accessData, downloadCache, wgribCache);
        }
        [HttpGet("{date}/{lat}/{lon}")]
        public async Task<ActionResult<ForeCastResult>> Get(DateTime date,double lat,double lon)
        {
            try
            {
                var result = await _foreCastService.GetForeCastData(date, lat,lon);
                return await Task.FromResult(Ok(new ForeCastResult(result.Temperature.ToCelsius())));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError);

            }
        }
    }
}
