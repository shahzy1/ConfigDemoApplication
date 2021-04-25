using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ConfigDemo.Models;

namespace ConfigDemo.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        //Navigate to URL, for example https://localhost:44320/home/simpleconfig
        public string Index()
        {
            Logger.LogInformation("I am using dependency injection created in the base cotroller");
            return "Navigate to URL to show an example";
        }

        //using configuration
        public ViewResult SimpleConfig()
        {
            var configValue = Configuration.GetSection("AppConfig").GetChildren();
            string result = configValue.Select(i => i.Value).Aggregate((i, j) => i + "," + j );
            // generate the view
            return View("Result",
            (object)String.Format("Simple Config value: {0}", result));
        }

        //using strong type
        public ViewResult ConfigValueFromConfig()
        {
            string configValue = AppConfiguration.Value.ApplicationName;
            // generate the view
            return View("Result",
            (object)String.Format("App Config value: {0}", configValue));
        }
        public ViewResult ConnectionStringFromConfig()
        {
            string configValue = AppConnectionString.Value.DBConnection1;
            // generate the view
            return View("Result",
            (object)String.Format("Connection String Config value: {0}", configValue));
        }

        //demo model usage
        public ViewResult ModelProperty()
        {
            // create a new Product object
            Product myProduct = new Product();
            // set the property value
            myProduct.Name = "Lazy reobot";
            // get the property
            string productName = myProduct.Name;
            // generate the view
            return View("Result",
            (object)String.Format("Product name: {0}", productName));
        }
    }
}
