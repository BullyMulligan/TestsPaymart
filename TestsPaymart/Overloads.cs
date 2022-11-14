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
        Thread.Sleep(300);
    }

    protected void SendKeys(By element, string text)//перегрузка "SendKeys" - введите SendKeys(элемент поля ввода,текст)
    {
        var sendingElement = driver.FindElement(element);
        sendingElement.SendKeys(text);
        Thread.Sleep(300);
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
        string text = driver.FindElements(element)[index].Text;
        OnlyDigit(text);
        var code = "";
        for (int i = 55; i < text.Length; i++)
        {
            if (Char.IsDigit(text[i]))
            {
                code += text[i];
            }
        }
        return code;
    }
}