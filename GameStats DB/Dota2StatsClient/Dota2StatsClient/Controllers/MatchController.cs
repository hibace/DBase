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
    public class MatchController : Controller
    {
        string address = "http://localhost:57732/Dota2Stats/";

        public async Task<ActionResult> Index(int? page)
        {
            List<MatchHistory> maHistory = new List<MatchHistory>();
            List<Maintemp> Maintemp = new List<Maintemp>();
            List<Match> Match = new List<Match>();
            List<Player> Player = new List<Player>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(address);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage maintempRes = await client.GetAsync(address + "/Maintemp/");
                HttpResponseMessage matchRes = await client.GetAsync(address + "/Match/");
                HttpResponseMessage playerhRes = await client.GetAsync(address + "/Player/");

                if (matchRes.IsSuccessStatusCode && maintempRes.IsSuccessStatusCode)

                {
                    Match = JsonConvert.DeserializeObject<List<Match>>(matchRes.Content.ReadAsStringAsync().Result);
                    Maintemp =
                        JsonConvert.DeserializeObject<List<Maintemp>>(maintempRes.Content.ReadAsStringAsync().Result);
                    Player = JsonConvert.DeserializeObject<List<Player>>(playerhRes.Content.ReadAsStringAsync().Result);
                }

                var playersInMatch = from m in Maintemp
                    join ma in Match on m.IdMatch equals ma.Id
                    join p in Player on m.IdPLayer equals p.Id

                    select new
                    {
                        MatchId = m.IdMatch,
                        PlayerId = m.IdPLayer,
                        Nickname = p.Nickname
                    };

                var query = from m in Maintemp
                    join ma in Match on m.IdMatch equals ma.Id

                    select new
                    {
                        MatchId = m.IdMatch,
                        Date = ma.Date,
                        Duration = ma.Duration,
                        GameMode = ma.GameMode,
                        Players = from p in playersInMatch
                        where p.MatchId == m.IdMatch
                        select new
                        {
                            Nickname = p.Nickname,
                            PlayerId = p.PlayerId
                        }
                    };


                var res = query;

                var curDate = DateTime.Now;
                var lastMonthDate = new DateTime(curDate.Year, curDate.Month - 1, curDate.Day);
                res = res.Where(x => x.Date <= curDate && x.Date >= lastMonthDate);

                res = from r in res orderby r.MatchId select r;

                res = res.ToList().DistinctBy(m => m.MatchId);
                var json = JsonConvert.SerializeObject(res.ToList());
                maHistory = JsonConvert.DeserializeObject<List<MatchHistory>>(json);

                int pageSize = 10;
                int pageIndex = (page ?? 1);
                return View(maHistory.ToPagedList(pageIndex, pageSize));
            }
        }


        public async Task<ActionResult> Info(int? id, int? page)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<MatchHistory> pim = new List<MatchHistory>();

            List<Maintemp> Maintemp = new List<Maintemp>();
            List<Match> Match = new List<Match>();
            List<Player> Player = new List<Player>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(address);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage maintempRes = await client.GetAsync(address + "/Maintemp/");
                HttpResponseMessage matchRes = await client.GetAsync(address + "/Match/");
                HttpResponseMessage playerhRes = await client.GetAsync(address + "/Player/");

                if (matchRes.IsSuccessStatusCode && maintempRes.IsSuccessStatusCode)

                {
                    Match = JsonConvert.DeserializeObject<List<Match>>(matchRes.Content.ReadAsStringAsync().Result);
                    Maintemp =
                        JsonConvert.DeserializeObject<List<Maintemp>>(maintempRes.Content.ReadAsStringAsync().Result);
                    Player = JsonConvert.DeserializeObject<List<Player>>(playerhRes.Content.ReadAsStringAsync().Result);
                }

                var playersInMatch = from m in Maintemp
                    join ma in Match on m.IdMatch equals ma.Id
                    join p in Player on m.IdPLayer equals p.Id

                    select new
                    {
                        MatchId = m.IdMatch,
                        PlayerId = m.IdPLayer,
                        Nickname = p.Nickname
                    };

                var query = from m in Maintemp
                    join ma in Match on m.IdMatch equals ma.Id

                    select new
                    {
                        MatchId = m.IdMatch,
                        Date = ma.Date,
                        Duration = ma.Duration,
                        GameMode = ma.GameMode,
                        Players = from p in playersInMatch
                        where p.MatchId == m.IdMatch && m.IdMatch == id && p.MatchId == id
                        select new
                        {
                            Nickname = p.Nickname,
                            PlayerId = p.PlayerId
                        }
                    };


                var res = query;

                res = from r in res orderby r.MatchId select r;

                res = res.ToList().DistinctBy(m => m.MatchId);
                res = from r in res
                    where r.MatchId == id
                    select new
                    {
                        MatchId = r.MatchId,
                        Date = r.Date,
                        Duration = r.Duration,
                        GameMode = r.GameMode,
                        Players = r.Players
                    };

                var json = JsonConvert.SerializeObject(res.ToList());
                pim = JsonConvert.DeserializeObject<List<MatchHistory>>(json);

                int pageSize = 10;
                int pageIndex = (page ?? 1);
                return View(pim.ToPagedList(pageIndex, pageSize));
            }
        }
    }
}