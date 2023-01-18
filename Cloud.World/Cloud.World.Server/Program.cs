using Cloud.World.Shared.Data;
using Cloud.World.Shared.Database;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBootstrapBlazor();

//添加数据库服务
builder.Services.AddSqlServer<DB_CloudWorldContext>(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddScoped<CloudWorldContext>();

//添加全局身份验证
builder.Services.AddScoped<UserData>();

//路由小写
builder.Services.AddRouting(options => options.LowercaseUrls = true);


var app = builder.Build();

app.UseBootstrapBlazor();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

//注册WebAPI路径
app.MapControllers();

app.Run();
