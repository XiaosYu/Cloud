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
	public class UserSerivce: DataServiceBase
	{
		public UserSerivce(CloudWorldContext context): base(context) { }

		public async Task<VUser?> LoginAsync(string account, string password)
		{
			var data = password.ToBytes().ToMD5();
			var user = await Context.VUser.FirstOrDefaultAsync(s => (s.Uid == account || s.Phone == account || s.Qq == account) && (s.PassWord == data));
			return user;
		}

		public async Task<VUser?> UpdateInfoAsync(string uid, string? password=null, string? qq=null, string? phone=null)
		{
			var user = await Context.VUser.FirstOrDefaultAsync(s => s.Uid == uid);
			if(user is not null)
			{
				if(qq is not null) user.Qq = qq;
				if(phone is not null) user.Phone = phone;
				if(password is not null)
				{
					var data = password.ToBytes().ToMD5();
					user.PassWord = data;
				}
				await Context.UpdateAsync(user);
				await Context.SaveChangesAsync();
			}
			return user;
		}
	}
}
