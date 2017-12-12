using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Dota2StatsAdmin.Controllers
{
    using System.Reflection;
    using ViewModel.Admin;

    public class AdminController : Controller
    {
        Dictionary<string, IEnumerable<string>> tables = new Dictionary<string, IEnumerable<string>>
        {
            {"Hero", new List<string> {"HeroClass", "Id", "Name", "Role"}},
            {"HeroStat", new List<string> {"HeroDamage", "HeroHealing", "Id", "IdHero", "IdMatch", "TowerDamage"}},
            {"Item", new List<string> {"Id", "Name", "Type"}},
            {"ItemStat", new List<string> {"Id", "IdItem", "TimeUsed"}},
            {"ItemTemp", new List<string> {"Id", "IdItem", "IdMainTemp"}},
            {"MainTemp", new List<string> {"Id", "IdHero", "IdMatch", "IdPlayer"}},
            {"Match", new List<string> {"Date", "Duration", "GameMode", "Id"}},
            {"Player", new List<string> {"Id", "Nickname", "NumberOfGames"}},
            {"PlayerStat", new List<string> {"Id", "IdPlayer", "MostMatchesPlayed", "TimeSpentPlaying", "Verified"}}

        };
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            var viewModel = new IndexModel();
            viewModel.Tables = new JavaScriptSerializer().Serialize(tables.Select(o => o.Key).ToList());
            return View(viewModel);
        }
        public ActionResult Table(string model)
        {
            var viewModel = new TableModel();
            viewModel.Title = model;
            viewModel.Columns = new JavaScriptSerializer().Serialize(tables[model]);
            return View(viewModel);
        }
    }
}