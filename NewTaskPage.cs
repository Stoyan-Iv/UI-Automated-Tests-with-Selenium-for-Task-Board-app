using OpenQA.Selenium;

namespace UI_Test_for_Task_Board_app_with_Selenium
{
    class NewTaskPage : BasePage
    {
        public NewTaskPage(IWebDriver driver) : base(driver)
        {
        }
        public string pageurl = baseUrl + "/tasks/create";
        public void GoToPage()
        {

            driver.Navigate().GoToUrl(this.pageurl);
        }

        public IWebElement titleField => driver.FindElement(By.CssSelector("#title"));
        public IWebElement descriptionField => driver.FindElement(By.CssSelector("#description"));
        public IWebElement boardOption => driver.FindElement(By.CssSelector("#boardName"));
        public IWebElement createButton => driver.FindElement(By.CssSelector("#create"));
        public IWebElement errorMessage => driver.FindElement(By.CssSelector("body > main > div"));
    }
}
