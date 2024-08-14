using System.Collections.Generic;
using UnityEngine;

public class GarbageCollection : MonoBehaviour
{
    [Header("Minigame configuration")]
    [SerializeField] private GameObject[] garbage;
    [SerializeField] private GameObject minigameObject;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private TypeOfMinigame.Minigames minigames;

    [Header("UI")]
    [SerializeField] private Timer timer;
    [SerializeField] private ShowNotifications notification;

    [Header("Configs")]
    [SerializeField] private AllMinigames allMinigamesInformation;
    [SerializeField] private ItemConfig itemConfig;
    [SerializeField] private PlayerWallet walletConfig;

    [Header("Timer Settings")]
    [SerializeField] private int minutes;
    [SerializeField] private int seconds;

    private int countOfGarbage;
    private int index;

    private bool isPlaying;

    private const int minCountOfGarbage = 30;
    private const int maxCountOfGarbage = 51;


    public void StartMinigame()
    {
        isPlaying = true;
        minigameObject.SetActive(true);
        timer.StartMinigame(minutes, seconds);
        InitializeMinigameIndex();
        SetPlayerPosition();
        DisableGarbage();
        GenerateGarbage();
        ClearConfig();
    }

    public void EndMinigame()
    {
        isPlaying = false;
        minigameObject.SetActive(false);
        timer.StopTimer();
        SetPlayerPosition();
        notification.GetNotification($"Erned {AccuralMoney()}$");
    }

    private void GenerateGarbage()
    {
        List<int> indices = new List<int>();
        countOfGarbage = Random.Range(minCountOfGarbage, maxCountOfGarbage);

        for (int i = 0; i < garbage.Length; i++)
        {
            indices.Add(i);
        }
        for (int i = 0; i < indices.Count; i++)
        {
            int temp = indices[i];
            int randomIndex = Random.Range(i, indices.Count);
            indices[i] = indices[randomIndex];
            indices[randomIndex] = temp;
        }
        for (int i = 0; i < countOfGarbage; i++)
        {
            int index = indices[i];
            garbage[index].SetActive(true);
        }
    }

    private void DisableGarbage()
    {
        for (int i = 0; i < garbage.Length; i++)
        {
            if (garbage[i].activeInHierarchy)
            {
                garbage[i].SetActive(false);
            }
        }
    }

    private void SetPlayerPosition()
    {
        if (isPlaying && characterController != null)
        {
            characterController.enabled = false;
            characterController.transform.position = spawnPosition.position;
            characterController.enabled = true;
        }
    }

    private long AccuralMoney()
    {
        var minigameInfo = allMinigamesInformation.minigamesInfomrations[index];
        long ernedMoney;
        if(itemConfig.itemsCleared == itemConfig.itemsInLevel)
        {
            ernedMoney = (long)(itemConfig.itemsCleared * minigameInfo.classicalSalary * minigameInfo.salaryMultiply);
        }
        else
        {
            ernedMoney = (long)(itemConfig.itemsCleared * minigameInfo.salaryWithFine * minigameInfo.salaryMultiply);
        }
        walletConfig.money += ernedMoney;
        return ernedMoney;
    }

    private void ClearConfig()
    {
        itemConfig.items = 0;
        itemConfig.itemsCleared = 0;
        itemConfig.itemsInLevel = countOfGarbage;
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
}
