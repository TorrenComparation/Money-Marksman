using UnityEngine;

[ExecuteInEditMode]
public class DayTime : MonoBehaviour
{
    [SerializeField] private Gradient directionalLightGradient;
    [SerializeField] private Gradient ambientLightGradient;
    [SerializeField, Range(1, 1440)] private float timeDayInSeconds;
    [SerializeField, Range(0f, 1f)] private float timeProgress;
    [SerializeField] private Light directionalLight;
    private Vector3 defaultAngles;
    private void Start()
    {
        defaultAngles = directionalLight.transform.localEulerAngles;
    }
    private void Update()
    {
        if (Application.isPlaying)
        {
            timeProgress += Time.deltaTime / timeDayInSeconds;
        }
        if (timeProgress > 1f)
        {
            timeProgress = 0f;
        }

        directionalLight.color = directionalLightGradient.Evaluate(timeProgress);
        RenderSettings.ambientLight = ambientLightGradient.Evaluate(timeProgress);
        directionalLight.transform.localEulerAngles = new Vector3(360f * timeProgress - 90, defaultAngles.x, defaultAngles.z);
    }
}
