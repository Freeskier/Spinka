using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spinka.Application.Extensions
{
    public static class LinqExtension
    {
        public static async Task<TResult> SelectAsync<TSource, TResult>(this Task<TSource> source, Func<TSource, TResult> selector) 
        {
            return await Task.Run(async () =>
            {
                var sourceResult = await source;
                var ret = sourceResult == null ? default(TResult) : selector(sourceResult);
                return ret;
            });
        }
        
    }
}