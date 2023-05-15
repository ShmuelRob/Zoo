using Microsoft.EntityFrameworkCore;
using Zoo.DAL;
using Zoo.DAL.AdminRepository;
using Zoo.DAL.AnimalRepository;
using Zoo.DAL.CatalogRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ZooDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnections")));
builder.Services.AddTransient<IAdminRepository, AdminRepository>();
builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
builder.Services.AddTransient<ICatalogRepository, CatalogRepository>();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
       .AllowAnyMethod()
       .AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using var scope = app.Services.CreateScope();
    var ctx = scope.ServiceProvider.GetRequiredService<ZooDbContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseAuthorization();
app.UseRouting();

app.MapControllers();

app.Run();
