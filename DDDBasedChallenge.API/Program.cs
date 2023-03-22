using DDDBasedChallenge.Application.Features;
using DDDBasedChallenge.Application.Interfaces.Repositories;
using DDDBasedChallenge.Persistence;
using DDDBasedChallenge.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


builder.Services.AddDbContext<DDDBasedChallengeContext>();

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
