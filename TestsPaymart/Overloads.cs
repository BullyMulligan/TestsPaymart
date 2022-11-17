namespace TestsPaymart;

public class Overloads:Data
{
        
    protected void TestExpectedActual(By expected,string actual)
    {
        Assert.AreEqual(driver.FindElement(expected).Text,actual);
    }

    protected void TestExpectedActualNonDigit(By expected,string actual)
    {
        
        Assert.AreEqual(NonDigitAndSimbols(driver.FindElement(expected).Text),actual);
    }

    protected void TestExpectedActualNonDigit(By expected,string actual,int index)
    {
        Assert.AreEqual(NonDigitAndSimbols(driver.FindElements(expected)[index].Text),actual);
    }
    public void TestExpectedActualOnlyDigit(By expected,string actual,int index)
    {
        Assert.AreEqual(OnlyDigit(driver.FindElements(expected)[index].Text),actual);
    }

    protected void TestExpectedActualOnlyDigit(By expected,string actual)
    {
        Assert.AreEqual(OnlyDigit(driver.FindElement(expected).Text),actual);
    }

    protected void TestExpectedActual(By expected, string actual,int index)
    {
        Assert.AreEqual(driver.FindElements(expected)[index].Text,actual);
    }

    protected void ClickIndexList(By element, int index)
    {
        driver.FindElements(element)[index].Click();
        Thread.Sleep(300);
    }

    protected void Click(By element)//перегрузка метода "Клик" - просто введите Click(элемент, который нужно кликнуть)
    {
        var clickedElement = driver.FindElement(element);
        clickedElement.Click();
        
    }

    protected void SendKeys(By element, string text)//перегрузка "SendKeys" - введите SendKeys(элемент поля ввода,текст)
    {
        var sendingElement = driver.FindElement(element);
        sendingElement.SendKeys(text);
        
    }

    protected void Screenshot(string name)//перегрузка метода. Просто введи Screenshot("имя_скриншота")
    {
        Screenshot s1 = ((ITakesScreenshot)driver).GetScreenshot();
        s1.SaveAsFile($"#{name}.jpg");
    }

    private string OnlyDigit(string text)//метод, возвращающий строку цифр
    {
        string word = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (Char.IsDigit(text[i]))
            {
                word += text[i];
            }
        }

        return word;
    }

    private string NonDigitAndSimbols(string text)//метод, возвращающий строку без символовов и цифр
    {
        string word = "";
        for (int i = 0; i < text.Length; i++)
        {
            if (Char.IsLetter(text[i]) || text[i]==' ')
            {
                word += text[i];
            }
        }

        return word;
    }

    protected void DownloadFileToUrl(string file)//метод сохраняет файл,добавляя имени # в начало имени. Параметры - "имя_файла.расширение"
    {
        WebClient wc = new WebClient();
        wc.DownloadFile(driver.Url,"#"+file);
    }

    protected string GetSmsCode(By element,int index)
    {
        Thread.Sleep(2000);
        string text = driver.FindElements(element)[index].Text;
        OnlyDigit(text);
        var code = "";
        var count = 0;
        if (count<=4)
        {
            for (int i = 55; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                {
                    code += text[i];
                    count++;
                }
            }
        }
        return code;
    }
    public void unhide(IWebDriver driver, IWebElement element) //делаем элемент видимым
    {
        String script = "arguments[0].style.opacity=1;"
                        + "arguments[0].style['transform']='translate(0px, 0px) scale(1)';"
                        + "arguments[0].style['MozTransform']='translate(0px, 0px) scale(1)';"
                        + "arguments[0].style['WebkitTransform']='translate(0px, 0px) scale(1)';"
                        + "arguments[0].style['msTransform']='translate(0px, 0px) scale(1)';"
                        + "arguments[0].style['OTransform']='translate(0px, 0px) scale(1)';"
                        + "return true;";
         driver.ExecuteJavaScript(script, element);
    }

    public void attachFile(IWebDriver driver, By locator, String file) //добавляем файл
    {
        IWebElement input = driver.FindElement(locator);
        unhide(driver, input);
        input.SendKeys(file);
    }

    public void RightClick(By element)
    {
        Actions action = new Actions(driver);
        IWebElement elemen = driver.FindElement(element);
        action.ContextClick(elemen).Perform();
    }
    //Методы авторизации
    public By AuthVendor(string id, string password)
    {
        SendKeys(_fieldIdVendor,id);
        SendKeys(_fieldPasswordVendor,password);
        Click(_authButton);
        return By.XPath("//div[@class='error']");
        
    }
    public void AuthAdmin(string login,string password)
    {
        driver = new OpenQA.Selenium.Chrome.ChromeDriver();//открываем Хром
        driver.Navigate().GoToUrl("https://sasha.paymart.uz/ru/login");//вводим адрес сайта
        driver.Manage().Window.Maximize();//открыть в полном окне
        driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
        SendKeys(_fieldIdAuth,login);
        SendKeys(_fieldPasswordAuth,login);
        Click(_btnAuthAdmin);
        Thread.Sleep(500);
        TestExpectedActual(_expEmployees, "Сотрудники");
    }
}