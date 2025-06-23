using Lab13_BernieOrtiz.Application.Usuarios.DTOs;
using Lab13_BernieOrtiz.Application.Usuarios.Queries;
using ClosedXML.Excel;
namespace Lab13_BernieOrtiz.Infrastructure;

public class ReporteExcelUsuariosService {
    private readonly GetUsuariosQueryHandler _handler;

    public ReporteExcelUsuariosService(GetUsuariosQueryHandler handler) {
        _handler = handler;
    }
    public async Task<byte[]> GenerarExcelAsync() {
        var usuarios = await _handler.Handle(new GetUsuariosQuery());

        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Usuarios");

        // Encabezado
        ws.Cell(1, 1).Value = "ID";
        ws.Cell(1, 2).Value = "Nombre";
        ws.Cell(1, 3).Value = "Email";

        int fila = 2;
        foreach (var u in usuarios) {
            ws.Cell(fila, 1).Value = u.IdUsuario;
            ws.Cell(fila, 2).Value = u.Nombre;
            ws.Cell(fila, 3).Value = u.Email;
            fila++;
        }
        
        var tablaRango = ws.Range(1, 1, fila - 1, 3);
        var tabla = tablaRango.CreateTable();
        tabla.Theme = XLTableTheme.TableStyleMedium9;
        
        ws.Range("A1:C1").Style.Font.Bold = true;
        
        ws.Columns().AdjustToContents();

        using var ms = new MemoryStream();
        wb.SaveAs(ms);
        return ms.ToArray();
    }
}