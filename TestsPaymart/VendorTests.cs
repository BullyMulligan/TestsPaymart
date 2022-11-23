using System.Collections.ObjectModel;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Interactions;

namespace TestsPaymart;

public class VendorTests:Overloads
{
    
    private readonly By _btnPrintClientAct = By.XPath("//a[@class='btn btn-orange mr-2']");
    private readonly By _photoClient = By.XPath("//div[@class='d-flex flex-row-reverse justify-content-between align-items-center custom-file']");
    private readonly By _act = By.XPath("//div[@class='d-flex flex-row-reverse justify-content-between align-items-center custom-file mb-3']");
    private readonly By _btnCancelContract = By.XPath("//button[@class='btn btn-red border-radius-8 w-100']");
    private readonly By _createContract = By.XPath("//a[@title='Договора']");
     
    private string smsCode="";

    [SetUp]
    protected void Setup()
    {
        driver = new OpenQA.Selenium.Chrome.ChromeDriver();//открываем Хром
        driver.Navigate().GoToUrl("https://sasha.paymart.uz/ru");//вводим адрес сайта
        driver.Manage().Window.Maximize();//открыть в полном окне
        driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(10);
        driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
        driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
    }
    

    [Test]
    public void Auth()
    {
        AuthVendor(idVendor,passwordVendor);
        TestExpectedActual(_exContracts,"Договора");
        Screenshot("Успешная авторизация");
    }

    
    [Test]
    public void PrintContractAct()//Проверка распечатки Акта клиента
    {
        AuthVendor(idVendor,passwordVendor);
        Thread.Sleep(500);
        ClickIndexList(_listLeftMenu,1);
        /*TestExpectedActualNonDigit(_orderStatusTab,"Все договоры ",0);
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
        TestExpectedActualNonDigit(_btnCancelContract, "Отменить договор");*/
        if (driver.FindElements(_btnPrintClientAct).Count != 0)
        {
            Click(_btnPrintClientAct);
            driver.SwitchTo().Window(driver.WindowHandles[1]);
            DownloadFileToUrl("АКТ на узбекском(латиница и кириллица) и на русском языках.pdf");
            return;
        }
        Scroll(0,500);
        Screenshot("Отсутствие кнопки Скачать АКТ, так как он находится на модерации");
        
    }

    [Test]
    public void FindBuyerNegativeBuyerNotFound()
    {
        AuthVendor(idVendor,passwordVendor);
        Thread.Sleep(1000);
        driver.FindElements(_listLeftMenu)[0].Click();
        SendKeys(_fieldNumberBuyerNewContract,"123456789");
        Screenshot("CreateContractVendor");
        TestExpectedActualNonDigit(_windowUserNotFound,"Пользователь не найден");
    }
    [Test]
    public void FindBuyerVendor()
    {
        FindBuyer();
        SendKeys(_fieldNumberBuyerNewContract,_buyerForContract);
        Thread.Sleep(200);
        TestExpectedActualOnlyDigit(_exNumberBuyer,"998"+_buyerForContract);
        Screenshot("Номер покупателя:998"+_buyerForContract);
    }
    [Test]
    public void CreateContractVendor()
    {
        var number = "909775979";
        AuthVendor(idVendor,passwordVendor);
        Thread.Sleep(1000);
        FindBuyerCreateContract("1234567890");
        if (driver.FindElement(By.XPath("//div[@class='dropdown-menu show user-info-dropdown']")).Text=="Пользователь не найден")
        {
            Screenshot("Пользователь не найден");
            return;
        }
        Click(_windowUserNotFound);
        Select(_btnActionCategory,0,_selectProductCategory,0);
        Select(_btnActionCategory,1,_selectProductCategory,19);
        Select(_btnActionCategory,2,_selectProductCategory,21);
        Scroll(0,300);
        SendKeys(_fieldProducts,3,"СВЧ-Печь 'Салем 1692'");
        Select(_selectListNewContract,0,0);
        Clear(_fieldProducts,4);
        SendKeys(_fieldProducts,4,"2");
        SendKeys(_fieldProducts,5,"100");
        Select(_selectListNewContract,1,3);
        Thread.Sleep(500);
        Scroll(0,800);
        Click(_btnCreateContract);
        ClickIndexList(_btnSendSms,1);
        TestExpectedActualOnlyDigit(_exContractIsCreated,$"998{number}");
        Screenshot("Договор передан на подтверждение клиенту");
    }
    

    [Test]
    public void LanguageSwitchTest()
    {
        AuthVendor(idVendor,passwordVendor);
        if (driver.FindElement(_exNewContract).Text =="Договора")
        {
            Click(_languageSwitch);
            Click(_switchLanguage);
            TestExpectedActual(_exNewContract,"Shartnomalar");
            Screenshot("Страница на узбекском языке");
        }
        if (driver.FindElement(_exNewContract).Text =="Shartnomalar")
        {
            Click(_languageSwitch);
            Click(_switchLanguage);
            TestExpectedActual(_exNewContract,"Договора");
            Screenshot("Страница на русском языке");
        }
        
    }
    [Test]
    public void InstructionDownloadTest()
    {
        AuthVendor(idVendor,passwordVendor);
        ClickIndexList(_listInstruction,0);
        driver.SwitchTo().Window(driver.WindowHandles[1]);
        DownloadFileToUrl("InstructionDownload.pdf");
    }

    [Test]
    public void SideBarTest()
    {
        AuthVendor(idVendor,passwordVendor);
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
        var check = AuthVendor(idVendor,"123");
        TestExpectedActual(check,"Некорректный пароль");
        Screenshot("Некорректный пароль");
       
    }
    [Test]
    public void NegativeAuthIdTests()
    {
        var check = AuthVendor("123456789","123");
        TestExpectedActual(check,"Данный ID не зарегистрирован");
        Screenshot("Данный ID не зарегистрирован");
        
    }
    [Test]
    public void CancelContractVendor()//проверяем отмену контракта
    {
        AuthVendor(idVendor,passwordVendor);
        FindContract("4");
        if (driver.FindElement(_exStatusContract).Text=="В Рассрочке")
        {
            Click(_btnCancelContract);
            Thread.Sleep(500);
            Click(_btnReasonCancelContract);
            SendKeys(_fieldReasonCancelContract,"Я хлебушек");
            Click(_btnReasonCancelContract);
            driver.FindElements(By.XPath("//div[@class='mx-auto']//button"))[0].Click();
            Thread.Sleep(500);
            SendKeys(_fieldSmsCode,GetSmsCode( 0));
            Click(_btnContractCancel);
            FindContract("4");
            TestExpectedActual(_exStatusContract,"Отменен");
            Screenshot("Контракт отменен");
        }
        else if (driver.FindElement(_exStatusContract).Text=="Отменен")
        {
            Screenshot("Контракт был отменен ранее");
        }
        
        
    }
    [Test]
    public void DebuggerTest()
    {
        AuthVendor(idVendor,passwordVendor);
        Click(_btnDebuggerMaximize);
    }
    
    [Test]
    public void NewBuyerSolvency()//проверка платежеспособности
    {
        AuthVendor(idVendor,passwordVendor);
        NewBuyerBeforeAddCard(_negativeBuyer);
        
        if ((driver.FindElements(_exNewBuyerIsReg).Count == 0))
        {
            By check = NewBuyerAddCard("8600492934548781","1027");
            Scroll(0,300);
            Screenshot("Карта не прошла проверку платежеспособности");
            TestExpectedActual(check,"Карта не прошла проверку платежеспособности! Укажите другую карту.");
        }
        else if(driver.FindElements(_exNewBuyerIsReg).Count == 0)
        {
            TestExpectedActual(_exNewBuyerIsReg,"Данный пользователь уже зарегистрирован!");
        }
        
        
    }
    [Test]
    public void NewBuyerCardNotBuyers()//проверка, является ли покупатель хозяином карты
    {
        AuthVendor(idVendor,passwordVendor);
        NewBuyerBeforeAddCard(_newBuyer);
        if ((driver.FindElements(_exNewBuyerIsReg).Count==0))
        {
            By check = NewBuyerAddCard("8600492934548781","1027");
            TestExpectedActual(check,"Телефон клиента не совпадает с телефоном смс информирования карты");
            Scroll(0,300);
            Screenshot("Карта клиента не привязана к телефоне");
        }
        else if(driver.FindElements(_exNewBuyerIsReg).Count!=0)
        {
            TestExpectedActual(_exNewBuyerIsReg,"Данный пользователь уже зарегистрирован!");
        }
        
    }
    [Test]
    public void NewBuyer()
        /*Данный тест универсален. Если пользователь уже зарегал карту или залил фотографии и отложил регистрацию,
         то запустив тест, мы начнем с незавершенного шага. Также, если пользователь зарегистрирован,
         то тест покажет, статус клиента*/
    {
        AuthVendor(idVendor,passwordVendor);
        NewBuyerBeforeAddCard(_newBuyer);
        if (driver.FindElements(By.XPath("//div[@class='alert alert-success']")).Count != 0)
        {
            if (driver.FindElement(_exWaitingForModerate).Text == "Данный пользователь уже зарегистрирован!")
            {
                Screenshot("Пользователь уже зарегистирован");
                return;
            }
        }
        if (driver.FindElements(By.XPath("//div[@class='alert alert-success']")).Count==0)
        {
            NewBuyerAddCard(_buyerCard,_buyerCardDate);
        }
        
        if (driver.FindElements(By.XPath("//div[@class='alert alert-success']")).Count==1)
        {
            NewBuyerAddPhotos();
        }
        Thread.Sleep(1000);
        if (driver.FindElements(By.XPath("//div[@class='alert alert-success']")).Count==2)
        {
            NewBuyerAddContactFace();
        }
        if (driver.FindElements(By.XPath("//p[@class='font-size-18 mt-3']")).Count!=0)
        {
            TestExpectedActual(_exClientIsReg, "Покупатель успешно отправлен на модерацию!");
            Screenshot("Покупатель успешно отправлен на модерацию!");
            return;
        }
        if (driver.FindElements(By.XPath("//div[@class='alert alert-success']")).Count==3)
        {
            TestExpectedActual(_exWaitingForModerate, "В ожидании модерции");
            Screenshot("В ожидании модерации");
        }
    }
    
    [TearDown]
    public void TearDown()
    {
        //driver.Quit();
    }

    public void FindContract(string number)
    {
        Thread.Sleep(500);
        ClickIndexList(_listLeftMenu,1);
        Thread.Sleep(500);
        SendKeys(_fieldFoundContract,number);
        Click(_btnFoundContract);
    }
    public void NewBuyerBeforeAddCard(string phone)
    {
        Thread.Sleep(500);
        ClickIndexList(_listLeftMenu, 3);
        SendKeys(_fieldNewBuyer, phone);
        driver.FindElements(By.XPath("//div[@id='newBuyer']/div"))[0].FindElements(_btnSendSms)[0].Click();
        Click(_btnDebuggerMaximize); //открываем дебаггер, если нужно сверить смс-код
        Thread.Sleep(300);
        Click(_btnDebuggerMinimize);
        SendKeys(_fieldSmsCodeNewBuyer, GetSmsCode( 0));
        driver.FindElements(By.XPath("//div[@id='newBuyer']/div/div"))[1].FindElements(_btnSendSms)[0].Click();
        
    }

    public By NewBuyerAddCard(string card,string cardDate)
    {
        SendKeys(_fieldCardBuyer, card);
        SendKeys(_fieldCardDate,cardDate);
        Thread.Sleep(300);
        driver.FindElements(By.XPath("//div[@id='newBuyer']/div"))[0].FindElements(_btnSendSms)[0].Click();
        Thread.Sleep(200);
        if (driver.FindElements(By.XPath("//div[@class='error']")).Count!=0)
        {
            return By.XPath("//div[@class='error']");
        }
        SendKeys(_fieldSmsCheck,GetSmsCode(29));
        Thread.Sleep(300);
        Scroll(0,200);
        ClickIndexList(_btnSendSms,0);
        return By.XPath("//div[@id='newBuyer']/div/div");
    }

    public void NewBuyerAddPhotos()
    {
        attachFile(driver,_attachPassportSelfie,"C:/Users/ipopov/RiderProjects/TestsPaymart/TestsPaymart/File/1.jpg" );
        attachFile(driver,_attachPassportFirstPage,"C:/Users/ipopov/RiderProjects/TestsPaymart/TestsPaymart/File/1.jpg");
        attachFile(driver,_attachPassportAdressPage,"C:/Users/ipopov/RiderProjects/TestsPaymart/TestsPaymart/File/1.jpg");
        Thread.Sleep(200);
        driver.ExecuteJavaScript("window.scrollTo(0,700)");
        Thread.Sleep(300);
        Click(_btnSavePhotos);
        
    }

    public void NewBuyerAddContactFace()
    {
        driver.FindElements(_fieldContactFaceOne)[0].SendKeys("Brad Pitt");
        driver.FindElements(_fieldContactFaceOne)[1].SendKeys("Хлеб Питт");
        driver.FindElements(_fieldContactFaceNumber)[0].SendKeys("123456789");
        driver.FindElements(_fieldContactFaceNumber)[1].SendKeys("098765432");
        Click(_btnAddContact);
    }

    public void FindBuyerCreateContract(string number)
    {
        driver.FindElements(_listLeftMenu)[0].Click();
        SendKeys(_fieldNumberBuyerNewContract,number);
        Thread.Sleep(1000);
        
    }
    
}