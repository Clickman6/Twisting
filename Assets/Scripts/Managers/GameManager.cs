using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }

    private readonly List<Coin> _coinsList = new List<Coin>();
    private int _amountCoins;
    private int _collectedCoins;

    private void Awake() {
        Instance = this;
    }

    public void AddCoin(Coin coin) {
        _coinsList.Add(coin);
        _amountCoins = _coinsList.Count;

        UIManager.Instance.UpdateCoinsLabel(_amountCoins, _collectedCoins);
    }

    public void RemoveCoin(Coin coin) {
        _coinsList.Remove(coin);
    }

    public void CollectCoin() {
        _collectedCoins++;
        UIManager.Instance.UpdateCoinsLabel(_amountCoins, _collectedCoins);

        if (_collectedCoins >= _amountCoins) {
            UIManager.Instance.ShowWinPanel();
            Pause();
        }
    }

    public static void Pause() {
        Time.timeScale = 0;
    }

    public static void UnPause() {
        Time.timeScale = 1;
    }

    public Coin GetNearestCoin(Vector3 current) {
        Coin target = null;

        float distance = Mathf.Infinity;

        foreach (var coin in _coinsList) {
            float tmp = Vector3.Distance(current, coin.transform.position);

            if (tmp < distance) {
                distance = tmp;
                target = coin;
            }
        }

        return target;
    }

    public void PlayerIsDie() {
        UIManager.Instance.ShowLosingPanel();
        Pause();
    }
}
