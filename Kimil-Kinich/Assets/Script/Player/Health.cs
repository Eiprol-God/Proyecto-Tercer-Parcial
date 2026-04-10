public int health = 2;

public void TakeDamage(int damage)
{
    health -= damage;

    if (health <= 0)
    {
        Debug.Log("Murió el jugador");
    }
}