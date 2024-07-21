using TMPro;
using UnityEngine;

public class BalanceUpdate : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _balanceText;
    [SerializeField] private TextMeshProUGUI _moneyPerSecondText;
    [SerializeField] private PlayerWallet _playerWallet;
    private void Update()
    {
        _balanceText.text = BalanceConvertor.ConvertMoney(_playerWallet.money);
        _moneyPerSecondText.text =  $"{_playerWallet.moneyPerSecond}/m";
    }
}
