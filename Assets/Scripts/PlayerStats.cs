using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public GameObject player; 
    public int health;
    public int maxHealth = 10;
    public float DamageCooldown = 0f;
    public Slider HealthBar;
   

    private void Start()
    {
        health = maxHealth;
        HealthBar.value = health;
        
    }

    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Player is dead");           
            health = maxHealth;
            transform.position = Checkpoint.checkpointPosition;
            HealthBar.value = health;
        }

        DamageCooldown -= Time.deltaTime;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        HealthBar.value -= amount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            TakeDamage(1);

        }

        if (collision.gameObject.CompareTag("DeathBoundary"))
        {
            TakeDamage(10);
        }
    }

    


   





}
