using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace UI_Test_for_Task_Board_app_with_Selenium
{
    class BasePage
    {
        
        public IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }
        public const string baseUrl = "https://taskboard-1.stoyaniv.repl.co";
        
        public IWebElement taskBoardButton => driver.FindElement(By.CssSelector("body > main > div > a:nth-child(1)"));
        public IWebElement newTaskButton => driver.FindElement(By.CssSelector("body > main > div > a:nth-child(2)"));
        public IWebElement searchLink => driver.FindElement(By.CssSelector("body > main > div > a:nth-child(3)"));
        public IReadOnlyCollection<IWebElement> taskInfo => driver.FindElements(By.CssSelector("body > main > section"));


    }
}
