using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingForPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _confirmPanel;
    [SerializeField] private MarkInformation _information;
    [SerializeField] private FreezePlayer _freezePlayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _confirmPanel.SetActive(true);
            _freezePlayer.ChangeConfiguration(false);
        }
    }

    public void ClosePanel()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _confirmPanel.SetActive(false);
        _freezePlayer.ChangeConfiguration(true);
    }
}
