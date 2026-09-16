using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog.Core;
using TestProject1.Options;


namespace TestProject1.Base;

public abstract class BaseTest : IDisposable
{
    protected readonly IWebDriver? driver;
    protected readonly RegistrationOption settings;
    
    protected BaseTest()
    {
        var options = new ChromeOptions();
        options.AddArguments("--start-maximized");
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.sharelane.com/cgi-bin/register.py");

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        
        settings = config.GetSection("RegistrationOption").Get<@RegistrationOption>() 
                      ?? throw new InvalidOperationException("RegistrationOption section not found in appsettings.json");
    }

    public void Dispose()
    {
        driver?.Quit();
        driver?.Dispose();
    }
}