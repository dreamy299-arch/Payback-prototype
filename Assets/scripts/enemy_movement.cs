using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    public float speed;
    
    private int facingDirection = -1;
    private EnemyState enemyState;

    public float attackRange = 2f;
    private Rigidbody2D rb;
    public Transform player;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyState == EnemyState.Chasing)
        {
            Chase();
        }
        else if(enemyState == EnemyState.Attacking)
        {
            // attacking code
        }
        
    }
    
    void Chase()
    {
      if(Vector2.Distance(transform.position, player.transform.position) <= attackRange)
      {
        ChangeState(EnemyState.Attacking);
      }

     else if(player.position.x > transform.position.x && facingDirection == -1 ||
            player.position.x > transform.position.x && facingDirection == 1)
            {
                Flip();
            }
          Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
          if(player == null)
          {
            player = collision.transform;
          }
  
          ChangeState(EnemyState.Chasing);
        }
         
    }

    private void OnCollisionEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
          rb.linearVelocity = Vector2.zero;

          ChangeState(EnemyState.Idle);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
{
// Check if it is the player leaving the range
if (collision.gameObject.CompareTag("Player"))
{
// hopefully this stops the chase ;-;
rb.linearVelocity = Vector2.zero;

ChangeState(EnemyState.Idle);
}
}
 // referenced code    
void ChangeState(EnemyState newState)
{
    if(enemyState == EnemyState.Idle)
          anim.SetBool("isIdle", false);
        else if(enemyState == EnemyState.Chasing)
          anim.SetBool("isChasing", false);
          else if(enemyState == EnemyState.Attacking)
          anim.SetBool("isAttacking", false);

        
    enemyState = newState;

    if(enemyState == EnemyState.Idle)
          anim.SetBool("isIdle", true);
        else if(enemyState == EnemyState.Chasing)
          anim.SetBool("isChasing", true);
          else if(enemyState == EnemyState.Attacking)
          anim.SetBool("isAttacking", true);
}
}


public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
}
