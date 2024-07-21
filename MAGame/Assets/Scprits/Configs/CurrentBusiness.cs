using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CurrentBusiness", menuName = "Configs/Business")]
public class CurrentBusiness : ScriptableObject
{
    public List<string> nameOfBusiness = new List<string>();
}
