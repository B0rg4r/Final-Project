using UnityEngine;

public class Checkpoint : MonoBehaviour, IInteractable
{
    public GameObject player;
    public static Vector3 checkpointPosition;
    [SerializeField] private PlayerStats playerStats;
    public int health;
    public int maxHealth;

    public void Interact()
    {
        checkpointPosition = player.transform.position;
        Debug.Log("Checkpoint reached!");
        health = maxHealth;
        
        
    }

    
    void Start()
    {
        checkpointPosition = player.transform.position;
    }
}



