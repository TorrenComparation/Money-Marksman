using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Business", menuName = "Configs/Business")]
public class Business : ScriptableObject
{
    public List<string> nameOfBusiness = new List<string>();
}
