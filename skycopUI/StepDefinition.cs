using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;


namespace SeleniumTemplate
{
    [Binding]
    public class StepDefinition
    {
        private PageObject _pageObject;
        public PageObject PageObject => _pageObject ?? (_pageObject = new PageObject());
        public static IWebDriver Driver;
        public class Browser

        {
            public IWebDriver Chrome;

            public Browser()
            {
                var options = new ChromeOptions();
                options.AddArgument("--start-maximized");
                Chrome = new ChromeDriver(options);
            }
        }

        public StepDefinition(Browser browser)
        {
            Driver = browser.Chrome;
            PageFactory.InitElements(Driver, PageObject);
        }

        [Given(@"I Open Google homepage")]
        public void GivenIOpenSkycopClaimPage()
        {
            Driver.Url = "https://www.google.com/";
        }

        [Given(@"I navigate to claims")]
        public void GivenINavigateToClaims()
        {
            Driver.Url = "https://claim.skycop.com/";
            
            //ScenarioContext.Current.Pending();
        }

        [Then(@"I set Kaunas as departure airport")]
        public void ThenISetKaunasAsDepartureAirport()
        {
            Thread.Sleep(2000);
            PageObject.departureAirportField.SendKeys(Constants.departureAirport);

            Thread.Sleep(2000);
            var kaunasSelection = Driver.FindElement(By.XPath("//div[@title='Kaunas International Airport']"));
            kaunasSelection.Click();
        }
        
        [Then(@"I set London as destination airport")]
        public void ThenISetLondonAsDestinationAirport()
        {
            Thread.Sleep(2000);
            var departureAirportField = Driver.FindElement(By.XPath("(//input[@class='Select-input'])[2]"));
            departureAirportField.SendKeys("LGW");

            Thread.Sleep(2000);
            var londonSelection = Driver.FindElement(By.XPath("//div[@title='London Gatwick Airport']"));
            londonSelection.Click();

        }

        [Then(@"I go to select direct or not flight")]
        public void ThenIGoToSelectDirectOrNotFlight()
        {
            var directFlightFirst = Driver.FindElement(By.XPath("(//div[@class='Select-value'])[3]"));
            directFlightFirst.Click();

            var directFlight = Driver.FindElement(By.XPath("//div[@id='react-select-4--option-1']"));
            directFlight.Click();
        }

        [Then(@"I select connecting airport")]
        public void ThenISelectConnectingAirport()
        {
            Thread.Sleep(2000);
            var connectingAirport = Driver.FindElement(By.XPath("(//input[@class='Select-input'])[3]"));
            connectingAirport.SendKeys("VNO");
            Thread.Sleep(2000);
            connectingAirport = Driver.FindElement(By.XPath("//div[@title='Vilnius International Airport']"));
            connectingAirport.Click();
        }

        [Then(@"I select which flight was with issues")]
        public void ThenISelectWhichFlightWasWithIssues()
        {
            var whichFlightIssue = Driver.FindElement(By.XPath("//span[@class='row no-gutters text-c-md h-mb0']"));
            whichFlightIssue.Click();

        }

        [Then(@"I enter airlines name")]
        public void ThenIEnterAirlinesName()
        {
            Thread.Sleep(3000);
            var whichAirlines = Driver.FindElement(By.XPath("(//input[@class='Select-input'])[4]"));
            whichAirlines.SendKeys("RR");

            Thread.Sleep(2000);
            var whichAirlinesClick = Driver.FindElement(By.XPath("//div[@id='react-select-7--option-0']"));
            whichAirlinesClick.Click();
            
        }

        [Then(@"I enter flight number")]
        public void ThenIEnterFlightNumber()
        {
            var flightNumber = Driver.FindElement(By.XPath("//input[@name='failedFlightNumberDigits']"));
            flightNumber.SendKeys("5555");
        }

        [Then(@"I enter flight date")]
        public void ThenIEnterFlightDate()
        {
            var flightDate = Driver.FindElement(By.XPath("//input[@name='failedFlightDate']"));
            flightDate.Click();

            var pickFlightDate = Driver.FindElement(By.XPath("(//td[@class='rdtDay'])[2]"));
            pickFlightDate.Click();

        }

        [Then(@"I choose problem")]
        public void ThenIChooseProblem()
        {
            var problemEncountered = Driver.FindElement(By.XPath("(//span[@class='form-check-label form-check-label--bold'])[1]"));
            problemEncountered.Click();
        }

        [Then(@"I enter time delayed")]
        public void ThenIEnterTimeDelayed()
        {
            Thread.Sleep(2000);
            var timeDelayed = Driver.FindElement(By.XPath("(//span[@class='form-check-label form-check-label--bold'])[4]"));
            timeDelayed.Click();

        }

        [Then(@"I choose the reason for delay")]
        public void ThenIChooseTheReasonForDelay()
        {           
            var theReason = Driver.FindElement(By.XPath("(//span[@class='Select-value-label'])[6]"));
            theReason.Click();

            
            //var pickFlightDate = Driver.FindElement(By.XPath("//div[@aria-activedescendant='react-select-21--option-2']"));
            
        }









    }
}