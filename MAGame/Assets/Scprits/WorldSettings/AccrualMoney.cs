using UnityEngine;

public class AccrualMoney : MonoBehaviour
{
    [SerializeField] private PlayerWallet _walletConfig;
    private void Start()
    {
        InvokeRepeating("UpdateBalance", 1f, 1f);
    }
    private void UpdateBalance() => _walletConfig.money += _walletConfig.moneyPerSecond;
}
