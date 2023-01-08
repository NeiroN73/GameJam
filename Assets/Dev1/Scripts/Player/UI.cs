using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tmproGO;

    private int _amountCoins;

    public void Initialize(PickingMoney pickingMoney)
    {
        pickingMoney.OnPickingCoin += UpdateCoinsUI;
    }

    private void UpdateCoinsUI()
    {
        _amountCoins++;
        _tmproGO.text = _amountCoins.ToString();
    }
}
