using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    [SerializeField] private float moveX, moveY, rotateX, rotateY;
    [SerializeField] private float sens;
    [SerializeField] private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
      
        //CharacterRotation
        moveX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sens;
        moveY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sens;

        rotateY += moveX;
        rotateX -= moveY;

        rotateX = Mathf.Clamp(rotateX, -70f, 70f);

        transform.rotation = Quaternion.Euler(rotateX, rotateY, 0);
        player.rotation = Quaternion.Euler(0, rotateY, 0);

        
    }
}
