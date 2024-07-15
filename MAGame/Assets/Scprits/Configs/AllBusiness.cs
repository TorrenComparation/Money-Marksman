using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AllBusiness", menuName = "Configs/AllBusiness")]
public class AllBusiness : ScriptableObject
{
    public List<BusinessInfomration> businessInfomrations = new List<BusinessInfomration>();
}
