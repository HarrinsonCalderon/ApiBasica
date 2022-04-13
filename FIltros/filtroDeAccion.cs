using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.FIltros
{
    public class filtroDeAccion : IActionFilter
    {
        private readonly ILogger<filtroDeAccion> logger;
        public filtroDeAccion(ILogger<filtroDeAccion> logger) {
            this.logger = logger;
        }
        //antes de ejecutar la accion
        public void OnActionExecuting(ActionExecutingContext context)
        {
            logger.LogInformation("Antes de ejecutar la accion");
        }
        //despues de ejecutar la accion
        public void OnActionExecuted(ActionExecutedContext context)
        {
            logger.LogInformation("Despues de ejecutar la accion");
        }

       
    }
}
