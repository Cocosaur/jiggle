
using UnityEngine;

public class S_PickUp : MonoBehaviour
{
    public bool Pressed = false;

    public Camera CurrentCamera;
    private float cameraDistance;

    public bool pickUpable;

    public Rigidbody rigidbody;
   
    
    
    void OnMouseDown()
    { 
        if (pickUpable == false)
        {
            return;
        }

        Pressed = true;
        rigidbody.isKinematic = true;

        cameraDistance = Vector3.Distance(transform.position, CurrentCamera.transform.position);
    }
    
    void OnMouseUp()
    {
        Pressed = false;
        rigidbody.isKinematic = false;
    }

    void ClenchDefense()
    {
        
        Debug.Log("clenching activated");
        //modify rigidbody mass (make player heavier)
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Pressed)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = cameraDistance;
            
            mousePos = CurrentCamera.ScreenToWorldPoint(mousePos);
            //print(mousePos);
            mousePos.z = 0;
            rigidbody.MovePosition(mousePos);
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            ClenchDefense();
        }
    }
}
