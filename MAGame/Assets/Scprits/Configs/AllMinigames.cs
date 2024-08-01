using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AllMinigames", menuName = "Configs/AllMinigames")]
public class AllMinigames : ScriptableObject
{
    public List<MnigamesInformation> minigamesInfomrations = new List<MnigamesInformation>();
}