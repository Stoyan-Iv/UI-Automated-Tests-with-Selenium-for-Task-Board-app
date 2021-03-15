using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UI_Test_for_Task_Board_app_with_Selenium
{
    public class Tests
    {
        IWebDriver driver;


        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void CheckFirstDoneTask()
        {
           //Arrange 
           var page = new TaskBoardPage(driver);
           //Act
           page.GoToPage();
           var firstDoneTask = page.firstDoneTask;
          //Assert
           Assert.AreEqual(firstDoneTask.Text, "Project skeleton");
        }
        [Test]
        public void SearchWithValidData()
        {
            //Arrange
            var page = new SearchPage(driver);
            //Act
            page.GoToPage();
            page.searchField.SendKeys("Edit tasks");
            page.searchButton.Click();
            //Assert
            Assert.AreEqual(page.resultMassege.Text, "1 tasks found.");
            Assert.AreEqual(page.result.Text, "Edit tasks");
        }
        [Test]
        public void SearchWithEmptyData()
        {
            //Arrange
            var page = new SearchPage(driver);
            //Act
            page.GoToPage();
            page.searchField.SendKeys("");
            page.searchButton.Click();
            //Assert

            Assert.IsFalse(page.body.Text.Contains("Title"));
        }
        [Test]
        public void SearchWithInValidData()
        {
            //Arrange
            var page = new SearchPage(driver);

            //Act
            page.GoToPage();
            page.searchField.SendKeys("invalid word");
            page.searchButton.Click();

            //Assert
            Assert.AreEqual(page.resultMassege.Text, "No tasks found.");
        }
        [Test]
        public void AddTaskWithValidDat()
        {
            //Arrange
            var page = new NewTaskPage(driver);

            //Act - Create Task
            page.GoToPage();
            page.titleField.SendKeys("Task From UI Test");
            page.descriptionField.SendKeys("Task From UI Test");
            var selectElement = new SelectElement(page.boardOption);
            selectElement.SelectByValue("Open");
            page.createButton.Click();

            //Act - Observe ViewPage
            var viewPage = new TaskBoardPage(driver);
            var allOpenTitle = viewPage.GetAllOpenTitle();
            int index = allOpenTitle.Length - 3;

            //Assert
            Assert.AreEqual(allOpenTitle[index], "Task From UI Test");
        }
        [Test]
        public void AddTaskWithInValidDat()
        {
            //Arrange
            var page = new NewTaskPage(driver);

            //Act
            page.GoToPage();
            page.titleField.SendKeys("");
            page.descriptionField.SendKeys("");
            page.createButton.Click();

            //Assert
            Assert.AreEqual(page.errorMessage.Text, "Error: Title cannot be empty!");

         
        }
        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}