using UnityEngine;

public class vidainimigo : MonoBehaviour
{
    public float health = 10f;

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
