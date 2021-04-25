using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using ConfigDemo.Models;

namespace ConfigDemo.Controllers
{
    public abstract class BaseController<T> : Controller where T : BaseController<T>
    {
        private ILogger<T> _logger;
        private IConfiguration _configuration;
        private IOptions<ConnectionString> _appConnectionString;
        private IOptions<AppConfig> _appConfiguration;

        protected ILogger<T> Logger => _logger ?? (_logger = HttpContext?.RequestServices.GetService<ILogger<T>>());
        protected IConfiguration Configuration => _configuration ?? (_configuration = HttpContext?.RequestServices.GetService<IConfiguration>());
        protected IOptions<ConnectionString> AppConnectionString => _appConnectionString ?? (_appConnectionString = (HttpContext?.RequestServices.GetService<IOptions<ConnectionString>>()));
        protected IOptions<AppConfig> AppConfiguration => _appConfiguration ?? (_appConfiguration = (HttpContext?.RequestServices.GetService<IOptions<AppConfig>>()));

        protected string DisplayMessage
        {
            get { return TempData["DisplayMessage"] == null ? String.Empty : TempData["DisplayMessage"].ToString(); }
            set { TempData["DisplayMessage"] = value; }
        }
    }
}
