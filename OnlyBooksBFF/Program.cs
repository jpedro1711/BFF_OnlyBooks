using OnlyBooksBFF.APis;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddRefitClient<ILivroApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://onlybookscontainerapp.yellowocean-3bc779a1.northeurope.azurecontainerapps.io/"));

builder.Services.AddRefitClient<IGeneroLivroApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://onlybookscontainerapp.yellowocean-3bc779a1.northeurope.azurecontainerapps.io/"));

builder.Services.AddRefitClient<IReservaApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://onlybookscontainerapp.yellowocean-3bc779a1.northeurope.azurecontainerapps.io/"));

builder.Services.AddRefitClient<IUsuarioApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://onlybookscontainerapp.yellowocean-3bc779a1.northeurope.azurecontainerapps.io/"));

builder.Services.AddRefitClient<IEmprestimoApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://emprestimosfunctionapp.azurewebsites.net/api"));

builder.Services.AddRefitClient<ICreateEmprestimoAsyncApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://onlybookscontainerapp.yellowocean-3bc779a1.northeurope.azurecontainerapps.io/"));
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
