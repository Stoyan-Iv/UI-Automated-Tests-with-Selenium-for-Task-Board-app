using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace UI_Test_for_Task_Board_app_with_Selenium
{
    class TaskBoardPage : BasePage
    {
        public TaskBoardPage(IWebDriver driver) : base(driver)
        {
        }
        public string pageurl = baseUrl + "/boards";
        public void GoToPage()
        {
          
            driver.Navigate().GoToUrl(this.pageurl);
        }

        public IWebElement firstDoneTask => driver.FindElement(By.CssSelector("#task1 > tbody > tr.title td"));
        public IReadOnlyCollection<IWebElement> allTask => driver.FindElements(By.CssSelector("body > main td"));
        public IReadOnlyCollection<IWebElement> allOpenTitle => driver.FindElements(By.CssSelector("body > main > div > div:nth-child(1) tr td"));


        public string[] GetAllTask()
        {
            var listWithAllDoneTask = this.allTask.Select(s => s.Text).ToArray();
            return listWithAllDoneTask;
        }
     
        public string[] GetAllOpenTitle()
        {
            var listWithAllOpenTitle = this.allOpenTitle.Select(s => s.Text).ToArray();
            return listWithAllOpenTitle;
        }
    }
}
