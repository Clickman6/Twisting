interface IDamaging<T> {
    T Damage { get; }

    void ToDamage(IHeartiness<T> other);
}
