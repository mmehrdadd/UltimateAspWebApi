using UltimateAspWebApi.Extensions;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
//LogManager.Setup().LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Services.ConfigureLoggerService();
builder.Services.AddControllers();
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
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

if(app.Environment.IsDevelopment()) 
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();

app.UseStaticFiles();
app.UseForwardedHeaders();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
