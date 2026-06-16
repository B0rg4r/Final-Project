using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Slider healthBar;
    public GameObject player; 
    public int health;
    public int maxHealth = 10;

    private void Start()
    {
        health = maxHealth;
        healthBar.value = 10;
    }
    private void Update()
    {
        healthBar.value = health;
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Player is dead");
        }
    }

    //public void TakeDamage(int amount)
    //{
    //    health -= amount;
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }
}
