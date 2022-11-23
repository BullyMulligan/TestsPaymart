using OpenQA.Selenium.Support.UI;

namespace TestsPaymart;

public class Overloads:Data
{
        
    protected void TestExpectedActual(By expected,string actual)
    {
        Assert.AreEqual(driver.FindElement(expected).Text,actual);
    }

    protected void TestExpectedActual(By expected, int index, string actual)
    {
        Assert.AreEqual(driver.FindElements(expected)[index].Text,actual);
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
    protected void SendKeys(By element,int index, string text)//перегрузка "SendKeys" - введите SendKeys(элемент поля ввода,текст)
    {
        var sendingElement = driver.FindElements(element)[index];
        sendingElement.SendKeys(text);
        
    }
    protected void Clear(By element)//перегрузка "SendKeys" - введите SendKeys(элемент поля ввода,текст)
    {
        var sendingElement = driver.FindElement(element);
        sendingElement.Clear();
        
    }
    protected void Clear(By element,int index)//перегрузка "SendKeys" - введите SendKeys(элемент поля ввода,текст)
    {
        var sendingElement = driver.FindElements(element)[index];
        sendingElement.Clear();
        
    }

    protected void Screenshot(string name)//перегрузка метода. Просто введи Screenshot("имя_скриншота")
    {
        Screenshot s1 = ((ITakesScreenshot)driver).GetScreenshot();
        s1.SaveAsFile($"C:/Users/ipopov/RiderProjects/TestsPaymart/TestsPaymart/File/Screenshots/{name}.jpg");
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
        wc.DownloadFile(driver.Url,"C:/Users/ipopov/RiderProjects/TestsPaymart/TestsPaymart/File/Screenshots/"+file);
    }

    protected string GetSmsCode(int index)
    {
        Click(_btnDebuggerMaximize); //открываем дебаггер, если нужно сверить смс-код
        Thread.Sleep(300);
        while (driver.FindElements(_listDebuggerMessages).Count<=index)
        {
            Thread.Sleep(100);
        }
        string text = driver.FindElements(_listDebuggerMessages)[index].Text;
        OnlyDigit(text);
        var code = "";
        var count = 0;
        while (count<=4)
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
        Click(_btnDebuggerMinimize);
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
    public void RightClick(IWebElement element)
    {
        Actions action = new Actions(driver);
        action.ContextClick(element).Perform();
    }
    //Методы авторизации
    public By AuthVendor(string id, string password)
    {
        SendKeys(_fieldIdVendor,id);
        SendKeys(_fieldPasswordVendor,password);
        Click(_authButton);
        Thread.Sleep(500);
        return By.XPath("//div[@class='error']");
        
    }
    public void AuthAdmin(string login,string password)
    {
        driver.Navigate().GoToUrl("https://sasha.paymart.uz/ru/login");//вводим адрес сайта
        driver.Manage().Window.Maximize();//открыть в полном окне
        driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
        SendKeys(_fieldIdAuth,login);
        SendKeys(_fieldPasswordAuth,password);
        Click(_btnAuthAdmin);
        Thread.Sleep(500);
    }
    public void FindBuyer()
    {
        AuthVendor(idVendor,passwordVendor);
        Thread.Sleep(1000);
        driver.FindElements(_listLeftMenu)[0].Click();
        SendKeys(_fieldNumberBuyerNewContract,_buyerForContract);
        Thread.Sleep(200);
        Click(_windowAccertNumber);
    }

    public void Select(By select, int index,int element)
    {
        SelectElement list = new SelectElement(driver.FindElements(select)[index]);
        list.SelectByIndex(element);
    }
    public void Select(By select, int index,string text)
    {
        SelectElement list = new SelectElement(driver.FindElements(select)[index]);
        list.SelectByText(text);
    }
    public void selectStudyType(string studyType,string XPath)
    {
        //driver.FindElement(By.XPath(XPath)).Click();
        // you might need a slight pause here waiting for the dropdown to load and open
        driver.FindElement(By.XPath(XPath + studyType)).Click();
    }

    public void ActionClick(By element)
    {
        Actions action = new Actions(driver);
        action.Click(driver.FindElement(element)).Perform();
    }

    public void ActionClick(By list, int index)
    {
        Actions action = new Actions(driver);
        action.Click(driver.FindElements(list)[index]).Perform();
    }
    public void ActionClick(By list, int index,string name)
    {
        Actions action = new Actions(driver);
        action.Click(driver.FindElements(list)[index].FindElement(By.XPath("[text()='"+name+"']"))).Perform();
    }

    public void Scroll(int weiпth,int height)
    {
        driver.ExecuteJavaScript($"window.scrollTo({weiпth},{height})");
    }

    public void Select(By list,int indexList, By element,int indexElement)//Заполняем модифицированный список Ul/li
    {
        ActionClick(list,indexList);//Жмем кнопку, если она единственная, то индекс заполняем 0
        Thread.Sleep(200);
        ActionClick(element,indexElement);//element - искомый элемент в листе, indexElement - его индекс
        Thread.Sleep(500);
    }
}