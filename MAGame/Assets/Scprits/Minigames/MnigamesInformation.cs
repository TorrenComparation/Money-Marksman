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
    public int classicalSalary;
    public int salaryWithFine;
    public float salaryMultiply;

  
    public MnigamesInformation(string description, TypeOfMinigame.Minigames minigames, int classicalSalary, int salaryWithFine, float salaryMultiply)
    {
        this.description = description;
        this.minigames = minigames;
        this.classicalSalary = classicalSalary;
        this.salaryWithFine = salaryWithFine;
        this.salaryMultiply = salaryMultiply;
    }
}
