using AuthService;
using IdentityServerHost.Quickstart.UI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
//services.AddControllers();
builder.Services.AddControllersWithViews();
services.AddSwaggerGen();

services.AddIdentityServer()
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddDeveloperSigningCredential()
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
     .AddTestUsers(TestUsers.Users);


var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseIdentityServer();
app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();

