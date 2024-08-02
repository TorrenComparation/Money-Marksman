using UnityEngine;

public class MinigamesLoader : MonoBehaviour
{
    [SerializeField] private GarbageCollection[] GarbageCollection;
    [SerializeField] private TypeOfMinigame.Minigames minigame;

    public static bool isMinigamePlaying;

    private int currentLocationIndex;

    public void LoadGarbageColletion(int locaionIndex) 
    { 
        isMinigamePlaying = true;
        GarbageCollection[locaionIndex].StartMinigame();
        minigame = TypeOfMinigame.Minigames.Garbage_Colletion;
        currentLocationIndex = locaionIndex;
    }

    public void EndedMinigame()
    {
        isMinigamePlaying = false;

        if (minigame == TypeOfMinigame.Minigames.Garbage_Colletion)
        {
            GarbageCollection[currentLocationIndex].EndMinigame();
        }
        else if(minigame == TypeOfMinigame.Minigames.Pizza_Delivery)
        {

        }
        else if (minigame == TypeOfMinigame.Minigames.Plumber)
        {

        }
    }
}
