using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WSRobaSegonaMa.Models;

namespace WSRobaSegonaMa.Controllers
{
    public class DonorController : ApiController
    {
        // GET: api/emails
        [Route("api/emails")]
        public HttpResponseMessage Get()
        {
            var contactes = DonorRepository.GetAllDonors();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contactes);
            return response;
        }
        // GET: api/emailsTot
        [Route("api/emailsTot")]
        public HttpResponseMessage GetTot()
        {
            var telefons = DonorRepository.GetAllDonors();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, telefons);
            return response;
        }

        [Route("api/emailC/{dni:alpha}")]
        public HttpResponseMessage GetEmailByName(string dni)
        {
            var telefons = DonorRepository.SearchDonorsByDni(dni);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, telefons);
            return response;
        }

        // GET: api/email/5
        [Route("api/email/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var telefon = DonorRepository.GetDonor(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, telefon);
            return response;
        }

        // PUT: api/email/5
        [Route("api/email/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody] Donor val)
        {
            var telefon = DonorRepository.UpdateDonor(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, telefon);
            return response;
        }

        // POST: api/email
        [Route("api/email")]
        public HttpResponseMessage Post([FromBody] Donor val)
        {
            var email = DonorRepository.InsertDonor(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, email);
            return response;
        }


        // DELETE: api/email/5
        [Route("api/email/{id?}")]
        public HttpResponseMessage Delete(int id)
        {
            DonorRepository.DeleteDonor(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "S'ha esborrat correctament");
            return response;
        }
    }
}