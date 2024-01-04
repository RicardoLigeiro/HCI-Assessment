using Hci.Services;
using Hci.WebApi;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "AllowAnyOrigin";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:5175"); // add the allowed origins  
        });
});

// Load app settings
builder.Configuration.AddJsonFile("appsettings.json", false);
var configuration = builder.Configuration;
var config = new ApplicationSettings();
configuration.Bind("Settings", config);

// Add services to the container.

builder.Services.AddControllers();

// Register hci services 
builder.Services.AddHciPersistenceCollection(config.ConnectionStrings.Databases.Sql);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);

app.Run();
