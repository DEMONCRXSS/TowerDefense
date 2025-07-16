using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CoinsUI : MonoBehaviour
{
    [SerializeField]
    private Text _coinsText;
    [SerializeField]

    private UnityEvent _onCoinsUpdated;

    public void UpdateCoins(int coins)
    {
        _coinsText.text = "x" + coins.ToString();
        _onCoinsUpdated?.Invoke();
    }
}
