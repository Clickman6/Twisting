using UnityEngine;

public class Mine : MonoBehaviour, IDamaging<int> {
    public int Damage => _damage;

    [SerializeField] private float _radius;
    [SerializeField] private float _power;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _effect;

    private void OnTriggerEnter(Collider other) {
        Vector3 explosionPos = transform.position;

        // В данном проекте конечно не актуально, так как на сцене только один объект с Rigidbody 
        Collider[] colliders = Physics.OverlapSphere(explosionPos, _radius);

        foreach (Collider hit in colliders) {
            if (hit.TryGetComponent(out Rigidbody rb)) {
                rb.AddExplosionForce(_power, transform.position, _radius, 3f, ForceMode.Impulse);
            }

            if (hit.TryGetComponent(out IHeartiness<int> heartiness)) {
                ToDamage(heartiness);
            }
        }

        Die();
    }

    public void Die() {
        AudioManager.Instance.PlayExplosionSound();
        Instantiate(_effect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    public void ToDamage(IHeartiness<int> heartiness) {
        heartiness.MakeDamage(Damage);
    }
}
