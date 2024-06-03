using Ejercicio06_PersonasYGrupos.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio06_PersonasYGrupos.Controllers
{
    public class EmployeeController : Controller
    {
        IListaBuilder MiGenerador = new InicialBuilder();
        public IActionResult Index()
        {
            var empleados = MiGenerador.dameEmpleados();

            ViewBag.Index = empleados;
            ViewData["empleados"] = empleados;

            return View(empleados);
        }

        public IActionResult Consulta1()
        {
            var empleados = MiGenerador.dameEmpleados();

            var consulta1 = 
                from empleado in empleados 
                where empleado.Sex.ToString() == "M"
                select empleado;

            ViewBag.Consulta1 = consulta1;
            ViewData["consulta1"] = consulta1;

            return View(consulta1);
        }

        public IActionResult Consulta2()
        {
            var empleados = MiGenerador.dameEmpleados();
            IFecha fecha = new ObtenerAnno();
            var consulta2 =
                from empleado in empleados
                where fecha.getAnno(empleado.DOB) < 2008
                select empleado;
            ViewBag.Consulta2 = consulta2;
            ViewData["consulta2"] = consulta2;

            return View(consulta2);
        }

        public IActionResult Consulta3()
        {
            var empleados = MiGenerador.dameEmpleados();
            var consulta3=
                from empleado in empleados
                where empleado.Sex.ToString() == "F"
                orderby empleado.FName
                select empleado;
            ViewBag.Consulta3 = consulta3;
            ViewData["consulta3"] = consulta3;

            return View(consulta3);
        }

        public IActionResult Consulta4()
        {
            var empleados = MiGenerador.dameEmpleados();
            IFecha fecha = new ObtenerAnno();
            var consulta4 =
                from empleado in empleados
                where empleado.Sex.ToString() == "M"
                      && empleado.FName.StartsWith("J")
                orderby fecha.getAnno(empleado.DOB) descending
                select empleado;
            ViewBag.Consulta4 = consulta4;
            ViewData["consulta4"] = consulta4;

            return View(consulta4);
        }

        public IActionResult Consulta5()
        {
            var empleados = MiGenerador.dameEmpleados();
            var consulta5 =
                empleados.GroupBy(e => new { e.FName, e.Sex })
                    .OrderBy(g => g.Key.FName)
                    .Select(g => new
                    {
                        g.Key.FName,
                        g.Key.Sex
                    }).ToList();

            ViewBag.Consulta5 = consulta5;
            ViewData["consulta5"] = consulta5;

            return View(consulta5);
        }
    }
}
