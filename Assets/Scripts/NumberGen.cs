using UnityEngine;

public class NumberGen : MonoBehaviour, IInteractable
{
  public void Interact()
  {
    Debug.Log(Random.Range(0, 100));
    }
}
