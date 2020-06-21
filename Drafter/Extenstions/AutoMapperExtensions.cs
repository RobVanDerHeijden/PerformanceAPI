using System.Collections;
using System.Collections.Generic;
using AutoMapper;

namespace Drafter.Extensions
{
    public static class AutoMapperExtensions
    {
        public static List<Resource> MapList<Resource>(this IMapper mapper, IEnumerable source)
        {
            return mapper.Map<List<Resource>>(source);
        }
    }
}