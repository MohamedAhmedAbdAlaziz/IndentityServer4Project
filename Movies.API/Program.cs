using Microsoft.EntityFrameworkCore;
using Movies.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MoviesContext>(x =>
x.UseInMemoryDatabase("Movies"));

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5005";
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = false
        };
        
    });

builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("ClientIdPolicy", option =>
    option.RequireClaim("client_id", "movieClient"));
});
//builder.Services.AddDbContext<MoviesContext>(x =>
//{
//    x.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"));
//});
var app = builder.Build();
SeedDataBase(app);

 static void SeedDataBase(WebApplication app)
{ 
    using var scope= app.Services.CreateScope();
    var services= scope.ServiceProvider;
    var movieContext = services.GetRequiredService<MoviesContext>();
    MoviesContextSeed.SeedAsync(movieContext);
}

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
