using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Office
{
    static public class Office
    {
        static public IServiceCollection AddOffice(this IServiceCollection collection)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            return collection;
        }

        static public void UseOffice()
            => Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }
}
