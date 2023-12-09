using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestApi.Models;
using TestApi.NewFolder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddCustomJwtAuth(builder.Configuration);

var app = builder.Build();

var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var rolemanager = services.GetRequiredService<RoleManager<IdentityRole>>();
var usermanager = services.GetRequiredService<UserManager<IdentityUser>>();
await AddRoleAndUser.AddRole(rolemanager);
await AddRoleAndUser.AddUser(usermanager);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
