using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class ThirdPersonMovement : MonoBehaviour
{
    public float speed = 1f;
    Vector3 movement; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + movement * Time.deltaTime * speed; 
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 receivedVector2 = context.ReadValue<Vector2>();
        movement = new Vector3(receivedVector2.x, 0f, receivedVector2.y);
    }
}

