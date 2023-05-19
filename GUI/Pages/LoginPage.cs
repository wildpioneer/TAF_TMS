using OpenQA.Selenium;

namespace GUI.Pages
{
    public class LoginPage : BasePage
    {
        private static string END_POINT = "";
        
        // Описание элементов
        private static readonly By EmailInputBy = By.Id("name");
        private static readonly By PswInputBy = By.Id("password");
        private static readonly By RememberMeCheckboxBy = By.Id("rememberme");
        private static readonly By LoginInButtonBy = By.Id("button_primary");
        
        // Инициализация класса
        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
        }
        public LoginPage(IWebDriver driver) : base(driver, false)
        {
        }
        
        public override bool IsPageOpened()
        {
            try
            {
                return LoginInButton().Displayed;
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

        // Методы
        public IWebElement EmailInput()
        {
            return Driver.FindElement(EmailInputBy);  
        }

        public IWebElement PswInput()
        {
            return Driver.FindElement(PswInputBy);
        }

        public IWebElement RememberMeCheckbox()
        {
            return Driver.FindElement(RememberMeCheckboxBy);  
        }

        public IWebElement LoginInButton()
        {
           return Driver.FindElement(LoginInButtonBy);
        }
    }
}