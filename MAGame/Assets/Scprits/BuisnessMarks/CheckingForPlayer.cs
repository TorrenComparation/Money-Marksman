using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingForPlayer : MonoBehaviour
{
    [SerializeField] private GameObject confirmPanel;
    [SerializeField] private MarkInformation information;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            confirmPanel.SetActive(true); 
        }
    }
}
