using UnityEngine;

public class player_combat : MonoBehaviour
{
    public int damage = 1;

private void OnTriggerEnter2D(Collider2D collision)
{
// Check if the object we collided with has the EnemyHealth script
EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();

if (enemyHealth != null)
{
// Deal damage (pass negative value to reduce health)
enemyHealth.ChangeHealth(-damage);
}
}
}

