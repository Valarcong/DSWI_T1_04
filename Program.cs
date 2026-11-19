using DSWI_T1_04.Data;
using DSWI_T1_04.Repositories;
using DSWI_T1_04.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddScoped<ClienteRepositoryInterface, ClienteRepository>();
builder.Services.AddScoped<ClienteServiceInterface, ClienteService>();

builder.Services.AddScoped<PedidoRepositoryInterface, PedidoRepository>();
builder.Services.AddScoped<PedidoServiceInterface, PedidoService>();


var app = builder.Build();

// Configuración del entorno
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();

