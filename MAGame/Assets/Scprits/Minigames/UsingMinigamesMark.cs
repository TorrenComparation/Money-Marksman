using TMPro;
using UnityEngine;

public class UsingMinigamesMark : MonoBehaviour
{

    [Header("Settings Part")]
    [SerializeField] private TextMeshProUGUI[] minigamesPanelTexts;
    [SerializeField] private ShowNotifications notification;
    [SerializeField] private AllMinigames allMinigamesInformation;
    [SerializeField] private TypeOfMinigame.Minigames minigames;
    private int index;
    private void Start()
    {
        InitializeBusinessIndex();
        UpdateInformation();
    }

    private void InitializeBusinessIndex()
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

    public void UpdateInformation()
    {
        var minigamesInfo = allMinigamesInformation.minigamesInfomrations[index];
        Debug.Log(minigames.ToString().Replace("_", " "));
        minigamesPanelTexts[0].text = minigames.ToString().Replace("_", " ");
        minigamesPanelTexts[1].text = minigamesInfo.description;
        minigamesPanelTexts[2].text = $"{minigamesInfo.minClasicalSalary}-{minigamesInfo.maxClasicalSalary}";
        minigamesPanelTexts[3].text = $"{minigamesInfo.minSalaryWithFine}-{minigamesInfo.maxSalaryWithFine}";
    }
}



