using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using Log = Serilog.Log;

namespace TestProject1.Base;

public abstract class BasePage
{
   protected readonly IWebDriver _driver;

   protected BasePage(IWebDriver driver)
   {
      _driver = driver;
   }

   protected IWebElement WaitForElement(By by, int timeoutSeconds = 10)
   {
      var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(timeoutSeconds));
      return wait.Until(d => d.FindElement(by));
   }

   protected void Click(By by)
   {
      try
      {
         Log.Information("Trying to click element {Locator}", by);
         WaitForElement(by).Click();
      }
      catch (Exception e)
      {
         Log.Error("Exception clicking element {Locator}, exception {Exception}", by, e.Message);
         throw;
      }
   }

   protected void Type(By by, string? text)
   {
      if (string.IsNullOrEmpty(text)) throw new ArgumentNullException(nameof(text));
      
      try
      {
         Log.Information("Attempt to enter text - {text} into the element - {Locator}", text, by);
         WaitForElement(by).SendKeys(text);
      }
      catch (Exception e)
      {
         Log.Error("Exception typing text to element {Locator}, exception {Exception}", by, e.Message);
         throw;
      }
   }

   protected bool IsDisplayed(By by)
   {
      var element = WaitForElement(by);
      return element.Displayed;
   }
}  