using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuidController : ControllerBase
    {
        public GuidController()
        {
        }

        [HttpGet]
        public IEnumerable<string> Get([FromQuery] bool upperCase = false, [FromQuery] bool base64Encode = false, [FromQuery] bool registryFormat = false)
        {
            return GenerateGuids(upperCase: upperCase,
                                 base64Encode: base64Encode,
                                 registryFormat: registryFormat);
        }

        [HttpGet]
        [Route("{number}")]
        public IEnumerable<string> Get([FromRoute]int number, [FromQuery] bool upperCase = false, [FromQuery] bool base64Encode = false, [FromQuery] bool registryFormat = false)
        {
            return GenerateGuids(number: number,
                                 upperCase: upperCase,
                                 base64Encode: base64Encode,
                                 registryFormat: registryFormat);
        }


        private IEnumerable<string> GenerateGuids(int number = 1, bool upperCase = false, bool base64Encode = false, bool registryFormat = false)
        {
            return Enumerable.Range(1, number <= 100 ? number : 100)
                .Select(index => GetGuid(upperCase, base64Encode, registryFormat))
                .ToArray();
        }

        private string GetGuid(bool upperCase = false, bool base64Encode = false, bool registryFormat = false)
        {
            var guid = Guid.NewGuid().ToString();

            if (upperCase)
            {
                guid = guid.ToUpper();
            }

            if (registryFormat)
            {
                guid = "{" + $"{guid}" + "}";
            }

            if (base64Encode)
            {
                var bytes = Encoding.UTF8.GetBytes(guid);
                guid = Convert.ToBase64String(bytes).TrimEnd('=');
            }

            return guid;
        }
    }
}
