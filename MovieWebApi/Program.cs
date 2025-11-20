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
//builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient(typeof(IMovieManager), typeof(MovieManager));
builder.Services.AddTransient(typeof(IBookingManager), typeof(BookingManager));

builder.Services.AddTransient(typeof(IUserManager), typeof(UserManager));

builder.Services.AddTransient(typeof(ITheatreManager), typeof(TheatreManager));

builder.Services.AddTransient(typeof(IMovieService), typeof(MovieService));
builder.Services.AddTransient(typeof(IUserService), typeof(UserService));
builder.Services.AddTransient(typeof(IBookingService), typeof(BookingService));
builder.Services.AddTransient(typeof(ITheatreService), typeof(TheatreService));
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
