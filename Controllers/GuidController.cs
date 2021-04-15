using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public IEnumerable<string> Get([FromQuery] bool upperCase = false, [FromQuery] bool shortUid = false, [FromQuery] bool registryFormat = false)
        {
            return GenerateGuids(upperCase: upperCase,
                                 shortUid: shortUid,
                                 registryFormat: registryFormat);
        }

        [HttpGet]
        [Route("{number}")]
        public IEnumerable<string> Get([FromRoute]int number, [FromQuery] bool upperCase = false, [FromQuery] bool shortUid = false, [FromQuery] bool registryFormat = false)
        {
            return GenerateGuids(number: number,
                                 upperCase: upperCase,
                                 shortUid: shortUid,
                                 registryFormat: registryFormat);
        }


        private IEnumerable<string> GenerateGuids(int number = 1, bool upperCase = false, bool shortUid = false, bool registryFormat = false)
        {
            return Enumerable.Range(1, number <= 100 ? number : 100)
                .Select(index => GetGuid(upperCase, shortUid, registryFormat))
                .ToArray();
        }

        private string GetGuid(bool upperCase = false, bool shortUid = false, bool registryFormat = false)
        {
            var guid = Guid.NewGuid();
            var uuid = guid.ToString();

            if (shortUid)
            {
                return Regex.Replace(Convert.ToBase64String(guid.ToByteArray()), "[/+=]", "");
            }

            if (upperCase)
            {
                uuid = uuid.ToUpper();
            }

            if (registryFormat)
            {
                uuid = "{" + $"{uuid}" + "}";
            }

            return uuid;
        }
    }
}
