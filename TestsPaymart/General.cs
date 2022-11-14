namespace TestsPaymart;

public class General:Global
{
    
    protected string _numberFoundContract = "6";
    protected readonly By _fieldFoundContract = By.XPath("//input[@type='text']");
    protected readonly By _btnFoundContract = By.XPath("//button[@type='submit']");
    protected readonly By _btnReasonCancelContract = By.XPath("//form[@enctype='multipart/form-data']//button[@type='submit']");
    protected readonly By _fieldReasonCancelContract = By.XPath("//form[@enctype='multipart/form-data']//textarea");
    protected readonly By _fieldSmsCode = By.XPath("//input[@id='cancelSmsCode']");
    protected readonly By _btnTotalCancelContract = By.XPath("//div/button[@class='btn btn-orange text-white modern-shadow mt-3 mx-auto w-100 px-5 py-3']");
    protected readonly By _btnBackCancelContract = By.XPath("//img[@src='https://lisa.paymart.uz/images/icons/icon_arrow_orange.svg']");
    protected readonly By _btnSmsCheckCancelContract = By.XPath("//div[@class='mx-auto']//button");
    
    protected readonly By _exСontractBuyer = By.XPath("//div[@style='word-break: break-word; width: 55%;']/span[@class='number']");
    protected readonly By _exReasonCancel = By.XPath("//h5[@class='reason__title']");
    protected readonly By _exReasonCancelAssert = By.XPath("//div[@class='font-weight-900 font-size-40 text w-75 text-center mx-auto']");
    protected readonly By _exSmsCodeCheck = By.XPath("//p[@class='text-red text-center mt-2']");
    protected readonly By _exInActive = By.XPath("//div[@class='order-status-container completed']");
    protected static readonly By _exContracts = By.XPath("//div[@class='title']//h1"); 
    protected static readonly By _listLeftMenu = By.XPath("//ul[@class='list-group list-group-flush mt-3']//a");//Левое меню
    protected static readonly By _tableContract = By.XPath("//table[@class='products table-bordered']//tr//th");
    protected static readonly By _orderStatusTab = By.XPath("//ul[@id='orderStatus']//li");
    protected static readonly By _exNewContract = By.XPath("//div[@class='title']//h1");
    protected static readonly By _fieldNumberBuyerNewContract = By.XPath("//div//input[@required='required']");
    protected static readonly By _windowAccertNumber = By.XPath("//div//a[@class='dropdown-item']");
    protected static readonly By _windowUserNotFound = By.XPath("//div[@class='dropdown-menu show user-info-dropdown']/div");
    protected static readonly By _exNumberBuyer =By.XPath("//div[@class='font-weight-normal mb-2']");
    protected static readonly By _listCatalogTitleRight = By.XPath("//div[@class='title-right']//a");
    protected static readonly By _exFieldsErrors = By.XPath("//span[@class='validation-error']");
    protected static readonly By _listItem = By.XPath("//div[@class='list']");
    protected static readonly By _buttonListCategory = By.XPath("//div[@class='multiselect__select']");
    protected static readonly By _listCategoryes = By.XPath("//div[@class='row align-items-end']");
    protected static readonly By _listCategoryProduct = By.XPath("//div[@class='form-group col-12 col-sm-3 position-relative']");
    protected static readonly By _listIntoSetCategory = By.XPath("//li[@class='multiselect__element']/span");
    protected static readonly By _listInstruction = By.XPath("//div[@class='instruction']/a");
    protected static readonly By _languageSwitch = By.XPath("//a[@class='dropdown-toggle']/img");

    protected static readonly By _switchLanguage = By.XPath("//div[@class='dropdown-menu dropdown-menu-right show']/a/img");

    //Debugger
    protected static readonly By _btnDebuggerMaximize = By.XPath("//a[@class='phpdebugbar-maximize-btn']");
    protected static readonly By _btnDebuggerMinimize = By.XPath("//a[@class='phpdebugbar-minimize-btn']");
    protected static readonly By _listDebuggerMessages = By.XPath("//div[@class='phpdebugbar-panel phpdebugbar-active']//ul//li");
    //NewBuyer
    protected static readonly By _fieldNewBuyer = By.Id("inputPhone");
    protected static readonly By _fieldSmsCodeNewBuyer = By.Id("phoneInputSMSCode");
    protected static readonly By _rowNewBuyer = By.XPath("//div[@id = 'newBuyer']//div[@class= 'form-row']");
    protected static readonly By _btnSendSms = By.XPath("//button[@class='btn btn-orange']");
    
    
    //Admin Side
    //Auth Page
    protected readonly By _btnAuthAdmin = By.XPath("//button[@class='btn btn-orange btn-block']");
    protected readonly By _fieldIdAuth = By.Id("inputPhone");
    protected readonly By _fieldPasswordAuth = By.Id("inputPassword");
    protected readonly By _expErrorEmtyNumber = By.XPath("//div[@class='error']");

    //Employees Page
    protected readonly By _expEmployees = By.XPath("//div[@class='d-flex flex-column']/h1");
    
    //Sidebar
    protected readonly By _btnSideBarOpen = By.Id("sidebar-toggle");
}