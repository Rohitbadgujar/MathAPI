using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.Statistics;
using System.Net.Http;

namespace MathAPI.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class MathAPIController : ControllerBase
    {
        private readonly ILogger<MathAPIController> _logger;

        public MathAPIController(ILogger<MathAPIController> logger)
        {
            _logger = logger;
        }

        [Route("min/{quantifier}")]
        [HttpPost]
        public IActionResult Min([FromBody] List<int> numberList, int quantifier)
        {
            if (numberList.Count < quantifier)
            {
                return BadRequest("Quantifier cannot be greater than list size");
            }
            numberList.Sort();
            return Ok(numberList.Take(quantifier).ToList());
        }
        [Route("max/{quantifier}")]
        [HttpPost]
        public IActionResult Max([FromBody] List<int> numberList, int quantifier)
        {
            if (numberList.Count < quantifier)
            {
                return BadRequest("Quantifier cannot be greater than list size");
            }
            numberList.Sort();
            numberList.Reverse();
            return Ok(numberList.Take(quantifier).ToList());
        }
        [Route("avg")]
        [HttpPost]
        public double Avg([FromBody] List<int> numberList)
        {
            return numberList.Count > 0 ? numberList.Average() : 0.0;
        }
        [Route("median")]
        [HttpPost]
        public double Median([FromBody] List<double> numberList)
        {
            var  data = numberList.AsEnumerable();
            return numberList.Count > 0 ? data.Median() : 0.0;
        }

        [Route("percentile/{quantifier}")]
        [HttpPost]
        public double Percentile([FromBody] List<double> numberList, int quantifier)
        {
            numberList.Sort();
            var percentileIndex = (int)Math.Ceiling((double) quantifier / 100 * numberList.Count()) - 1;
            return numberList[percentileIndex];
        }
    }
}
