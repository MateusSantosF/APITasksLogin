using Login.Facades.UserFacade;
using Login.Facades.UserFacade.interfaces;
using Login.Services.Context;
using Login.Services.UserRepository;
using Login.Services.UserRepository.interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// INJECT 

builder.Services.AddScoped<IUserFacade, UserFacade>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// DATABASE
builder.Services.AddDbContext<UserContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
