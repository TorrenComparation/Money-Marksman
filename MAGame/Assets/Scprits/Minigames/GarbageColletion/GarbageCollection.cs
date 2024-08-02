using System.Collections.Generic;
using UnityEngine;

public class GarbageCollection : MonoBehaviour
{
    [SerializeField] private GameObject[] garbage;
    [SerializeField] private GameObject minigame;
    [SerializeField] private Transform spawnPosition;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private ItemConfig itemConfig;
    [SerializeField] private Timer timer;


    [Header("Timer Settings")]
    [SerializeField] private int minutes;
    [SerializeField] private int seconds;

    private Vector3 lastPlayerPosition;

    private const int minCountOfGarbage = 30;
    private const int maxCountOfGarbage = 51;
    private int countOfGarbage;

    public void StartMinigame()
    {
        minigame.SetActive(true);
        timer.StartMinigame(minutes, seconds);
        ClearConfig();
        SetPlayerPosition();
        DisableGarbage();
        GenerateGarbage();
    }

    private void GenerateGarbage()
    {
        List<int> indices = new List<int>();
        int countOfGarbage = Random.Range(minCountOfGarbage, maxCountOfGarbage);
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

        
        if(characterController != null)
        {
            lastPlayerPosition = characterController.transform.position;
            characterController.enabled = false;
            characterController.transform.position = spawnPosition.position;
            characterController.enabled = true;
        }
    }

    private void ClearConfig()
    {
        itemConfig.items = 0;
        itemConfig.itemsInLevel = countOfGarbage;
    }
}
