using System.Collections;
using UnityEngine;

public class FreezeMark : MonoBehaviour
{
    [SerializeField] private GameObject mainMinigamePart;
    [SerializeField] private float minutesOfDelay;
    public void DelayBetweenMinigame() => StartCoroutine(StartDelay());
    
    private IEnumerator StartDelay()
    {
        Debug.Log("Delay Started");
        mainMinigamePart.SetActive(false);
        yield return new WaitForSeconds(minutesOfDelay * 60f);
        mainMinigamePart.SetActive(true);
    }
}
