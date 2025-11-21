using Microsoft.EntityFrameworkCore;
using ProyectoParqueo.Data;

var builder = WebApplication.CreateBuilder(args);

// Agregar MVC (obligatorio para controladores y vistas)
builder.Services.AddControllersWithViews();

// Agregar autorización (porque usas app.UseAuthorization())
builder.Services.AddAuthorization();

// Agregar DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Archivos estáticos (wwwroot)
app.UseStaticFiles();

app.UseRouting();

// Autorización
app.UseAuthorization();

// Rutas (aquí está la ruta acomodada correctamente)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Parqueo}/{action=Registrar}/{id?}"
);

app.Run();
