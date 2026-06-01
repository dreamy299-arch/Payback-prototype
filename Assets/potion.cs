using UnityEngine;

public class HealingPotion : MonoBehaviour
{
public int healAmount = 5;

private void OnTriggerEnter2D(Collider2D collision)
{
// 1. Find the PlayerHealth component on the object we collided with
PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

// 2. Check if the component was actually found (null check)
if (playerHealth != null)
{
// 3. Call the method on the instance we found
playerHealth.ChangeHealth(healAmount);

// 4. Destroy the potion
Destroy(gameObject);
}
}
}



