using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UsingMinigamesMark : MonoBehaviour
{
    [Header("UI Part")]
    [SerializeField] private TextMeshProUGUI[] minigamesPanelTexts;
    [SerializeField] private ShowNotifications notification;
    [SerializeField] private Button onButtonClick;
    [Header("Minigame configuration")]
    [SerializeField] private TypeOfMinigame.Minigames minigames;
    [SerializeField] private AllMinigames allMinigamesInformation;
    [SerializeField] private FreezeMark freezeMark;
    [SerializeField] private MinigamesLoader minigamesLoader;
    [SerializeField] private int numberOfPlace; 

    private int index;
    private void Start()
    {
        InitializeMinigameIndex();
        UpdateInformation();
        onButtonClick.onClick.AddListener(LoadMinigame);
    }

    private void InitializeMinigameIndex()
    {
        for (int i = 0; i < allMinigamesInformation.minigamesInfomrations.Count; i++)
        {
            if (minigames == allMinigamesInformation.minigamesInfomrations[i].minigames)
            {
                index = i;
                break;
            }
        }
    }

    private void UpdateInformation()
    {
        var minigamesInfo = allMinigamesInformation.minigamesInfomrations[index];
        minigamesPanelTexts[0].text = minigames.ToString().Replace("_", " ");
        minigamesPanelTexts[1].text = minigamesInfo.description;
        minigamesPanelTexts[2].text = $"{minigamesInfo.classicalSalary * 30}-{minigamesInfo.classicalSalary * 50}";
        minigamesPanelTexts[3].text = $"{minigamesInfo.salaryWithFine*1}-{minigamesInfo.salaryWithFine * 29}";
    }

    private void LoadMinigame()
    {
        if(minigames == TypeOfMinigame.Minigames.Garbage_Colletion)
        {
            freezeMark.DelayBetweenMinigame();
            minigamesLoader.LoadGarbageColletion(numberOfPlace);
        }
    }
}



