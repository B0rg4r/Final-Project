using Unity.VisualScripting;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public GameObject player; 
    public int health;
    public int maxHealth = 10;

    private void Start()
    {
        health = maxHealth;
    }
    
    public void TakeDamage(int amount)
    {
        health -= amount;
    }

   

    private void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Player is dead");
             
        }
    }





}
