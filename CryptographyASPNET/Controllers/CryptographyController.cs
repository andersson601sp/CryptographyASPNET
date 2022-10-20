using CryptographyASPNET.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CryptographyASPNET.Helper.Cryptography;

namespace CryptographyASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptographyController : ControllerBase
    {
        private readonly ILogger<CryptographyController> _logger;

        public CryptographyController(ILogger<CryptographyController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("PostEncrypt")]
        public ActionResult<Response> PostEncrypt([FromBody] Resquest resquest)
        {
            Response result = new Response { Value = EncryptDecrypt.Encrypt(resquest.Value) };
            return result;
        }

        [HttpPost]
        [Route("PostDecrypt")]
        public ActionResult<Response> PostDecrypt([FromBody] Resquest resquest)
        {
            Response result = new Response { Value = EncryptDecrypt.Decrypt(resquest.Value) };
            return result;
        }
    }
}
