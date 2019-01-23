﻿using System;
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
        // GET: api/donors
        [Route("api/donors")]
        public HttpResponseMessage Get()
        {
            var donors = DonorRepository.GetAllDonors();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, donors);
            return response;
        }
        // GET: api/donorsTot
        [Route("api/donorsTot")]
        public HttpResponseMessage GetTot()
        {
            var donors = DonorRepository.GetAllDonors();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, donors);
            return response;
        }
        //GET: api/donor/65432343T
        [Route("api/donor/{dni:alpha}")]
        public HttpResponseMessage GetEmailByName(string dni)
        {
            var donors = DonorRepository.SearchDonorsByDni(dni);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, donors);
            return response;
        }

        // GET: api/donor/5
        [Route("api/donor/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var donors = DonorRepository.GetDonor(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, donors);
            return response;
        }

        // PUT: api/donor/5
        [Route("api/donor/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody] Donor val)
        {
            var donors = DonorRepository.UpdateDonor(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, donors);
            return response;
        }

        // POST: api/donor
        [Route("api/donor")]
        public HttpResponseMessage Post([FromBody] Donor val)
        {
            var donors = DonorRepository.InsertDonor(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, donors);
            return response;
        }


        // DELETE: api/donor/5
        [Route("api/donor/{id?}")]
        public HttpResponseMessage Delete(String id)
        {
            DonorRepository.DeleteDonor(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "S'ha esborrat correctament");
            return response;
        }
    }
}