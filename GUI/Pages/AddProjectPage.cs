using OpenQA.Selenium;

namespace GUI.Pages
{
    public class AddProjectPage : BasePage
    {
        private static string END_POINT = "index.php?/admin/projects/add";
        
        // Описание элементов
        private static readonly By NameInputBy = By.Id("name");
        
        
        public AddProjectPage(IWebDriver? driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }

        public AddProjectPage(IWebDriver? driver) : base(driver, false)
        {
        }
        
        public override bool IsPageOpened()
        {
            try
            {
                return NameInput.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        protected override string GetEndpoint()
        {
            return END_POINT;
        }

        public IWebElement NameInput => Driver.FindElement(NameInputBy);
    }
}