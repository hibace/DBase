using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dota2Stats.Models;
using Dota2Stats.Repositories.ItemTemp;
using Dota2Stats.Resources;

namespace Dota2Stats.Controllers
{
    using Middleware;
    using Npgsql;
    using NpgsqlTypes;

    public class ItemTempController : ApiController
    {
        private IItemTempRepository itemTempRepository;
        public ItemTempController(IItemTempRepository itemTempRepository)
        {
            this.itemTempRepository = itemTempRepository;
        }

        // GET: api/ItemTemp
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, itemTempRepository.GetAll().Select(o => new ItemTempResource(o)));
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
                return Request.CreateResponse(HttpStatusCode.OK, new ItemTempResource(itemTempRepository.Get(id)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        //POST api/ItemTemp
        public HttpResponseMessage Post([FromBody]ItemTempResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ItemTempResource(itemTempRepository.Insert(value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        //PUT api/ItemTemp/5
        public HttpResponseMessage Put(int id, [FromBody]ItemTempResource value)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new ItemTempResource(itemTempRepository.Update(id, value.ToModel())));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // DELETE api/ItemTemp/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                itemTempRepository.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }
        
        // Get api/ItemTemp?idMainTemp=10
        public HttpResponseMessage GetItemTempByIdMainTemp(int idMainTemp)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, itemTempRepository.GetItemTempByIdMainTemp(idMainTemp).Select(o => new ItemTempResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }

        // Get api/ItemTemp?idItem=10
        public HttpResponseMessage GetItemTempByIdItem(int idItem)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, itemTempRepository.GetItemTempByIdItem(idItem).Select(o => new ItemTempResource(o)));
            }
            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, exc.ToString());
            }
        }
    }
}
