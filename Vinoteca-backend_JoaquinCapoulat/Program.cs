var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Registrar WineRepository como singleton
builder.Services.AddSingleton<WineRepository>();
builder.Services.AddSingleton<AuthService>();

// Registrar WineService como scoped
builder.Services.AddScoped<WineService>();

var app = builder.Build();

// Configuración del pipeline HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
