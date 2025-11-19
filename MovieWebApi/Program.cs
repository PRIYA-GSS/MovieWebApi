using DataAccess.Context;
using DataAccess.Repositories;
using Interfaces.IManager;
using Interfaces.IRepository;
using Interfaces.IService;
using Managers;
using Microsoft.EntityFrameworkCore;
using MovieWebApi.Mappings;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IMovieManager), typeof(MovieManager));
builder.Services.AddScoped(typeof(IMovieService), typeof(MovieService));
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
