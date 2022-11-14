namespace TestsPaymart;

public class Data:General
{
    protected IWebDriver driver;
    protected string idVendor = "2";
    protected string passwordVendor = "1sOwS0vCTHCS";

    public readonly By _orderSt = By.Id("orderStatus");
    protected readonly By _idVendor = By.Id("inputPartnerId"); //input[@id='inputPartnerId']
    protected readonly By _passwordVendor = By.Id("inputPassword");
    protected readonly By _authButton = By.XPath("//button[@type='submit']");

    protected string _numberAdmin = "998000000000";
    protected string _passwordAdmin = "Paymart123!";
}