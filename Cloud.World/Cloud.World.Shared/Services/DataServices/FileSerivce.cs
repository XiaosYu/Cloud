using BootstrapBlazor.Components;
using Cloud.World.Shared.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.World.Shared.Services.DataServices
{
    public class FileSerivce : DataServiceBase
    {
        public FileSerivce(CloudWorldContext context): base(context) { }

        public async Task<bool> Validate(byte[] sources)
        {
            var md5 = sources.ToMD5();
            var result = await Context.TbFile.FirstOrDefaultAsync(s => s.Hash == md5);
            return result != null;
        }

        public async Task<bool> Update(UploadFile file)
        {
            return true;
        }


	}
}
