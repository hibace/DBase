using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2StatsAdmin.ViewModel.Admin
{
    using Shared;
    using System.Reflection;

    public class TableModel : LayoutModel
    {
        public string Columns { get; set; }
    }
}