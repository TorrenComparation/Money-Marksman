using TMPro;
using UnityEngine;

public class MarkUsing : MonoBehaviour
{
    [SerializeField] private Animator _notifAnimator;
    [SerializeField] private  TextMeshProUGUI[] _buyBusinessPanelTexts;
    [SerializeField] private PlayerWallet _walletConfig;
    [SerializeField] private Business _businessConfig;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Gradient _markColor;

    [Header("Main Part")]
    [SerializeField] private string attention;
    [SerializeField] private string description;
    [SerializeField] private int price;
    [SerializeField] private int moneyPerSecond;
    [SerializeField] private string typeOfBusiness;

    private void Start()
    {
        for (int i = 0; i < _businessConfig.nameOfBusiness.Count; i++)
        {
            if (_businessConfig.nameOfBusiness[i] == typeOfBusiness)
            {
                ChangeMark();

                price += 100000;
                moneyPerSecond += 100;
            }

        }

    }
    public void UpdateInformation()
    {
        _buyBusinessPanelTexts[0].text = attention;
        _buyBusinessPanelTexts[1].text = description;
        _buyBusinessPanelTexts[2].text = price.ToString();
        _buyBusinessPanelTexts[3].text = moneyPerSecond.ToString();
    }

    private void BuyBusiness()
    {
        if (_walletConfig.money >= price)
        {
            ChangeMark();
            CalculateResults();
            _businessConfig.nameOfBusiness.Add(typeOfBusiness);

            price += 100000;
            moneyPerSecond += 100;
        }
    }

    private void ChangeMark()
    {
        var color = _particleSystem.colorOverLifetime;
        color.color = _markColor;
    }

    public void ChooseBusinessMechanic()
    {
        if (_businessConfig.nameOfBusiness.Count == 0)
        {
            BuyBusiness();
        }
        else
        {
            for (int i = 0; i < _businessConfig.nameOfBusiness.Count; i++)
            {
                if (_businessConfig.nameOfBusiness[i] != typeOfBusiness)
                {
                    BuyBusiness();
                }
                else
                {
                    UpgradeBusiness();

                   
                }
            }
        }
    }
    private void UpgradeBusiness()
    {

        if (_walletConfig.money >= price)
        {
            CalculateResults();
            price += 100000;
            moneyPerSecond += 100;
        }
    }

    private void CalculateResults()
    {
        _walletConfig.money -= price;
        _walletConfig.moneyPerSecond += moneyPerSecond;
    }
}
