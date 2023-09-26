using ESCMB.Application.Repositories.Sql;

namespace ESCMB.Application.ApplicationServices
{
    /// <summary>
    /// Ejemplo de un servicio de aplicacion para resolver procesos
    /// relacionados a la entidad Dummy que no son responsabilidad del
    /// handler que ejecuta el caso de uso.
    /// </summary>
    internal static class DummyEntityApplicationService
    {
        public static bool DummyEntityExist(this IDummyEntityRepository context, object value)
        {
            context = context ?? throw new ArgumentNullException(nameof(context));
            value = value ?? throw new ArgumentNullException(nameof(value));

            var response = context.FindOne(value);

            return response != null;
        }
    }
}
