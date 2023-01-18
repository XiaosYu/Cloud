using Cloud.Utility.IO.Compression;
using System.Net.NetworkInformation;
using System.Threading;
using System;
using Cloud.Test.Models;
using Cloud.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Cloud.Utility.Extensions;
using System.Text.RegularExpressions;
using System.Collections.Concurrent;

using System.Text;
using Cloud.Office.Pdf;
using Cloud.Office;
using Cloud.Office.Xls;
using Cloud.Utility.Cryptography;


var e = "1234".Encrypt();
Console.WriteLine(e);
var s = e.Decrypt();
Console.WriteLine(s);

class People
{
    public string Name { set; get; }
    public int Age { set; get; }
    public bool Sex { set; get; }
}
