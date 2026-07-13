using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButton : MonoBehaviour, IInteractable
{
   public void Interact()
   {
       Application.Quit();

    }
}
