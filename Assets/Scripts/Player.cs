using System;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [Range(1,1000)][SerializeField] private int _maxHitPoints = 100;

    [SerializeField] UnityEvent<PlayerHealth> _playerHealthChangedEvent = new();

    private PlayerHealth _health;

    private void Start()
    {
        _health = new PlayerHealth(_maxHitPoints);
        InvokeEvent();
    }

    public void DealDamage(int value)
    {
        Assert.IsTrue(value > 0);
        _health -= value;
        InvokeEvent();
    }

    public void Heal(int value)
    {
        Assert.IsTrue(value > 0);
        _health += value;
        InvokeEvent();
    }

    private void InvokeEvent()
    {
        _playerHealthChangedEvent.Invoke(_health);
    }
}
