using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;

namespace TestsPaymart;

public class AdminTests:Overloads
{
    public Action action;
    
    [SetUp]
    public void Setup()
    {
        driver = new OpenQA.Selenium.Chrome.ChromeDriver();//открываем Хром
        driver.Navigate().GoToUrl("https://sasha.paymart.uz/ru/login");//вводим адрес сайта
        driver.Manage().Window.Maximize();//открыть в полном окне
        driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
    }

    
    [Test]
    public void Auth()
    {
        AuthAdmin(_numberAdmin,_passwordAdmin);
    }
    [Test]
    public  void AuthAdminEmptyNumber()
    {
        AuthAdmin("","");
        TestExpectedActual(_expErrorEmtyNumber,"Номер телефона не может быть пустым");
        Screenshot("Номер телефона не может быть пустым");
        //TestExpectedActual(_expErrorEmtyNumber,"Пароль не может быть пустым");
        
        //TestExpectedActual(_expErrorEmtyNumber,"Некорректный пароль");
    }
    [Test]
    public  void AuthAdminEmptyPassword()
    {
        AuthAdmin(_numberAdmin,"");
        TestExpectedActual(_expErrorEmtyNumber,"Пароль не может быть пустым");
        Screenshot("Пароль не может быть пустым");
        //TestExpectedActual(_expErrorEmtyNumber,"Некорректный пароль");
    }
    [Test]
    public  void AuthAdminUncorectPassword()
    {
        AuthAdmin(_numberAdmin,"123456789");
        TestExpectedActual(_expErrorEmtyNumber,"Некорректный пароль");
        Screenshot("Некорректный пароль");
    }

    [Test]
    public void AuthAdminUserNotFound()
    {
        AuthAdmin("987654321","123456789");
        TestExpectedActual(_expErrorEmtyNumber,"Пользователь не найден");
        Screenshot("Пользователь не найден");
    }
    [Test]
    public void FindBuyer()
    {
        AuthAdmin(_numberAdmin,_passwordAdmin);
        FindBuyerAdmin(_newBuyer);
        if (driver.FindElements(_exClientTab).Count != 0)
        {
            if (driver.FindElement(_exClientTab).Text == "В таблице отсутствуют данные")
            {
                Screenshot("В таблице данные отсутствуют");
                return;
            }
        }
        Screenshot("Искомый покупатель");
        TestExpectedActual((By.XPath("//td")), 8, $"+99{_newBuyer}");
        
    }
    [Test]
    public void Scoring()
    {
        AuthAdmin(_numberAdmin,_passwordAdmin);
        FindBuyerAdmin(_newBuyer);
        if (driver.FindElements(_exClientTab).Count != 0)
        {
            if (driver.FindElement(_exClientTab).Text == "В таблице отсутствуют данные")
            {
                Screenshot("В таблице данные отсутствуют");
                return;
            }
        }
        Thread.Sleep(1000);
        driver.FindElements(By.XPath("//tbody"))[0].Click();
        Thread.Sleep(2000);
        driver.ExecuteJavaScript("window.scrollTo(0,300)");
        if (driver.FindElements(_btnModerate).Count!=0)//если клиент не верифицирован
        {
            Click(_btnModerate);//жмем кнопку "модерацию"
        }
        Thread.Sleep(200);
        driver.FindElements(_listScoringCient)[0].SendKeys(_passportNumber);
        driver.FindElements(_listScoringCient)[1].SendKeys(_buyerPnfl);
        SelectElement select = new SelectElement(driver.FindElements(By.XPath("//select[@class='form-control']"))[2]);
        select.SelectByIndex(10);
        select = new SelectElement(driver.FindElements(By.XPath("//select[@class='form-control']"))[3]);
        select.SelectByIndex(6);
        Scroll(0,1200);
        if (driver.FindElements(_btnScoring).Count == 1 && driver.FindElements(_exScoringIsPassed).Count==9)
        {
            Click(_btnScoring);
           
            Thread.Sleep(5000);
            Screenshot("Скоринг начался");
            return;
        }
        
        TestExpectedActual(_exStatusScoring,"Статус в MyId");
        Screenshot("Скоринг уже пройден");
        
        
    }

    [TearDown]
    public void TearDown()
    {
        //driver.Quit();
    }
    public void FindBuyerAdmin(string number)
    {
        Click(_btnSideBarOpen);
        driver.ExecuteJavaScript("window.scrollTo(0,700)");
        driver.FindElements(_listSideBarMenu)[24].Click();
        driver.FindElements(_fieldSearchClient)[1].SendKeys(number);
        Click(_btnSearchClient);
        
    }
}
