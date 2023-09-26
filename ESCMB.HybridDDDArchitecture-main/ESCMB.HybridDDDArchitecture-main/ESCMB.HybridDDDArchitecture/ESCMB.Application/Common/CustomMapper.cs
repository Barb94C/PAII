using AutoMapper;
using Common.Domain.Entities;
using System.Collections;

namespace ESCMB.Application.Common
{
    /// <summary>
    /// Clase base para el mapeo de objetos. No modificar este codigo
    /// </summary>
    public static class CustomMapper
    {
        public static IMapper MapperInstance { get; set; }

        public static T To<T>(this IValidate input)
        {
            IMapper mapper = MapperInstance;

            return mapper.Map<T>(input);
        }

        public static T To<T>(this T input)
        {
            IMapper mapper = MapperInstance;

            return mapper.Map<T>(input);
        }

        public static IEnumerable<T> To<T>(this IEnumerable input)
        {
            IMapper mapper = MapperInstance;
            return mapper.Map<IEnumerable<T>>(input);
        }
    }
}
