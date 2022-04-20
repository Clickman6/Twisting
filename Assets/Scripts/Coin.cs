using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Collider))]
public class Coin : MonoBehaviour {
    private float _offset;
    
    [SerializeField] private GameObject _effect;

    private void Start() {
        _offset = Random.Range(-1f, 1f);

        GameManager.Instance.AddCoin(this);
    }

    private void Update() {
        var time = Time.time + _offset;

        transform.localPosition = transform.up * (Mathf.Sin(time * 3.5f + _offset) * 0.1f + 0.1f);
        transform.localRotation = Quaternion.Euler(transform.up * 180f * (time - Mathf.Floor(time)));
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.GetComponent<PlayerController>()) return;
        
        GameManager.Instance.CollectCoin();
        Die();
    }

    public void Die() {
        AudioManager.Instance.PlayCoinSound();
        GameManager.Instance.RemoveCoin(this);
        Instantiate(_effect, transform.position, Quaternion.identity);

        Destroy(transform.parent.gameObject);
    }
}
