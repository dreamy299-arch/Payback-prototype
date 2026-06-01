using UnityEngine;

public class enemy_combat : MonoBehaviour
{
  public int damage = 5;

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.tag == "Player")
    collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damage);
  }
}
