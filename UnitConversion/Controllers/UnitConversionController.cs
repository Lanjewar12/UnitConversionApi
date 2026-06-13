using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitConversion.Application.Interface;
using UnitConversion.TO;

namespace UnitConversion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitConversionController : ControllerBase
    {
        private readonly IConversionService _conversionService;

        public UnitConversionController(
            IConversionService conversionService)
        {
            _conversionService = conversionService;
        }

        [HttpPost]
        public IActionResult Convert([FromBody] UnitConversionRequest request)
        {
            var result = _conversionService.Convert(request.Category, request.FromUnit, request.ToUnit, request.Value);

            var response = new UnitConversionResponse
            {
                OriginalValue = request.Value,
                FromUnit = request.FromUnit,
                ToUnit = request.ToUnit,
                ConvertedValue = result
            };

            return Ok(response);
        }
    }
}
