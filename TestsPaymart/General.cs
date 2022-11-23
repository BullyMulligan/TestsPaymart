namespace TestsPaymart;

public class General:Global
{
    
    //
    protected string _numberFoundContract = "4";
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
    protected readonly By _exContracts = By.XPath("//div[@class='title']//h1"); 
    protected readonly By _listLeftMenu = By.XPath("//ul[@class='list-group list-group-flush mt-3']//a");//Левое меню
    protected readonly By _tableContract = By.XPath("//table[@class='products table-bordered']//tr//th");
    protected readonly By _orderStatusTab = By.XPath("//ul[@id='orderStatus']//li");
    protected readonly By _exNewContract = By.XPath("//div[@class='title']//h1");
    //New contract
    protected readonly By _fieldNumberBuyerNewContract = By.XPath("//div//input[@required='required']");
    protected readonly By _windowAccertNumber = By.XPath("//div//a[@class='dropdown-item']");
    protected readonly By _windowUserNotFound = By.XPath("//a[@class='dropdown-item']");
    protected readonly By _exNumberBuyer =By.XPath("//div[@class='font-weight-normal mb-2']");
    protected readonly By _btnActionCategory = By.XPath("//div[@bg-color='grey']");
    protected readonly By _selectProductCategory = By.XPath("//ul[@class='multiselect__content']/li");
    protected readonly By _fieldProducts = By.XPath("//input[@autocomplete='off']");
    protected readonly By _selectListNewContract = By.XPath("//select");
    protected readonly By _exContractIsCreated = By.XPath("//div[@class='mb-2']");
    protected readonly By _btnCreateContract = By.Id("submitOrder");
    
    //Cancel contract
    protected readonly By _btnContractCancel = By.XPath("//button[@class='btn btn-orange text-white modern-shadow mt-3 mx-auto w-100 px-5 py-3']");
    protected readonly By _exStatusContract = By.XPath("//div[@class='col-12 col-md-4 pr-0']//div");
   

    protected readonly By _listCatalogTitleRight = By.XPath("//div[@class='title-right']//a");
    protected readonly By _exFieldsErrors = By.XPath("//span[@class='validation-error']");
    protected readonly By _listItem = By.XPath("//div[@class='list']");
    protected readonly By _buttonListCategory = By.XPath("//div[@class='multiselect__select']");
    protected readonly By _listCategoryes = By.XPath("//div[@class='row align-items-end']");
    protected readonly By _listCategoryProduct = By.XPath("//div[@class='form-group col-12 col-sm-3 position-relative']");
    protected readonly By _listIntoSetCategory = By.XPath("//li[@class='multiselect__element']/span");
    protected readonly By _listInstruction = By.XPath("//div[@class='instruction']/a");
    protected readonly By _languageSwitch = By.XPath("//a[@class='dropdown-toggle']/img");

    protected readonly By _switchLanguage = By.XPath("//div[@class='dropdown-menu dropdown-menu-right show']/a/img");

    //Debugger
    protected readonly By _btnDebuggerMaximize = By.XPath("//a[@class='phpdebugbar-maximize-btn']");
    protected readonly By _btnDebuggerMinimize = By.XPath("//a[@class='phpdebugbar-minimize-btn']");
    protected readonly By _listDebuggerMessages = By.XPath("//div[@class='phpdebugbar-panel phpdebugbar-active']//ul//li");
    //NewBuyer
    protected readonly By _fieldNewBuyer = By.Id("inputPhone");
    protected readonly By _fieldSmsCodeNewBuyer = By.Id("phoneInputSMSCode");
    protected readonly By _rowNewBuyer = By.XPath("//div[@id = 'newBuyer']//div[@class= 'form-row']");
    protected readonly By _btnSendSms = By.XPath("//button[@class='btn btn-orange']");
    protected readonly By _fieldCardBuyer = By.Id("inputCardNumber");
    protected readonly By _fieldCardDate = By.Id("inputCardExp");
    protected readonly By _fieldSmsCheck = By.Id("sms-code-input");
    protected readonly By _attachPassportSelfie = By.Id("passport_selfie");
    protected readonly By _attachPassportFirstPage = By.Id("passport_first_page");
    protected readonly By _attachPassportAdressPage = By.Id("passport_with_address");
    protected readonly By _btnSavePhotos = By.XPath("//div[@class='form-controls']//button");
    protected readonly By _fieldContactFaceOne =By.Id("name");
    protected readonly By _fieldContactFaceNumber = By.Id("phone");
    protected readonly By _btnAddContact = By.XPath("//div[@class='form-controls mt-0 pt-0']//button");
    protected readonly By _exNewBuyerIsReg = By.XPath("//div[@class='alert alert-info']");
    protected readonly By _exWaitingForModerate = By.XPath("//div[@class='alert alert-info']");
    protected readonly By _exClientIsReg = By.XPath("//div[@class='font-weight-900 font-size-40 text']");
    
    
    
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
    protected readonly By _listSideBarMenu = By.XPath("//div[@class='menu']/ul/ul/li");
    
    //Clients Page
    protected readonly By _fieldSearchClient = By.XPath("//input[@type='search']");
    protected readonly By _btnSearchClient = By.XPath("//button[@class='btn btn-success btn-search']");
    protected readonly By _listScoringCient = By.XPath("//div[@class='scoring_katm']/div/input");
    protected readonly By _btnModerate = By.XPath("//button[@class='btn btn-outline-primary']");
    protected readonly By _btnAddCard = By.XPath("//button[@class='btn btn-light']");
    protected readonly By _fieldCardNumber = By.XPath("//input[@placeholder='8600 0000 0000 0000']");
    protected readonly By _fieldCadrdDate = By.XPath("//input[@placeholder='00/00']");
    protected readonly By _btnSendSmsScoring = By.XPath("//button[@class='btn btn-primary']");
    protected readonly By _fieldConfirmCode =By.Id("confirm-code");
    protected readonly By _btnCheckCode = By.XPath("//button[@class='btn btn-primary']");
    protected readonly By _btnScoring =By.XPath("//button[@style='cursor: pointer;']");
    protected readonly By _exStatusScoring = By.XPath("//td[@style='text-align: left;']");
    protected readonly By _exScoringIsPassed = By.XPath("//table[@class='table']//th");
    protected readonly By _exClientTab = By.XPath("//td[@valign='top']");
}