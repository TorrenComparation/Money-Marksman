using UnityEngine;

public class MinigamesLoader : MonoBehaviour
{
    [SerializeField] private GarbageCollection[] GarbageCollection;
    
    public void LoadGarbageColletion(int locaionIndex) => GarbageCollection[locaionIndex].StartMinigame();
    
}
