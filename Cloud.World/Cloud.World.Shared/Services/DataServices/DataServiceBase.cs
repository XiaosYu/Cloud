using Cloud.Utility.Extensions;
using Cloud.World.Shared.Data;
using Cloud.World.Shared.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.World.Shared.Services.DataServices
{
	public abstract class DataServiceBase
	{
		protected DataServiceBase(CloudWorldContext context)
		{
			Context = context;
		}
		protected CloudWorldContext Context { get; set; }
		private TbLog CreateLog(UserData user)
			=> user.IsOnline ? new TbLog()
			{
				Batch = user.Batch,
				Ip = user.Client!.Ip,
				Uid = user.UserID,
			} : null;
		public async Task LogAsync(UserData user, string action, object args)
		{
			var log = CreateLog(user);
			if (log != null)
			{
				log.Action = action;
				log.Parameter = args.ToJson();
				await Context.AddAsync(log);
				await Context.SaveChangesAsync();
			}
		}
		public void Log(UserData user, string action, object args) 
		{
			var log = CreateLog(user);
			if (log != null)
			{
				log.Action = action;
				log.Parameter = args.ToJson();
				Context.Add(log);
			}
		}

	}
}
