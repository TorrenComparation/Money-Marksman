[System.Serializable]
 public class BusinessInfomration 
{
    public string typeOfBusiness;
    public string description;
    public int price;
    public int moneyPerSecond;
    public int precentageOfPriceInrcease;
    public int precentageOfProfitInrcease;

    public BusinessInfomration(string description, string typeOfBusiness, int price, int moneyPerSecond, int precentageOfPriceInrcease, int precentageOfProfitInrcease)
    {
        this.description = description;
        this.typeOfBusiness = typeOfBusiness;
        this.price = price;
        this.moneyPerSecond = moneyPerSecond;
        this.precentageOfPriceInrcease = precentageOfPriceInrcease;
        this.precentageOfProfitInrcease = precentageOfProfitInrcease;
    }
}
