﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Cloud.World.Shared.Database
{
    public partial class TbProject
    {
        public TbProject()
        {
            TbAnnex = new HashSet<TbAnnex>();
            TbFile = new HashSet<TbFile>();
        }

        public string Pid { get; set; }
        public string Sid { get; set; }
        public string Pname { get; set; }
        public string Introduction { get; set; }
        public DateTime Deadline { get; set; }
        public int Pstatus { get; set; }
        public DateTime Ptime { get; set; }
        public string Publisher { get; set; }

        public virtual TbUser PublisherNavigation { get; set; }
        public virtual TbSubject SidNavigation { get; set; }
        public virtual ICollection<TbAnnex> TbAnnex { get; set; }
        public virtual ICollection<TbFile> TbFile { get; set; }
    }
}