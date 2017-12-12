using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dota2Stats.Models;
using Dota2Stats.Repositories.Item;
using Dota2Stats.Resources;

namespace Dota2Stats.Controllers
{
    using Middleware;
    using Npgsql;
    using NpgsqlTypes;

    public class ItemController : ApiController
    {
        private IItemRepository itemRepository;
        public ItemController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        // GET: api/Item
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, itemRepository.GetAll().Select(o => new ItemResource(o)));
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
                return Request.CreateResponse(HttpStatusCode.OK, new ItemResource(itemRepository.Get(id)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        //POST api/Item
        public HttpResponseMessage Post([FromBody]ItemResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ItemResource(itemRepository.Insert(value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        //PUT api/Item/5
        public HttpResponseMessage Put(int id, [FromBody]ItemResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ItemResource(itemRepository.Update(id, value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // DELETE api/Item/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                itemRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // Get api/Item?name=tango
        public HttpResponseMessage GetItemByName(string name)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, itemRepository.GetItemByName(name).Select(o => new ItemResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // Get api/Item?type=move
        public HttpResponseMessage GetItemByType(string type)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, itemRepository.GetItemByType(type).Select(o => new ItemResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }
    }
}
