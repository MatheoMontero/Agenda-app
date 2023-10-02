using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MASAJES.Models; // Reemplaza 'TuProyecto.Models' con el espacio de nombres correcto para tus modelos

public class GananciasController : Controller
{
    private DB_MASAJESEntities dbContext = new DB_MASAJESEntities(); // Reemplaza 'ApplicationDbContext' con tu contexto de base de datos

    public async Task<ActionResult> MostrarGananciasMensuales()
    {
        DateTime fechaActual = DateTime.Now;

        decimal gananciasMensuales = await dbContext.SESIONES_MASAJES
            .Where(s => s.FECHA.Month == fechaActual.Month && s.FECHA.Year == fechaActual.Year)
            .Select(s => s.PRECIO ?? 0)
            .DefaultIfEmpty()
            .SumAsync();

        return View(gananciasMensuales);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            dbContext.Dispose();
        }
        base.Dispose(disposing);
    }
}