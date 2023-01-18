using BootstrapBlazor.Components;
using Cloud.Utility.Extensions;
using Cloud.World.Shared.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.World.Shared.Data
{
	public class UserData
	{
		public VUser? User { get; set; }
		public ClientInfo? Client { get; }
		public string? Batch { get; set; }
		private WebClientService WebClientService { get; }

		public bool IsOnline => User != null && Client != null && Batch != null;
		public string? UserName => IsOnline ? User!.Name : null;
		public string? UserID => IsOnline ? User!.Uid: null;
		public object? UserInfo => IsOnline
			? new { Status = "Online", Info = new { User = new { User!.Uid, User!.Name }, Client = Client!, Batch = Batch! } }
			: new { Status = "Offline", Info = new { } };

		public UserData SignOut()
		{
			User = null;
			return this;
		}
		public UserData Login(VUser user) 
		{
			User = user;
			return this;
		}
		public UserData(WebClientService service)
		{
			Batch = new Random().RandString(10);
			WebClientService = service;
		}
		


	}
}
