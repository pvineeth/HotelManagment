using ApplicationContext;
using Microsoft.EntityFrameworkCore;
using Repositories.AuthenticationRepository;
using Repositories.BranchRepository;
using Repositories.HostelRepository;
using Repositories.RoleRepository;
using Repositories.UserRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HotelManagmentContext>(x=>x.UseSqlServer(builder.Configuration.GetConnectionString("HotelManagmentContext")));

builder.Services.AddTransient<IAuthenticationRepository,AuthenticationRepository>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IHostelReposirory, HostelReposirory>();
builder.Services.AddTransient<IBranchRepositoty, BranchRepository>();
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
