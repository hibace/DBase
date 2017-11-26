using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dota2Stats.Models;
using Dota2Stats.Repositories.ItemStat;
using Dota2Stats.Resources;

namespace Dota2Stats.Controllers
{
    using Middleware;
    using Npgsql;
    using NpgsqlTypes;

    public class ItemStatController : ApiController
    {
        private IItemStatRepository itemStatRepository;
        public ItemStatController(IItemStatRepository itemStatRepository)
        {
            this.itemStatRepository = itemStatRepository;
        }

        // GET: api/ItemStat
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, itemStatRepository.GetAll().Select(o => new ItemStatResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        public HttpResponseMessage Get(int id)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ItemStatResource(itemStatRepository.Get(id)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        //POST api/ItemStat
        public HttpResponseMessage Post([FromBody]ItemStatResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ItemStatResource(itemStatRepository.Insert(value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        //PUT api/ItemStat/5
        public HttpResponseMessage Put(int id, [FromBody]ItemStatResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ItemStatResource(itemStatRepository.Update(id, value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // DELETE api/ItemStat/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                itemStatRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // Get api/ItemStat?timeUsed=100
        public HttpResponseMessage GetItemStatByTimeUsed(int timeUsed)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, itemStatRepository.GetItemStatByTimeUsed(timeUsed).Select(o => new ItemStatResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // Get api/ItemStat?idItem=10
        public HttpResponseMessage GetItemStatByIdItem(int idItem)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, itemStatRepository.GetItemStatByIdItem(idItem).Select(o => new ItemStatResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }
    }
}
