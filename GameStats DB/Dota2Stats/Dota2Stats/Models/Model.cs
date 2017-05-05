using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2Stats.Models
{
    public abstract class Base
    {
        public virtual int Id { get; set; }
    }

    public class Hero : Base
    {
        public virtual string Name { get; set; }
        public virtual string Hero_class { get; set; }
        public virtual string Role { get; set; }
        //public virtual Match Id_match { get; set; }
    }



    //public class Hero_stat : Base
    //{
    //    public virtual Hero Hero { get; set; }
    //    public virtual int Hero_damage { get; set; }
    //    public virtual int Hero_healing { get; set; }
    //    public virtual int Tower_damage { get; set; }
    //    public virtual Match Id_match { get; set; }
    //}
}