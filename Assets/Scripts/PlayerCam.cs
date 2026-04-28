using JetBrains.Annotations;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0f, yRotation, 0f);

        if(Input.GetKeyDown(KeyCode.E)) PlayerInteract();
    }
    public void PlayerInteract()
    {
        var layermask0 = 1 << 0;
        var layermask3 = 1 << 3;
        var finalmask = layermask0 | layermask3;
        
        RaycastHit hit;
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(5f, 5f, 0));

        if (Physics.Raycast(ray, out hit, 15, finalmask))
        {
            Interact interactScript = hit.transform.GetComponent<Interact>();
            if (interactScript) interactScript.CallInteract(this);
        }
    }
}
