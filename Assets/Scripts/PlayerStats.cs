using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject player; 
    public int health;
    public int maxHealth = 10;
    public float DamageCooldown = 0f;
   

    private void Start()
    {
        health = maxHealth;
        
    }

    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Player is dead");           
            health = maxHealth;
            transform.position = Checkpoint.checkpointPosition;
        }

        DamageCooldown -= Time.deltaTime;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            TakeDamage(1);
        }
    }


   





}
