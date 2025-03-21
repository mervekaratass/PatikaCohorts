﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace Core.CrossCuttingConcerns.Logging
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
          _logger.LogInformation($"Incoming Request: {context.Request.Method} {context.Request.Path}");
        

          // _logger.LogInformation("Actiona girildi");
            await _next(context);
        }
    }

}
