﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Cloud.World.Shared.Database
{
    public partial class TbAnnex
    {
        public string Aid { get; set; }
        public string Pid { get; set; }
        public string Aname { get; set; }
        public string Atype { get; set; }
        public string Apath { get; set; }
        public int Astatus { get; set; }
        public DateTime Atime { get; set; }
        public string Publisher { get; set; }

        public virtual TbProject PidNavigation { get; set; }
        public virtual TbUser PublisherNavigation { get; set; }
    }
}