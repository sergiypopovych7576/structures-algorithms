using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuresAndAlgorithms
{
    public static class Search
    {
        public static T LinearSearch<T>(this IEnumerable<T> array, Predicate<T> predicate)
        {
            foreach(var item in array)
            {
                if(predicate(item))
                {
                    return item;
                }
            }


            return default(T);
        }
    }
}
