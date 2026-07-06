using UnityEngine;

public class Checkpoint : MonoBehaviour, IInteractable
{
    public GameObject player;
    public static Vector3 checkpointPosition;
    [SerializeField] private PlayerStats playerStats;


    public void Interact()
    {
        checkpointPosition = player.transform.position;
        Debug.Log("Checkpoint reached!");
    }

    
    void Start()
    {
        checkpointPosition = player.transform.position;
    }
}



