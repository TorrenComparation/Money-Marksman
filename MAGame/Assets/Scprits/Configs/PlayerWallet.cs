using UnityEngine;

[CreateAssetMenu(fileName = "PlayerWallet", menuName = "Configs/PlayerWallet")]
public class PlayerWallet : ScriptableObject
{
    public int money;
    public int moneyPerSecond;
}