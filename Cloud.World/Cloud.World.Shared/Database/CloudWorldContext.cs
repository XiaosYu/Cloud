using Cloud.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.World.Shared.Database
{
	public class CloudWorldContext: DbContext<DB_CloudWorldContext>
	{
		public CloudWorldContext(DB_CloudWorldContext context): base(context) 
		{

		}

		public DbSet<TbAccount, DB_CloudWorldContext> TbAccount { get; set; }
		public DbSet<TbAnnex, DB_CloudWorldContext> TbAnnex { get; set; }
		public DbSet<TbClass, DB_CloudWorldContext> TbClass { get; set; }
		public DbSet<TbCourseSelection, DB_CloudWorldContext> TbCourseSelection { get; set; }
		public DbSet<TbFile, DB_CloudWorldContext> TbFile { get; set; }
		public DbSet<TbFileType, DB_CloudWorldContext> TbFileType { get; set; }
		public DbSet<TbGlobal, DB_CloudWorldContext> TbGlobal { get; set; }
		public DbSet<TbLog, DB_CloudWorldContext> TbLog { get; set; }
		public DbSet<TbNotice, DB_CloudWorldContext> TbNotice { get; set; }
		public DbSet<TbProject, DB_CloudWorldContext> TbProject { get; set; }
		public DbSet<TbSubject, DB_CloudWorldContext> TbSubject { get; set; }
		public DbSet<TbUser, DB_CloudWorldContext> TbUser { get; set; }
		public DbSet<VAnnex, DB_CloudWorldContext> VAnnex { get; set; }
		public DbSet<VUser, DB_CloudWorldContext> VUser { get; set; }
		public DbSet<VWork, DB_CloudWorldContext> VWork { get; set; }
	}
}
