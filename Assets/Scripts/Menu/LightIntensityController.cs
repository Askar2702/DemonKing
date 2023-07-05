using UnityEngine;

public class LightIntensityController : MonoBehaviour
{
    [SerializeField] private AnimationCurve _intensityCurve;
    [SerializeField] private float _animationDuration = 1f;

    [SerializeField] private Light pointLight;

   

    private void Update()
    {
        float time = Time.time % _animationDuration; // Get the current time within the animation duration
        float normalizedTime = time / _animationDuration;
        float curveValue = _intensityCurve.Evaluate(normalizedTime);
        pointLight.intensity = curveValue;
    }
}
