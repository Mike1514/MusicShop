using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBlocksMiddleware;
using Microsoft.AspNetCore.Builder;

namespace ApiMIddleware.Middleware
{
    public static class LogExceptionMiddlevareExtention
    {
        public static IApplicationBuilder UseLogExceptionMiddlevare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogExceptionMiddlevare>();
        }
    }
}