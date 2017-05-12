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
        ItemStatRepository itemStatRepository = new ItemStatRepository();

        // GET: api/ItemStat
        public HttpResponseMessage Get()
        {
            List<ItemStat> items;
            try
            {
                items = itemStatRepository.GetAll().ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new ItemStatResource(items[i]).ToModel();
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<IEnumerable<ItemStat>>(HttpStatusCode.OK, items);
        }

        public HttpResponseMessage Get(int id)
        {
            ItemStat item;
            try
            {
                item = new ItemStatResource(itemStatRepository.Get(id)).ToModel();
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<ItemStat>(HttpStatusCode.OK, item);
        }

        //POST api/ItemStat
        public HttpResponseMessage Post([FromBody]ItemStatResource value)
        {
            try
            {
                value = new ItemStatResource(itemStatRepository.Insert(value.ToModel()));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<ItemStatResource>(HttpStatusCode.OK, value);
        }

        //PUT api/ItemStat/5
        public HttpResponseMessage Put(int id, [FromBody]ItemStatResource value)
        {
            try
            {
                value = new ItemStatResource(itemStatRepository.Update(id, value.ToModel()));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<ItemStatResource>(HttpStatusCode.OK, value);
        }

        // DELETE api/ItemStat/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                itemStatRepository.Delete(id);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// ////
        /// </summary>

        // Get api/ItemStat?timeUsed=100
        public HttpResponseMessage GetItemStatByTimeUsed(int timeUsed)
        {
            List<ItemStat> items;
            try
            {
                items = itemStatRepository.GetItemStatByTimeUsed(timeUsed).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new ItemStatResource(items[i]).ToModel();
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<List<ItemStat>>(HttpStatusCode.OK, items);
        }

        // Get api/ItemStat?idItem=10
        public HttpResponseMessage GetItemStatByIdItem(int idItem)
        {
            List<ItemStat> items;
            try
            {
                items = itemStatRepository.GetItemStatByIdItem(idItem).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new ItemStatResource(items[i]).ToModel();
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<List<ItemStat>>(HttpStatusCode.OK, items);
        }
    }
}
