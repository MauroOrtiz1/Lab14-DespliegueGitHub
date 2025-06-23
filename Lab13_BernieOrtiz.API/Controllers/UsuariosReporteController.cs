using Microsoft.AspNetCore.Mvc;
using Lab13_BernieOrtiz.Infrastructure;

namespace Lab13_BernieOrtiz.API.Controllers;

[ApiController]
[Route("api/reportes")]
public class UsuariosReporteController : ControllerBase
{
    private readonly ReporteExcelUsuariosService _service;

    public UsuariosReporteController(ReporteExcelUsuariosService service)
    {
        _service = service;
    }

    [HttpGet("usuarios")]
    public async Task<IActionResult> DescargarExcel()
    {
        var archivo = await _service.GenerarExcelAsync();
        return File(
            archivo,
            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
            "usuarios.xlsx"
        );
    }
}