public class TypeOfMinigame
{
    public enum Minigames
    {
        Garbage_Colletion,
        Pizza_Delivery,
        Plumber
    }

}
    
[System.Serializable]
public class MnigamesInformation 
{
    public TypeOfMinigame.Minigames minigames;
    public string description;
    public int minClasicalSalary;
    public int maxClasicalSalary;
    public int minSalaryWithFine;
    public int maxSalaryWithFine;

  
    public MnigamesInformation(string description, TypeOfMinigame.Minigames minigames, int minClasicalSalary, int maxClasicalSalary, int minSalaryWithFine, int maxSalaryWithFine, int precentageOfPriceInrcease, int precentageOfProfitInrcease, int businessLevel)
    {
        this.description = description;
        this.minigames = minigames;
        this.minClasicalSalary = minClasicalSalary;
        this.maxClasicalSalary = maxClasicalSalary;
        this.minSalaryWithFine = minSalaryWithFine;
        this.maxSalaryWithFine = minSalaryWithFine;
    }
}
