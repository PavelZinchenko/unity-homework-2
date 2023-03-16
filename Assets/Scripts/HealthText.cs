using TMPro;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    public void OnPlayerHealthChanged(PlayerHealth value)
    {
        _text.text = value.ToString();
    }
}
