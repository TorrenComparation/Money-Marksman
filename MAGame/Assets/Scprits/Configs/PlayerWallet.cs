using UnityEngine;

[CreateAssetMenu(fileName = "PlayerWallet", menuName = "Configs/PlayerWallet")]
public class PlayerWallet : ScriptableObject
{
    public long money;
    public int moneyPerSecond;
}