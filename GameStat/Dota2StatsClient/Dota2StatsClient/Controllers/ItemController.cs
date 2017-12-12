using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Dota2StatsClient.Models;
using PagedList;

namespace Dota2StatsClient.Controllers
{
    public class ItemController : Controller
    {
        string address = "http://localhost:57732/Dota2Stats/Item/";

        public async Task<ActionResult> Index(int? page)
        {
            List<Item> Item = new List<Item>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(address);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource  using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(address);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ItemResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the  list  
                    Item = JsonConvert.DeserializeObject<List<Item>>(ItemResponse);

                }
                //returning the  list to view  
                //return View(Hero);

                int pageSize = 10;
                int pageIndex = (page ?? 1);
                return View(Item.ToPagedList(pageIndex, pageSize));
            }
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Item Item = new Item();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(address);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource  using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(address + id);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ItemResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the  list  
                    Item = JsonConvert.DeserializeObject<Item>(ItemResponse);

                }
                //returning the  list to view  
                return View(Item);
            }
        }
    }
}