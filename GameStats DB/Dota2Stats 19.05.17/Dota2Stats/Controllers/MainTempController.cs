using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dota2Stats.Models;
using Dota2Stats.Repositories.MainTemp;
using Dota2Stats.Resources;

namespace Dota2Stats.Controllers
{
    using Middleware;
    using Npgsql;
    using NpgsqlTypes;

    public class MainTempController : ApiController
    {
        MainTempRepository mainTempRepository = new MainTempRepository();

        // GET: api/MainTemp
        public HttpResponseMessage Get()
        {
            List<MainTemp> items;
            try
            {
                items = mainTempRepository.GetAll().ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new MainTempResource(items[i]).ToModel();
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
            return Request.CreateResponse<IEnumerable<MainTemp>>(HttpStatusCode.OK, items);
        }

        public HttpResponseMessage Get(int id)
        {
            MainTemp item;
            try
            {
                item = new MainTempResource(mainTempRepository.Get(id)).ToModel();
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<MainTemp>(HttpStatusCode.OK, item);
        }

        //POST api/MainTemp
        public HttpResponseMessage Post([FromBody]MainTempResource value)
        {
            try
            {
                value = new MainTempResource(mainTempRepository.Insert(value.ToModel()));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<MainTempResource>(HttpStatusCode.OK, value);
        }

        //PUT api/MainTemp/5
        public HttpResponseMessage Put(int id, [FromBody]MainTempResource value)
        {
            try
            {
                value = new MainTempResource(mainTempRepository.Update(id, value.ToModel()));
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            finally
            {
                NpgsqlHelper.Connection.Close();
            }
            return Request.CreateResponse<MainTempResource>(HttpStatusCode.OK, value);
        }

        // DELETE api/MainTemp/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                mainTempRepository.Delete(id);
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

        // Get api/MainTemp?idMatch=10
        public HttpResponseMessage GetMainTempByIdMatch(int idMatch)
        {
            List<MainTemp> items;
            try
            {
                items = mainTempRepository.GetMainTempByIdMatch(idMatch).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new MainTempResource(items[i]).ToModel();
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
            return Request.CreateResponse<List<MainTemp>>(HttpStatusCode.OK, items);
        }

        // Get api/MainTemp?idHero=1
        public HttpResponseMessage GetMainTempByIdHero(int idHero)
        {
            List<MainTemp> items;
            try
            {
                items = mainTempRepository.GetMainTempByIdHero(idHero).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new MainTempResource(items[i]).ToModel();
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
            return Request.CreateResponse<List<MainTemp>>(HttpStatusCode.OK, items);
        }

        // Get api/MainTemp?idPlayer=5
        public HttpResponseMessage GetMainTempByIdPlayer(int idPlayer)
        {
            List<MainTemp> items;
            try
            {
                items = mainTempRepository.GetMainTempByIdPlayer(idPlayer).ToList();
                for (int i = 0; i < items.Count; i++)
                {
                    items[i] = new MainTempResource(items[i]).ToModel();
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
            return Request.CreateResponse<List<MainTemp>>(HttpStatusCode.OK, items);
        }
    }
}
