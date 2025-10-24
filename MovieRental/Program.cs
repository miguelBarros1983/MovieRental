using MovieRental.Configurations;
using MovieRental.Data;
using MovieRental.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkSqlite().AddDbContext<MovieRentalDbContext>(); //Por defeito o lifetime é scoped e o RentalFeatures estava como singletone, não é possível pela incongruência,
                                                                                  //pois um cria apenas uma só instancia (singletone) e o outro cria por cada http request
builder.Services.ConfigureDependencies(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseErrorHandlingMiddleware();
app.UseAuthorization();
app.MapControllers();

using (var client = new MovieRentalDbContext())
{
    client.Database.EnsureCreated();
}

app.Run();
