[System.Serializable]
 public class BusinessInfomration 
{
    public string typeOfBusiness;
    public string description;
    public int price;
    public int moneyPerSecond;
    public int precentageOfPriceInrcease;
    public int precentageOfProfitInrcease;
    public int businessLevel;

    public BusinessInfomration(string description, string typeOfBusiness, int price, int moneyPerSecond, int precentageOfPriceInrcease, int precentageOfProfitInrcease, int businessLevel)
    {
        this.description = description;
        this.typeOfBusiness = typeOfBusiness;
        this.price = price;
        this.moneyPerSecond = moneyPerSecond;
        this.precentageOfPriceInrcease = precentageOfPriceInrcease;
        this.precentageOfProfitInrcease = precentageOfProfitInrcease;
        this.businessLevel = businessLevel;
    }
}
