using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
  public int currentHealth;
  public int maxHealth;

  public TMP_Text healthtext;

  private void Start()
  {
    healthtext.text = "HP: " + currentHealth + " / " + maxHealth;
  }


  public void ChangeHealth(int amount )
  {
    currentHealth += amount;
    healthtext.text = "HP: " + currentHealth + " / " + maxHealth;

    if ( currentHealth <= 0)
    {
        gameObject.SetActive( false);
    }
  }
}
