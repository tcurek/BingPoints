using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using src.BingPoints;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Starting!");

var edgeOptions = new EdgeOptions();
edgeOptions.AddArguments("ser-data-dir=C:\\Users\\Marian\\AppData\\Local\\Microsoft\\Edge\\User Data");
edgeOptions.AddArguments("profile-directory=Personal 2");
edgeOptions.AddArguments("--start-maximized");

var driver = new EdgeDriver(edgeDriverDirectory: "./Drivers/", edgeOptions);
driver.Url = "https://bing.com";

try
{    
    var searches = SearchTermGenerator.Get(5);

    foreach(var search in searches)
    {
        var element = driver.FindElement(By.Id("sb_form_q"));
        element.SendKeys(search);
        element.Submit();
        Thread.Sleep(5000);
        driver.Navigate().Back();
    }
}
finally 
{
    driver.Quit();
}
