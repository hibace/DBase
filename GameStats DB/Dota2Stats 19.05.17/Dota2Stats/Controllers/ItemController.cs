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
        ItemRepository itemRepository = new ItemRepository();

        // GET: api/Item
        public HttpResponseMessage Get()
        {
            List<Item> items;
            try
            {
                items = itemRepository.GetAll().ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new ItemResource(items[i]).ToModel();
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
            return Request.CreateResponse<IEnumerable<Item>>(HttpStatusCode.OK, items);
        }

        public HttpResponseMessage Get(int id)
        {
            Item item;
            try
            {
                item = new ItemResource(itemRepository.Get(id)).ToModel();
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<Item>(HttpStatusCode.OK, item);
        }

        //POST api/Item
        public HttpResponseMessage Post([FromBody]ItemResource value)
        {
            try
            {
                value = new ItemResource(itemRepository.Insert(value.ToModel()));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<ItemResource>(HttpStatusCode.OK, value);
        }

        //PUT api/Item/5
        public HttpResponseMessage Put(int id, [FromBody]ItemResource value)
        {
            try
            {
                value = new ItemResource(itemRepository.Update(id, value.ToModel()));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<ItemResource>(HttpStatusCode.OK, value);
        }

        // DELETE api/Item/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                itemRepository.Delete(id);
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

        // Get api/Item?name=tango
        public HttpResponseMessage GetItemByName(string name)
        {
            List<Item> items;
            try
            {
                items = itemRepository.GetItemByName(name).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new ItemResource(items[i]).ToModel();
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
            return Request.CreateResponse<List<Item>>(HttpStatusCode.OK, items);
        }

        // Get api/Item?type=move
        public HttpResponseMessage GetItemByType(string type)
        {
            List<Item> items;
            try
            {
                items = itemRepository.GetItemByType(type).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new ItemResource(items[i]).ToModel();
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
            return Request.CreateResponse<List<Item>>(HttpStatusCode.OK, items);
        }
    }
}
