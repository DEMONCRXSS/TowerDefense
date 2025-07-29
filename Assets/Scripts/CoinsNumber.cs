using UnityEngine;
using UnityEngine.Events;

public class CoinsNumber : MonoBehaviour
{
    [SerializeField]
    private int _coins;

    public int Coins { get => _coins; }
    [SerializeField]

    private UnityEvent<int> _onCoinsUpdate;
    [SerializeField]
    private UnityEvent _onBuySucces;
    [SerializeField]
    private UnityEvent _onBuyFail;

    public void AddCoins(int amount)
    {
        _coins += amount;
        SetCoins(_coins);
    }
    public void SetCoins(int amount)
    {
        _coins = amount;
        _onCoinsUpdate?.Invoke(_coins);
    }

    public void SubtractCoins(int amount)
    {
        _coins -= amount;
        if (_coins < 0) _coins = 0;
        SetCoins(_coins);
    }

    public bool BuyObject(int amount)
    {
        if (_coins >= cost)
        {
            SubtractCoins(cost);
            _onBuySucces?.Invoke();
            return true;
        }
        else
        {
            _onBuyFail?.Invoke();
            return false;
        }
    }
}
