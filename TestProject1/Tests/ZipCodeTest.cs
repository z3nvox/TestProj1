using OpenQA.Selenium;
using TestProject1.Base;
using TestProject1.Options;
using TestProject1.Pages;

namespace TestProject1.Tests;

public class LoginTest : BaseTest
{
    private readonly SignUpPage _signUpPage;
    
    public LoginTest()
    {
        _signUpPage = new SignUpPage(driver);
    }
    
    [Fact]
    public void TestLogin()
    {
        _signUpPage.WaitForPageToLoad();
        _signUpPage.TypeZipCode(settings.ZipCode);
        _signUpPage.ClickContinue();
        _signUpPage.WaitForLoadSecondPage();
        _signUpPage.TypeFirstName(settings.FirstName);
        _signUpPage.TypeLastName(settings.LastName);
        _signUpPage.TypeEmail(settings.Email);
        _signUpPage.TypePassword(settings.Password);
        _signUpPage.TypeConfirmPassword(settings.ConfirmPassword);
        _signUpPage.ClickRegister();
        _signUpPage.CheckSuccess();
    }
}