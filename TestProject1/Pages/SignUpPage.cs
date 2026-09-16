using OpenQA.Selenium;
using Serilog;
using TestProject1.Base;

namespace TestProject1.Pages;

public class SignUpPage : BasePage
{
    public SignUpPage(IWebDriver driver) : base(driver)
    {
    }

    public bool WaitForPageToLoad()
    {
        Log.Information("Waiting for sign up page");

        return IsDisplayed(By.Name("zip_code"));
    }

    public void TypeZipCode(string? zipCode)
    {
        Log.Information("Entering zip code");
        
        Type(By.Name("zip_code"), zipCode);
        
        Log.Information("Entering zip code is successfully");
    }

    public void ClickContinue()
    {
        Log.Information("Clicking continue");
        
        Click(By.XPath("/html/body/center/table/tbody/tr[5]/td/table/tbody/tr[2]/td/table/tbody/tr[3]/td[2]/input"));
        
        Log.Information("Clicking continue is successfully");
    }

    public bool WaitForLoadSecondPage()
    {
        Log.Information("Waiting for second sign up page");
        
        return IsDisplayed(By.Name("first_name"));
    }

    public void TypeFirstName(string firstName)
    {
        Log.Information("Entering first name");
        
        Type(By.Name("first_name"), firstName);
        
        Log.Information("Entering first name is successfully");
    }

    public void TypeLastName(string lastName)
    {
        Log.Information("Entering last name");
        
        Type(By.Name("last_name"), lastName);
        
        Log.Information("Entering last name is successfully");
    }

    public void TypeEmail(string email)
    {
        Log.Information("Entering email");
        
        Type(By.Name("email"), email);
        
        Log.Information("Entering email is successfully");
    }
    
    public void TypePassword(string password)
    {
        Log.Information("Entering password");
        
        Type(By.Name("password1"), password);
        
        Log.Information("Entering password is successfully");
    }

    public void TypeConfirmPassword(string confirmPassword)
    {
        Log.Information("Entering confirm password");
        
        Type(By.Name("password2"), confirmPassword);
        
        Log.Information("Entering confirm password is successfully");
    }

    public void ClickRegister()
    {
        Log.Information("Clicking register");
        
        Click(By.XPath("/html/body/center/table/tbody/tr[5]/td/table/tbody/tr[2]/td/table/tbody/tr[6]/td[2]/input"));
        
        Log.Information("Clicking register is successfully");
    }

    public bool CheckSuccess()
    {
        Log.Information("Checking success");

        return IsDisplayed(By.XPath("/html/body/center/table/tbody/tr[4]/td/span"));
    }
}