using TMPro;
using UnityEngine;

public class MarkUsing : MonoBehaviour
{
    [SerializeField] private  TextMeshProUGUI[] _buyBusinessPanelTexts;
    [SerializeField] private PlayerWallet _walletConfig;

    [SerializeField] private string attention;
    [SerializeField] private string description;
    [SerializeField] private int price;
    [SerializeField] private int moneyPerSecond;

    public void UpdateInformation()
    {
        _buyBusinessPanelTexts[0].text = attention;
        _buyBusinessPanelTexts[1].text = description;
        _buyBusinessPanelTexts[2].text = price.ToString();
        _buyBusinessPanelTexts[3].text = moneyPerSecond.ToString(); 
    }

    public void BuyBusiness()
    {
        if(_walletConfig.money >= price)
        {
            _walletConfig.money -= price;
            _walletConfig.moneyPerSecond += moneyPerSecond;
        }
    }
}
