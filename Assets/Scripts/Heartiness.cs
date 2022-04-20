using UnityEngine;

public class Heartiness : MonoBehaviour, IHeartiness<int> {
    [SerializeField] private int _health;

    public int Health => _health;

    private void Start() {
        UIManager.Instance.SetHealth(Health);
    }

    public void MakeDamage(int damage) {
        _health -= damage;

        UIManager.Instance.UpdateHealth(Health);

        if (Health <= 0) {
            GameManager.Instance.PlayerIsDie();
            Die();
        }
    }

    private void Die() {
        gameObject.SetActive(false);
    }
}
