﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Cloud.World.Shared.Database
{
    public partial class TbClass
    {
        public TbClass()
        {
            TbUser = new HashSet<TbUser>();
        }

        public string Cid { get; set; }
        public string Cname { get; set; }
        public string Leader { get; set; }

        public virtual ICollection<TbUser> TbUser { get; set; }
    }
}