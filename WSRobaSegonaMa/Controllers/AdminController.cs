using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WSRobaSegonaMa.Models;

namespace WSRobaSegonaMa.Controllers
{
    public class AdminController : ApiController
    {


        // GET: api/administrators
        [Route("api/administrators")]
        public HttpResponseMessage Get()
        {
            var admins = AdminRepository.GetAllAdministrators();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, admins);
            return response;
        }

        // GET: api/administratorsTot
        [Route("api/administratorsTot")]
        public HttpResponseMessage GetTot()
        {
            var admins = AdminRepository.GetAllAdministrators();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, admins);
            return response;
        }

        //GET: api/administrator/65432343-TSAS
        [Route("api/administrator/{code:alpha}")]
        public HttpResponseMessage GetAdministratorByName(string code)
        {
            var admins = AdminRepository.SearchAdministratorsByCode(code);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, admins);
            return response;
        }

        //GET: api/administrator/admin@admin.com
        [Route("api/administratorEmail")]
        public HttpResponseMessage PostAdministratorByEmail([FromBody]string email)
        {
            var admin = AdminRepository.SearchAdministratorsByEmail(email);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, admin);
            return response;
        }

        // GET: api/administrator/5
        [Route("api/administrator/{id?}")]
        public HttpResponseMessage Get(int id)
        {
            var admins = AdminRepository.GetAdministrator(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, admins);
            return response;
        }

        // PUT: api/administrator/5
        [Route("api/administrator/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody] Administrator val)
        {
            var admins = AdminRepository.UpdateAdministrator(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, admins);
            return response;
        }

        // PUT: api/administrator/updlang/
        [Route("api/administrator/updlang")]
        public HttpResponseMessage PutLang([FromBody] String idAndLang)
        {

            int id = 0;
            string lang = "";

            String[] values = idAndLang.Split('-');

            id = int.Parse(values[0]);
            lang = values[1];

            HttpResponseMessage response;
            if (!lang.Equals("") && id != 0)
            {
                AdminRepository.SetAdminLang(id, lang);
                response = Request.CreateResponse(HttpStatusCode.OK, true);
            }
            else
            {
                //response = Request.CreateResponse(HttpStatusCode.Conflict, false);

                response = null;
            }

            return response;
        }

        // POST: api/administrator/login
        [Route("api/administrator/login")]
        public HttpResponseMessage PostLogin([FromBody] Administrator val)
        {
            var canLogin = AdminRepository.CanLogin(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, canLogin);
            return response;
        }

        // POST: api/administrator
        [Route("api/administrator")]
        public HttpResponseMessage Post([FromBody] Administrator val)
        {
            var admins = AdminRepository.InsertAdministrator(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, admins);
            return response;
        }

        // DELETE: api/administrator/5
        [Route("api/administrator/{id?}")]
        public HttpResponseMessage Delete(String id)
        {
            AdminRepository.DeleteAdministrator(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}