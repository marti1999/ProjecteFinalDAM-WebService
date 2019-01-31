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
    public class AnnouncementController : ApiController
    {
        //GET: api/announcement
        [Route("api/announcements")]
        public HttpResponseMessage getAnnouncements()
        {
            var announcements = AnnouncementRespository.GetAllAnnouncements();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, announcements);
            return response;
        }

        //GET: api/announcement/4
        [Route("api/announcement/{id?}")]
        public HttpResponseMessage getAnnouncementById(int id)
        {
            var announcements = AnnouncementRespository.getAnnouncement(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, announcements);
            return response;
        }

        // PUT: api/announcement/5
        [Route("api/announcement/{id?}")]
        public HttpResponseMessage Put(int id, [FromBody] Announcement val)
        {
            var announcements = AnnouncementRespository.updateAnnouncement(id, val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, announcements);
            return response;
        }

        // POST: api/announcement/
        [Route("api/announcement")]
        public HttpResponseMessage Post([FromBody] Announcement val)
        {
            var announcements = AnnouncementRespository.insertAnnouncement(val);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, announcements);
            return response;
        }

        // DELETE: api/announcement/5
        [Route("api/announcement/{id?}")]
        public HttpResponseMessage Delete(int id)
        {
            AnnouncementRespository.deleteAnnouncement(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }



    }
}