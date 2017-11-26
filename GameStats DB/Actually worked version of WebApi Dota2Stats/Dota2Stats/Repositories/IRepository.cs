using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Repositories
{
    using Models;
    public interface IRepository<TModel> //where TModel : BaseEntity
    {
        List<TModel> GetAll();
        TModel Get(int id);
        TModel Insert(TModel model);
        TModel Update(int id, TModel model);
        bool Delete(int id);
    }
}