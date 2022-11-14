
namespace TestsPaymart;

public class VendorTests:Overloads
{
    
    private readonly By _btnPrintClientAct = By.XPath("//a[@class='btn btn-orange mr-2']");
    private readonly By _photoClient = By.XPath("//div[@class='d-flex flex-row-reverse justify-content-between align-items-center custom-file']");
    private readonly By _act = By.XPath("//div[@class='d-flex flex-row-reverse justify-content-between align-items-center custom-file mb-3']");
    private readonly By _btnCancelContract = By.XPath("//button[@class='btn btn-red border-radius-8 w-100']");
    private readonly By _createContract = By.XPath("//a[@title='Договора']");
    private string _numberBuyer = "998186838";
    private string _newBuyer = "8909831021";
   
    
    [SetUp]
    protected void Setup()
    {
        driver = new OpenQA.Selenium.Chrome.ChromeDriver();//открываем Хром
        driver.Navigate().GoToUrl("https://lisa.paymart.uz/ru");//вводим адрес сайта
        driver.Manage().Window.Maximize();//открыть в полном окне
    }

    [Test]
    public void AuthVendor()
    {
        
        SendKeys(_idVendor,idVendor);
        SendKeys(_passwordVendor,passwordVendor);
        Click(_authButton);
        Thread.Sleep(500);
        TestExpectedActual(_exContracts,"Договора");
        Screenshot("AuthVendor");
    }

    
    [Test]
    public void PrintContractAct()//Проверка распечатки Акта клиента
    {
        driver.Manage().Timeouts().ImplicitWait.Add(System.TimeSpan.FromSeconds(5));
        AuthVendor();
        ClickIndexList(_listLeftMenu,1);
        TestExpectedActualNonDigit(_orderStatusTab,"Все договоры ",0);
        TestExpectedActualNonDigit(_orderStatusTab, "На модерации ", 1);
        TestExpectedActualNonDigit(_orderStatusTab, "В рассрочке ", 2);
        TestExpectedActualNonDigit(_orderStatusTab, "Загрузить акт ", 3);
        TestExpectedActualNonDigit(_orderStatusTab, "Просрочен ", 4);
        TestExpectedActualNonDigit(_orderStatusTab, "Отменен ", 5);
        TestExpectedActualNonDigit(_tableContract, "Товар", 0);
        TestExpectedActualNonDigit(_tableContract, "Количество", 1);
        TestExpectedActualNonDigit(_tableContract, "Цена сум", 2);
        TestExpectedActualNonDigit(_tableContract, "Сумма", 3);
        TestExpectedActualNonDigit(_tableContract, "НДС", 4);
        TestExpectedActualNonDigit(_tableContract, "Сумма НДС", 5);
        TestExpectedActualNonDigit(_tableContract, "Всего с НДС", 6);
        TestExpectedActualNonDigit(_btnPrintClientAct,"Распечатать Акт клиента");
        TestExpectedActualNonDigit(_photoClient, "фото клиента");
        TestExpectedActualNonDigit(_act, "AКТ");
        TestExpectedActualNonDigit(_btnCancelContract, "Отменить договор");
        Click(_btnPrintClientAct);
        driver.SwitchTo().Window(driver.WindowHandles[1]);
        DownloadFileToUrl("PrintContractAct.pdf");
    }

    [Test]
    public void CreateContractVendor()
    {
        driver.Manage().Timeouts().ImplicitWait.Add(System.TimeSpan.FromSeconds(5));
        AuthVendor();
        driver.FindElements(_listLeftMenu)[0].Click();
        TestExpectedActual(_exNewContract,"Новый договор");
        SendKeys(_fieldNumberBuyerNewContract,"123456789");
        Screenshot("CreateContractVendor");
        Thread.Sleep(700);
        TestExpectedActualNonDigit(_windowUserNotFound,"Пользователь не найден");
        driver.FindElement(_fieldNumberBuyerNewContract).Clear();
        SendKeys(_fieldNumberBuyerNewContract,"998"+_numberBuyer);
        Thread.Sleep(700);
        Click(_windowAccertNumber);
        TestExpectedActualOnlyDigit(_exNumberBuyer,"998"+_numberBuyer);
        //driver.FindElement(By.XPath("//*[@id='vue-app']/div/div[2]/div/form/div[2]/div[2]/div/div/div[1]/div[1]/div/div/div/div[1]")).Click();
        
    }
    

    [Test]
    public void LanguageSwitchTest()
    {
        AuthVendor();
        if (driver.FindElement(_exNewContract).Text =="Договора")
        {
            Click(_languageSwitch);
            Click(_switchLanguage);
            TestExpectedActual(_exNewContract,"Shartnomalar");
            Screenshot("LanguageSwitchTestUz");
        }
        if (driver.FindElement(_exNewContract).Text =="Shartnomalar")
        {
            Click(_languageSwitch);
            Click(_switchLanguage);
            TestExpectedActual(_exNewContract,"Договора");
            Screenshot("LanguageSwitchTestRus");
        }
        
    }
    [Test]
    public void InstructionDonloadTest()
    {
        AuthVendor();
        ClickIndexList(_listInstruction,0);
        driver.SwitchTo().Window(driver.WindowHandles[1]);
        DownloadFileToUrl("InstructionDownload.pdf");
    }

    [Test]
    public void SideBarTest()
    {
        AuthVendor();
        ClickIndexList(_listInstruction,1);
        TestExpectedActual(_listLeftMenu,"Создать договор",0);
        TestExpectedActual(_listLeftMenu,"Договора",1);
        TestExpectedActual(_listLeftMenu,"Отчеты",2);
        TestExpectedActual(_listLeftMenu,"Регистрация клиента",3);
        TestExpectedActual(_listLeftMenu,"Статус пользователя",4);
        TestExpectedActual(_listLeftMenu,"Калькулятор",5);
        
    }
    [Test]
    public void NegativeAuthPassTest()
    {
        //проверка некорректного пароля
        SendKeys(_idVendor,idVendor);
        Thread.Sleep(200);
        SendKeys(_passwordVendor,passwordVendor+"1");
        Click(_authButton);
        Thread.Sleep(1000);
        var negativeCheck = driver.FindElement(By.XPath("//div[@class='error']")).Text;
        Screenshot("NegativeAuthPassTest");
        Assert.AreEqual(negativeCheck, "Некорректный пароль");
        
        
    }
    [Test]
    public void NegativeAuthIDTests()
    {
        //проверка несуществующего ID
        SendKeys(_idVendor,idVendor+"2");//добавляем к ID цифру 2
        Thread.Sleep(200);
        SendKeys(_passwordVendor,passwordVendor);//и вводим корректный пароль
        Click(_authButton);
        Thread.Sleep(500);
        var negativeCheck = driver.FindElement(By.XPath("//div[@class='error']")).Text;
        Screenshot("NegativeAuthIDTests");
        Assert.AreEqual(negativeCheck, "Данный ID не зарегистрирован");
    }
    [Test]
    public void CancelContractVendor()//проверяем отмену контракта(для позитивного теста необходим смс-код)
    {
        driver.Manage().Timeouts().ImplicitWait.Add(System.TimeSpan.FromSeconds(5));
        AuthVendor();
        
        SendKeys(_fieldFoundContract,_numberFoundContract);
        Click(_btnFoundContract);
        
        TestExpectedActualOnlyDigit(_exСontractBuyer,_numberFoundContract);
        Click(_btnCancelContract);
        TestExpectedActual(_exReasonCancel,"Введите причину отмены договора");
        Click(_btnReasonCancelContract);
        
        TestExpectedActual(_exReasonCancel, "Введите причину отмены договора"); //проверяем активность кнопки с пустым полем
        SendKeys(_fieldReasonCancelContract,"Я хлебушек");
        Click(_btnReasonCancelContract);
        
        TestExpectedActual(_exReasonCancelAssert,"Вы действительно хотите отменить договор?");
        
        driver.FindElements(By.XPath("//div[@class='mx-auto']//button"))[0].Click();
        Thread.Sleep(500);
        driver.FindElements(By.XPath("//div[@class='mx-auto']//button"))[0].Click();
        Thread.Sleep(500);
        Screenshot("CancelContractVendor");
        TestExpectedActual(_exSmsCodeCheck,"СМС код неверный");
        Click(_btnBackCancelContract);
        
        TestExpectedActual(_exInActive,"В Рассрочке");
    }

    [Test]
    public void DebuggerTest()
    {
        AuthVendor();
        Click(_btnDebuggerMaximize);
    }

    [Test]
    public void NewBuyer()
    {
        AuthVendor();
        ClickIndexList(_listLeftMenu,3);
        SendKeys(_fieldNewBuyer,_newBuyer);
        //ClickIndexList(_btnSendSms,0);
        driver.FindElements(By.XPath("//div[@id='newBuyer']/div"))[0].FindElements(_btnSendSms)[0].Click();
        Click(_btnDebuggerMaximize);//открываем дебаггер, если нужно сверить смс-код
      
        
        var smsCode = GetSmsCode(_listDebuggerMessages,0);
        Click(_btnDebuggerMinimize);
        SendKeys(_fieldSmsCodeNewBuyer,smsCode);
        driver.FindElements(By.XPath("//div[@id='newBuyer']/div/div"))[1].FindElements(_btnSendSms)[0].Click();
        //TestsPaymart.AdminTests.AuthAdmin();
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }

}