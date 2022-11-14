namespace TestsPaymart;

public class AdminTests:Overloads
{
    
    
    [SetUp]
    public void Setup()
    {
        driver = new OpenQA.Selenium.Chrome.ChromeDriver();//открываем Хром
        driver.Navigate().GoToUrl("https://lisa.paymart.uz/ru/login");//вводим адрес сайта
        driver.Manage().Window.Maximize();//открыть в полном окне
    }

    [Test]
    public  void AuthAdmin()
    {
        Click(_btnAuthAdmin);
        TestExpectedActual(_expErrorEmtyNumber,"Номер телефона не может быть пустым");
        SendKeys(_fieldIdAuth,_numberAdmin);
        Click(_btnAuthAdmin);
        TestExpectedActual(_expErrorEmtyNumber,"Пароль не может быть пустым");
        SendKeys(_fieldPasswordAuth,"12");
        Click(_btnAuthAdmin);
        TestExpectedActual(_expErrorEmtyNumber,"Некорректный пароль");
        driver.FindElement(_fieldPasswordAuth).Clear();
        SendKeys(_fieldPasswordAuth,_passwordAdmin);
        Click(_btnAuthAdmin);
        Thread.Sleep(500);
        TestExpectedActual(_expEmployees, "Сотрудники");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}