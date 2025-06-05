using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OBAWebAPI.Framework.Domain.Helpers;
using OBAWebAPI.Framework.Domain.Models;
using OBAWebAPI.Framework.Service.Services;
using System.Net;

namespace OBAWebAPI.Framework.ApiResponse.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleService _exampleService;

        public ExampleController(IExampleService exampleService)
        {
            _exampleService = exampleService;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(decimal[]), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<decimal[]> GetDecreaseGraduate(int value) 
        {
            var res = await _exampleService.GetDecreaseGraduate(value);
            return res;
        }

        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(IEnumerable<ExampleModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<IEnumerable<ExampleModel>> GetData()
        {
            var res = await _exampleService.GetData();
            return res;
        }
    }
}
