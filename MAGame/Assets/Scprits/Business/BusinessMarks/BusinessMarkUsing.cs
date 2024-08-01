using TMPro;
using UnityEngine;

public class BusinessMarkUsing : MonoBehaviour
{
    [Header("Settings Part")]
    [SerializeField] private TextMeshProUGUI[] buyBusinessPanelTexts;
    [SerializeField] private ShowNotifications notification;
    [SerializeField] private PlayerWallet walletConfig;
    [SerializeField] private CurrentBusiness businessConfig;
    [SerializeField] private AllBusiness allBusinessInformationConfig;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Gradient markColor;
    [SerializeField] private string businessName;
    [SerializeField] private int maxLevel;

    private int index;

    private void Start()
    {
        InitializeBusinessIndex();
        InitializeBusinessValues();
        UpdateInformation();
    }

    private void InitializeBusinessIndex()
    {
        for (int i = 0; i < allBusinessInformationConfig.businessInfomrations.Count; i++)
        {
            if (allBusinessInformationConfig.businessInfomrations[i].typeOfBusiness == businessName)
            {
                index = i;
                break;
            }
        }
    }

    private void InitializeBusinessValues()
    {
        var businessInfo = allBusinessInformationConfig.businessInfomrations[index];
        if (businessConfig.nameOfBusiness.Contains(businessName))
        {
            ChangeMark();
        }
    }

    public void UpdateInformation()
    {
        var businessInfo = allBusinessInformationConfig.businessInfomrations[index];
        buyBusinessPanelTexts[0].text = businessName;
        buyBusinessPanelTexts[1].text = businessInfo.description;

        if (businessInfo.businessLevel == maxLevel)
        {
            buyBusinessPanelTexts[2].text = "MAX LVL";
            buyBusinessPanelTexts[3].text = "MAX LVL";
            buyBusinessPanelTexts[4].text = "MAX";
        }
        else
        {
            buyBusinessPanelTexts[2].text = businessInfo.price.ToString();
            buyBusinessPanelTexts[3].text = businessInfo.moneyPerSecond.ToString();
            buyBusinessPanelTexts[4].text = $"{businessInfo.businessLevel}/{maxLevel}";
        }
    }

    public void ChooseBusinessMechanic()
    {
        var businessInfo = allBusinessInformationConfig.businessInfomrations[index];
        if (businessInfo.businessLevel < maxLevel)
        {
            if (businessConfig.nameOfBusiness.Contains(businessName))
            {
                UpgradeBusiness();
            }
            else
            {
                BuyBusiness();
            }
        }
    }

    private void BuyBusiness()
    {
        var businessInfo = allBusinessInformationConfig.businessInfomrations[index];
        if (walletConfig.money >= businessInfo.price)
        {
            ChangeMark();
            CalculateResults(businessInfo);
            businessConfig.nameOfBusiness.Add(businessName);
            IncreasePriceAndRevenue(businessInfo);
            businessInfo.businessLevel++;
            UpdateInformation();
        }
        else
        {
            notification.GetNotification("Not enough money");
        }
    }

    private void UpgradeBusiness()
    {
        var businessInfo = allBusinessInformationConfig.businessInfomrations[index];
        if (walletConfig.money >= businessInfo.price)
        {
            CalculateResults(businessInfo);
            IncreasePriceAndRevenue(businessInfo);
            businessInfo.businessLevel++;
            UpdateInformation();
        }
        else
        {
            notification.GetNotification("Not enough money");
        }
    }

    private void ChangeMark()
    {
        var color = _particleSystem.colorOverLifetime;
        color.color = markColor;
    }

    private void CalculateResults(BusinessInfomration businessInfo)
    {
        walletConfig.money -= businessInfo.price;
        walletConfig.moneyPerSecond += businessInfo.moneyPerSecond;
    }

    private void IncreasePriceAndRevenue(BusinessInfomration businessInfo)
    {
        businessInfo.price += businessInfo.price * businessInfo.precentageOfPriceInrcease / 100;
        businessInfo.moneyPerSecond += businessInfo.moneyPerSecond * businessInfo.precentageOfProfitInrcease / 100;
    }
}
