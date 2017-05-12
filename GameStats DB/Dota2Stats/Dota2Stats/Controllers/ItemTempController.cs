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
        ItemTempRepository itemTempRepository = new ItemTempRepository();

        // GET: api/ItemTemp
        public HttpResponseMessage Get()
        {
            List<ItemTemp> items;
            try
            {
                items = itemTempRepository.GetAll().ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new ItemTempResource(items[i]).ToModel();
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
            return Request.CreateResponse<IEnumerable<ItemTemp>>(HttpStatusCode.OK, items);
        }

        public HttpResponseMessage Get(int id)
        {
            ItemTemp item;
            try
            {
                item = new ItemTempResource(itemTempRepository.Get(id)).ToModel();
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<ItemTemp>(HttpStatusCode.OK, item);
        }

        //POST api/ItemTemp
        public HttpResponseMessage Post([FromBody]ItemTempResource value)
        {
            try
            {
                value = new ItemTempResource(itemTempRepository.Insert(value.ToModel()));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<ItemTempResource>(HttpStatusCode.OK, value);
        }

        //PUT api/ItemTemp/5
        public HttpResponseMessage Put(int id, [FromBody]ItemTempResource value)
        {
            try
            {
                value = new ItemTempResource(itemTempRepository.Update(id, value.ToModel()));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<ItemTempResource>(HttpStatusCode.OK, value);
        }

        // DELETE api/ItemTemp/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                itemTempRepository.Delete(id);
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

        // Get api/ItemTemp?idMainTemp=10
        public HttpResponseMessage GetItemTempByIdMainTemp(int idMainTemp)
        {
            List<ItemTemp> items;
            try
            {
                items = itemTempRepository.GetItemTempByIdMainTemp(idMainTemp).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new ItemTempResource(items[i]).ToModel();
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
            return Request.CreateResponse<List<ItemTemp>>(HttpStatusCode.OK, items);
        }

        // Get api/ItemTemp?idItem=10
        public HttpResponseMessage GetItemTempByIdItem(int idItem)
        {
            List<ItemTemp> items;
            try
            {
                items = itemTempRepository.GetItemTempByIdItem(idItem).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new ItemTempResource(items[i]).ToModel();
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
            return Request.CreateResponse<List<ItemTemp>>(HttpStatusCode.OK, items);
        }
    }
}
