using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [Range(0.01f, 10f)][SerializeField] private float _smoothTime = 1f;

    private float _desiredValue;
    private bool _isCoroutineRunning;

    public void OnPlayerHealthChanged(PlayerHealth value)
    {
        _desiredValue = value.Percentage;

        if (!_isCoroutineRunning)
            StartCoroutine(ChangeSliderValue());
    }

    private IEnumerator ChangeSliderValue()
    {
        if (_isCoroutineRunning) yield break;
        _isCoroutineRunning = true;

        float velocity = 0;
        while (!Mathf.Approximately(_slider.value, _desiredValue))
        {
            _slider.value = Mathf.SmoothDamp(_slider.value, _desiredValue, ref velocity, _smoothTime);
            yield return null;
        }

        _isCoroutineRunning = false;
    }
}
