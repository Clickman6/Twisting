using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {
    public static UIManager Instance { get; private set; }

    [Header("Panels / Labels")]
    [SerializeField] private TextMeshProUGUI _coinsLabel;
    [SerializeField] private RectTransform _healthPanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losingPanel;

    [Header("Prefabs")]
    [SerializeField] private GameObject _heartPrefab;

    private void Awake() {
        Instance = this;

        _winPanel.SetActive(false);
        _losingPanel.SetActive(false);
    }

    public void SetHealth(int health) {
        for (int i = 0; i < health; i++) {
            Instantiate(_heartPrefab, _healthPanel);
        }
    }

    public void UpdateHealth(int health) {
        for (var i = 0; i < _healthPanel.childCount; i++) {
            _healthPanel.GetChild(i).gameObject.SetActive(i < health);
        }
    }

    public void UpdateCoinsLabel(int all, int collected) {
        _coinsLabel.text = $"{collected} / {all}";
    }

    public void ShowWinPanel() {
        _winPanel.SetActive(true);
    }

    public void ShowLosingPanel() {
        _losingPanel.SetActive(true);
    }
}
