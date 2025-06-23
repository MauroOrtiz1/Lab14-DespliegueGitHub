using Microsoft.AspNetCore.Mvc;
using Lab13_BernieOrtiz.Domain;

namespace Lab13_BernieOrtiz.API.Controllers;

[ApiController]
[Route("api/excel")]
public class ExcelController : ControllerBase
{
    private readonly IExcelReportGenerator _excelGenerator;

    public ExcelController(IExcelReportGenerator excelGenerator)
    {
        _excelGenerator = excelGenerator;
    }

    [HttpGet("primer-ejemplo")]
    public IActionResult GenerarExcel()
    {
        var archivo = _excelGenerator.CrearPrimerEjemplo();
        return File(archivo, 
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
            "PrimerEjemplo.xlsx");
    }
    [HttpGet("modificar-prueba")]
    public IActionResult ModificarPrueba()
    {
        var archivo = _excelGenerator.ModificarPruebaLab13();
        return File(archivo,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "Prueba_Lab13_Modificado.xlsx");
    }
    [HttpGet("tabla-ejemplo")]
    public IActionResult CrearTabla()
    {
        var archivo = _excelGenerator.CrearTablaConDatos();
        return File(archivo,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "TablaEjemplo.xlsx");
    }
    [HttpGet("con-estilos")]
    public IActionResult ExcelConEstilos()
    {
        var archivo = _excelGenerator.CrearExcelConEstilos();
        return File(archivo,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "Excel_Con_Estilos.xlsx");
    }


}
