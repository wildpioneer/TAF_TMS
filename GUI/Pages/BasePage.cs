using GUI.Utilites.Configuration;
using OpenQA.Selenium;

namespace GUI.Pages;

public abstract class BasePage
{
    protected IWebDriver Driver { get; set; }

    public BasePage(IWebDriver driver, bool openPageByUrl)
    {
        Driver = driver;

        if (openPageByUrl)
        {
            OpenPageByUrl();
        }
    }

    public abstract bool IsPageOpened();
    protected abstract string GetEndpoint();

    private void OpenPageByUrl()
    {
        Driver.Navigate().GoToUrl(Configurator.AppSettings.URL + GetEndpoint());
    }
}