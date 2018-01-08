using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using RedcapService.Models;

namespace RedcapService.Controllers
{
    public class DETController : ApiController
    {
        [HttpPost]
        [ActionName("PostByGUID")]
        public async Task<HttpResponseMessage> PostGuid(RedcapPost redcapPost)
        {
            if (redcapPost != null)
            {
                await EmailNotification.SnedEmail(redcapPost);
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
