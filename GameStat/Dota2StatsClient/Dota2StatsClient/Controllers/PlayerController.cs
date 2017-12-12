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
using Microsoft.Ajax.Utilities;
using PagedList;

namespace Dota2StatsClient.Controllers
{
    public class PlayerController : Controller
    {
        string address = "http://localhost:57732/Dota2Stats/";

        public async Task<ActionResult> Index(int? page)
        {
            List<Player> Player = new List<Player>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(address);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource  using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(address + "Player/");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var PlayerResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the  list  
                    Player = JsonConvert.DeserializeObject<List<Player>>(PlayerResponse);

                }
                //returning the  list to view  
                //return View(Hero);

                int pageSize = 10;
                int pageIndex = (page ?? 1);
                return View(Player.ToPagedList(pageIndex, pageSize));
            }
        }

        public async Task<ActionResult> History(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<PlayerHistory> pHistory = new List<PlayerHistory>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(address);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage heroRes = await client.GetAsync(address + "Hero/");
                HttpResponseMessage maintempRes = await client.GetAsync(address + "Maintemp/");
                HttpResponseMessage playerRes = await client.GetAsync(address + "Player/");
                HttpResponseMessage matchRes = await client.GetAsync(address + "Match/");

                if (heroRes.IsSuccessStatusCode && maintempRes.IsSuccessStatusCode && playerRes.IsSuccessStatusCode)
                {
                    var Hero = JsonConvert.DeserializeObject<List<Hero>>(heroRes.Content.ReadAsStringAsync().Result);
                    var Maintemp =
                        JsonConvert.DeserializeObject<List<Maintemp>>(maintempRes.Content.ReadAsStringAsync().Result);
                    var Player =
                        JsonConvert.DeserializeObject<List<Player>>(playerRes.Content.ReadAsStringAsync().Result);
                    var Match = JsonConvert.DeserializeObject<List<Match>>(matchRes.Content.ReadAsStringAsync().Result);

                    var playerHistoryQuery = from m in Maintemp
                        join h in Hero on m.IdHero equals h.Id
                        join p in Player on m.IdPLayer equals p.Id
                        join ma in Match on m.IdMatch equals ma.Id
                        select new
                        {
                            MatchId = m.IdMatch,
                            Date = ma.Date,
                            Duration = ma.Duration,
                            GameMode = ma.GameMode,
                            Hero = h.Name,
                            HeroId = m.IdHero,
                            PlayerId = m.IdPLayer
                        };

                    var res = playerHistoryQuery.Where(x => x.PlayerId == id).Take(10);

                    var resOrder = res.OrderBy(x => x.MatchId);

                    var json = JsonConvert.SerializeObject(resOrder.ToList());
                    pHistory = JsonConvert.DeserializeObject<List<PlayerHistory>>(json);


                    return View(pHistory);

                }
                return View(pHistory);
            }
        }

        public async Task<ActionResult> HeroPercent(int? id, int? page)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<HeroPercent> pickPercent = new List<HeroPercent>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(address);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage heroRes = await client.GetAsync(address + "Hero/");
                HttpResponseMessage maintempRes = await client.GetAsync(address + "Maintemp/");
                HttpResponseMessage playerRes = await client.GetAsync(address + "Player/");
                HttpResponseMessage matchRes = await client.GetAsync(address + "Match/");

                if (heroRes.IsSuccessStatusCode && maintempRes.IsSuccessStatusCode && playerRes.IsSuccessStatusCode)
                {
                    var Hero = JsonConvert.DeserializeObject<List<Hero>>(heroRes.Content.ReadAsStringAsync().Result);
                    var Maintemp =
                        JsonConvert.DeserializeObject<List<Maintemp>>(maintempRes.Content.ReadAsStringAsync().Result);
                    var Player =
                        JsonConvert.DeserializeObject<List<Player>>(playerRes.Content.ReadAsStringAsync().Result);
                    var Match = JsonConvert.DeserializeObject<List<Match>>(matchRes.Content.ReadAsStringAsync().Result);

                    var pn = from m in Maintemp
                        join p in Player on m.IdPLayer equals p.Id 
                        group new { m, p } by new
                        {
                            Nickname = p.Nickname,
                            IdPlayer = m.IdPLayer
                        }
                        into grouped
                        select new
                        {
                            Nickname = grouped.Key.Nickname,
                            IdPlayer = grouped.Key.IdPlayer,
                            Number_Of_Played_Games = grouped.Count()
                        };
                    
                    var pp = from m in Maintemp
                        join p in Player on m.IdPLayer equals p.Id
                        join h in Hero on m.IdHero equals h.Id
                        group new { m, p, h } by new
                        {
                            Nickname = p.Nickname,
                            IdPlayer = m.IdPLayer,
                            Hero = h.Name,
                            IdHero= h.Id
                        }
                        into grouped
                        select new
                        {
                            Nickname = grouped.Key.Nickname,
                            IdPlayer = grouped.Key.IdPlayer,
                            Hero = grouped.Key.Hero,
                            IdHero = grouped.Key.IdHero,
                            Played_Games_On_This_Hero = grouped.Count()
                        };

                    var query = from x in pp
                                join y in pn on x.IdPlayer equals y.IdPlayer
                                group new { x, y } by new
                                {
                                    Nickname = y.Nickname,
                                    IdPlayer = y.IdPlayer,
                                    Hero = x.Hero,
                                    IdHero = x.IdHero,
                                    Number_Of_Played_Games = y.Number_Of_Played_Games,
                                    Played_Games_On_This_Hero = x.Played_Games_On_This_Hero
                                }
                                into grouped
                                select new
                                {
                                    PlayerId = grouped.Key.IdPlayer,
                                    Nickname = grouped.Key.Nickname,
                                    HeroId = grouped.Key.IdHero,
                                    Hero = grouped.Key.Hero,
                                    PlayedGamesOnThisHero = grouped.Key.Played_Games_On_This_Hero,
                                    //Number_Of_Played_Games = grouped.Key.Number_Of_Played_Games,
                                    PickPercent = (Convert.ToDouble(grouped.Key.Played_Games_On_This_Hero) /
                                                  Convert.ToDouble(grouped.Key.Number_Of_Played_Games)) * 100
                                };


                    query = query.OrderByDescending(x => x.PickPercent);
                    var res = query.Where(x => x.PlayerId == id);


                    var json = JsonConvert.SerializeObject(res.ToList());
                    pickPercent = JsonConvert.DeserializeObject<List<HeroPercent>>(json);

                    int pageSize = 10;
                    int pageIndex = (page ?? 1);
                    return View(pickPercent.ToPagedList(pageIndex, pageSize));


                }
                return View();
            }
        }
    }
}