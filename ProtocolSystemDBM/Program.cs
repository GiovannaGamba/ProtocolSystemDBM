using Microsoft.EntityFrameworkCore;
using ProtocolSystemDBM.Repositories.Implementations;
using ProtocolSystemDBM.Repositories.Interfaces;
using ProtocolSystemDBM.Services.Implementations;
using ProtocolSystemDBM.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ProtocolSystemDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IProtocolService, ProtocolService>();
builder.Services.AddScoped<IProtocolRepository, ProtocolRepository>();

builder.Services.AddScoped<IProtocolStatusService, ProtocolStatusService>();
builder.Services.AddScoped<IProtocolStatusRepository, ProtocolStatusRepository>();

builder.Services.AddScoped<IProtocolFollowService, ProtocolFollowService>();
builder.Services.AddScoped<IProtocolFollowRepository, ProtocolFollowRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "protocolFollowHistory",
    pattern: "protocol/{id}/protocolfollow/list/",
    defaults: new { controller = "ProtocolFollow", action = "List" });

app.MapControllerRoute(
    name: "createProtocolFollow",
    pattern: "protocol/{id}/protocolfollow/create/",
    defaults: new { controller = "ProtocolFollow", action = "Create" });

app.MapControllerRoute(
    name: "updateProtocolFollow",
    pattern: "protocol/{protocolId}/protocolfollow/{id}/update/",
    defaults: new { controller = "ProtocolFollow", action = "Update" });

app.MapControllerRoute(
    name: "deleteProtocolFollow",
    pattern: "protocol/{protocolId}/protocolfollow/{id}/delete/",
    defaults: new { controller = "ProtocolFollow", action = "Delete" });

app.Run();
