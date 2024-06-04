// TUTORIAL
//https://www.youtube.com/watch?v=6J0-Yyfzh2c

// https://www.youtube.com/watch?v=JSiF8wh-5HU

using Ejercicio06_PersonasYGrupos.Services;

IListaBuilder MiGenerador = new InicialBuilder();
IFecha fecha = new ObtenerAnno();
var empleados = MiGenerador.dameEmpleados();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
