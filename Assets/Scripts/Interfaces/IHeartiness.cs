public interface IHeartiness<T> {
    T Health { get; }

    void MakeDamage(T damage);
}
