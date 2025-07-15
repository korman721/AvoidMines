using UnityEngine;

public class Wallet
{
    private int _coins;
    private int _coinsCountToWin;

    public Wallet(int coinsCountToWin)
    {
        _coinsCountToWin = coinsCountToWin;
    }

    public void AddCoin()
    {
        _coins++;

        if (CheckCurrentCoins())
        {
            Debug.Log("You Win");
            return;
        }
        else
            Debug.Log($"Coin Collected! {_coins}/{_coinsCountToWin}");
    }

    private bool CheckCurrentCoins()
    {
        if (_coins >= _coinsCountToWin)
            return true;
        else
            return false;
    }
}
