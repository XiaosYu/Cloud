﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Cloud.World.Shared.Database
{
    public partial class TbCourseSelection
    {
        public int Index { get; set; }
        public string Uid { get; set; }
        public string Sid { get; set; }
        public DateTime Ctime { get; set; }
        public int Cstatus { get; set; }

        public virtual TbSubject SidNavigation { get; set; }
        public virtual TbUser UidNavigation { get; set; }
    }
}