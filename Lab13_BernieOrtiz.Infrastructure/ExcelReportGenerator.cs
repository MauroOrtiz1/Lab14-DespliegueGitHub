using ClosedXML.Excel;
using Lab13_BernieOrtiz.Domain;

public class ExcelReportGenerator : IExcelReportGenerator
{
    public byte[] CrearExcelConEstilos()
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Estilos");

        var headerRow = worksheet.Row(1);
        headerRow.Style.Font.Bold = true;
        headerRow.Style.Fill.BackgroundColor = XLColor.Cyan;
        headerRow.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

        worksheet.Cell(1, 1).Value = "ID";
        worksheet.Cell(1, 2).Value = "Nombre";
        worksheet.Cell(1, 3).Value = "Edad";

        // Fila de datos
        worksheet.Cell(2, 1).Value = 1;
        worksheet.Cell(2, 2).Value = "Juan";
        worksheet.Cell(2, 3).Value = 28;

        using var ms = new MemoryStream();
        workbook.SaveAs(ms);
        return ms.ToArray();
    }

    public byte[] CrearTablaConDatos()
    {
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Datos");

        worksheet.Cell(1, 1).Value = "ID";
        worksheet.Cell(1, 2).Value = "Nombre";
        worksheet.Cell(1, 3).Value = "Edad";

        worksheet.Cell(2, 1).Value = 1;
        worksheet.Cell(2, 2).Value = "Juan";
        worksheet.Cell(2, 3).Value = 28;

        worksheet.Cell(3, 1).Value = 2;
        worksheet.Cell(3, 2).Value = "María";
        worksheet.Cell(3, 3).Value = 34;

        var range = worksheet.Range("A1:C3");
        range.CreateTable();

        using var ms = new MemoryStream();
        workbook.SaveAs(ms);
        return ms.ToArray();
    }


    public byte[] ModificarPruebaLab13()
    {
        var ruta = @"C:\Users\USER\Desktop\Prueba Lab13.xlsx";

        using var workbook = new XLWorkbook(ruta);
        var worksheet = workbook.Worksheet(1);

        worksheet.Cell("A2").Value = "Bernie";
        worksheet.Cell("B2").Value = "Mauro";
        worksheet.Cell("C2").Value = 19.5;

        workbook.Save(); 

        using var ms = new MemoryStream();
        workbook.SaveAs(ms);
        return ms.ToArray();
    }




    public byte[] CrearPrimerEjemplo() {
        // array de datos
        var personas = new[]
        { new { Nombre = "Bernie", Edad = 21 }, new { Nombre = "Robert", Edad = 32 }, new { Nombre = "Pedro", Edad = 24 },
            new { Nombre = "Lucía", Edad = 29 }, new { Nombre = "Carlos", Edad = 35 } };
        
        using var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Hoja1");

        worksheet.Cell(1, 1).Value = "Nombre";
        worksheet.Cell(1, 2).Value = "Edad";
        // Escribir datos desde el array
        int fila = 2;
        foreach (var persona in personas) {
            worksheet.Cell(fila, 1).Value = persona.Nombre;
            worksheet.Cell(fila, 2).Value = persona.Edad;
            fila++;
        }
        
        using var ms = new MemoryStream();
        workbook.SaveAs(ms);
        return ms.ToArray(); // Devuelve el archivo como array de bytes
    }
   

}