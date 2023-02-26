using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealControl : MonoBehaviour
{
    [SerializeField]
    private Image _hpAmountImg = null;

    [SerializeField]
    private MainPlayerControl _mainPlayerControl = null;

    private int _playerTotalHp = 0;

    private void Start()
    {
        _playerTotalHp = _mainPlayerControl.PlayerHealth;

        _mainPlayerControl._healthChange += OnPlayerHPChange;

        UpdatePlayerHealthBar(_mainPlayerControl.PlayerHealth);
    }

    private void OnPlayerHPChange(object sender, HealthChangeEvent healthChangeEvent)
    {
        UpdatePlayerHealthBar(healthChangeEvent.Health);
    }

    private void UpdatePlayerHealthBar(int playerHealth)
    {
        _hpAmountImg.fillAmount = playerHealth / (float)_playerTotalHp;
    }

}
