using System;
using TechTalk.SpecFlow;

namespace SeleniumTemplate
{
    [Binding]
    public sealed class Hooks
    {
        public static void Main()
        {
            Console.WriteLine("Starting test...");
            Console.ReadLine();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //StepDefinition.Driver.Close();
        }
    }

}
