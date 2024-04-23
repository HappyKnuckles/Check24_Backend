using Check24.Api;
using Check24.Api.Hubs;
using Check24.Core;
using Check24.Core.Interfaces;
using Check24.Db;
using Check24.Db.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<Check24Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Check24DB"), sqlServerOptions =>
    {
        sqlServerOptions.EnableRetryOnFailure();
    }));



builder.Services.AddControllers();
builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Dependency Injection
builder.Services.AddTransient(typeof(IRepository<>), typeof(Check24.Db.Repositories.Repository<>));
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ICommunityRepository, CommunityRepository>();
builder.Services.AddTransient<IUserCommunityRepository, UserCommunityRepository>();
builder.Services.AddTransient<IGameRepository, GameRepository>();
builder.Services.AddTransient<IBetRepository, BetRepository>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod())
);

var app = builder.Build();

app.MapHub<AllHub>("/allhub");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();




app.Run();
