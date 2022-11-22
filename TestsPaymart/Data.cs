namespace TestsPaymart;

public class Data:General
{
    
    protected string idVendor = "216580";//2
    protected string passwordVendor = "J74DdLwWV32l";//1sOwS0vCTHCS

    public readonly By _orderSt = By.Id("orderStatus");
    protected readonly By _fieldIdVendor = By.Id("inputPartnerId"); //input[@id='inputPartnerId']
    protected readonly By _fieldPasswordVendor = By.Id("inputPassword");
    protected readonly By _authButton = By.XPath("//button[@type='submit']");

    protected string _numberAdmin = "998000000000";
    protected string _passwordAdmin = "Paymart123!";

    protected string _buyerPnfl = "32212986520042";//"30902950200026";
    protected string _passportNumber = "AA9002868";//"AA3869823";
    protected string _buyerCard = "8600492976703658";//"8600492920928161";
    protected string _buyerCardDate = "1125"; //"1226";
    protected string _negativeBuyer = "8940937094";
    protected string _newBuyer = "8998186838"; //"8909831021";// 10 цифр

    protected string _buyerForContract = "998186838";
}