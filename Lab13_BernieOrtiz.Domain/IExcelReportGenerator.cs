namespace Lab13_BernieOrtiz.Domain
{
    public interface IExcelReportGenerator
    {
        byte[] CrearPrimerEjemplo();
        byte[] ModificarPruebaLab13();

        // 👇 Agrega esta línea para que el controlador lo reconozca
        byte[] CrearTablaConDatos();
        byte[] CrearExcelConEstilos();

    }


}