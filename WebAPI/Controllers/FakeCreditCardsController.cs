using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakeCreditCardsController : ControllerBase
    {
        IFakeCreditCardService _fakeCreditCardService;

        public FakeCreditCardsController(IFakeCreditCardService fakeCreditCardService)
        {
            _fakeCreditCardService = fakeCreditCardService;
        }

        [HttpPost("add")]
        public IActionResult Add(FakeCreditCard fakeCreditCard)
        {
            var result = _fakeCreditCardService.Add(fakeCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(FakeCreditCard fakeCreditCard)
        {
            var result = _fakeCreditCardService.Delete(fakeCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(FakeCreditCard fakeCreditCard)
        {
            var result = _fakeCreditCardService.Update(fakeCreditCard);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _fakeCreditCardService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _fakeCreditCardService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
