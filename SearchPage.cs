using OpenQA.Selenium;

namespace UI_Test_for_Task_Board_app_with_Selenium
{
    class SearchPage : BasePage
    {

        public SearchPage(IWebDriver driver) : base(driver)
        {
        }
        public string pageurl = baseUrl + "/tasks/search";
        public void GoToPage()
        {
            driver.Navigate().GoToUrl(this.pageurl);
        }
        public IWebElement searchField => driver.FindElement(By.CssSelector("#keyword"));
        public IWebElement searchButton => driver.FindElement(By.CssSelector("#search"));
        public IWebElement resultMassege => driver.FindElement(By.CssSelector("#searchResult"));
        public IWebElement body => driver.FindElement(By.CssSelector("body"));
        public IWebElement result => driver.FindElement(By.CssSelector("#task5 > tbody > tr.title td"));

        
    }
}
