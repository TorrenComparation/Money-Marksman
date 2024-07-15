using TMPro;
using System;
using UnityEngine;

public class MarkUsing : MonoBehaviour
{
    [Header("Settings Part")]
    [SerializeField] private TextMeshProUGUI[] _buyBusinessPanelTexts;
    [SerializeField] private ShowNotifications _notification;
    [SerializeField] private PlayerWallet _walletConfig;
    [SerializeField] private CurrentBusiness _businessConfig;
    [SerializeField] private AllBusiness _allBusinessInformationConfig;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Gradient _markColor;
    [SerializeField] private string businessName;
    public int _index;

    private void Start()
    {
        InitializeBusinessIndex();
        InitializeBusinessValues();
    }

    private void InitializeBusinessIndex()
    {
        for (int i = 0; i < _allBusinessInformationConfig.businessInfomrations.Count; i++)
        {
            if (_allBusinessInformationConfig.businessInfomrations[i].typeOfBusiness == businessName)
            {
                _index = i;
                break; // Оптимизация: выходим из цикла после нахождения
            }
        }
    }

    private void InitializeBusinessValues()
    {
        if (_businessConfig.nameOfBusiness.Contains(businessName))
        {
            var businessInfo = _allBusinessInformationConfig.businessInfomrations[_index];
            ChangeMark();
            IncreasePriceAndRevenue(businessInfo);
            UpdateInformation(businessInfo);
        }
    }

    public void UpdateInformation(BusinessInfomration businessInfo)
    {
        _buyBusinessPanelTexts[0].text = businessName;
        _buyBusinessPanelTexts[1].text = businessInfo.description;
        _buyBusinessPanelTexts[2].text = businessInfo.price.ToString();
        _buyBusinessPanelTexts[3].text = businessInfo.moneyPerSecond.ToString();
    }

    public void ChooseBusinessMechanic()
    {
        if (_businessConfig.nameOfBusiness.Contains(businessName))
        {
            UpgradeBusiness();
        }
        else
        {
            BuyBusiness();
        }
    }

    private void BuyBusiness()
    {
        var businessInfo = _allBusinessInformationConfig.businessInfomrations[_index];
        if (_walletConfig.money >= businessInfo.price)
        {
            ChangeMark();
            CalculateResults(businessInfo);
            _businessConfig.nameOfBusiness.Add(businessName);
            IncreasePriceAndRevenue(businessInfo);
        }
        else
        {
            _notification.NotEnoughtMoney();
        }
    }

    private void UpgradeBusiness()
    {
        var businessInfo = _allBusinessInformationConfig.businessInfomrations[_index];
        if (_walletConfig.money >= businessInfo.price)
        {
            CalculateResults(businessInfo);
            IncreasePriceAndRevenue(businessInfo);
        }
    }

    private void ChangeMark()
    {
        var color = _particleSystem.colorOverLifetime;
        color.color = _markColor;
    }

    private void CalculateResults(BusinessInfomration businessInfo)
    {
        _walletConfig.money -= businessInfo.price;
        _walletConfig.moneyPerSecond += businessInfo.moneyPerSecond;
    }

    private void IncreasePriceAndRevenue(BusinessInfomration businessInfo)
    {
        businessInfo.price += businessInfo.price * businessInfo.precentageOfPriceInrcease / 100;
        businessInfo.moneyPerSecond += businessInfo.moneyPerSecond * businessInfo.precentageOfProfitInrcease / 100;
    }
}