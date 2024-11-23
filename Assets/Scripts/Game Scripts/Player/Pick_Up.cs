using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pick_Up : MonoBehaviour
{
    [SerializeField] private GameObject player, heldObj;
    [SerializeField] private Transform Holdpos;
    [SerializeField] private float pickUpRange;
    [SerializeField] private Rigidbody heldObjrb;
    [SerializeField] private bool canDrop = true;
    [SerializeField] private int LayerNumber;
   
    // Start is called before the first frame update
    void Start()
    {
        pickUpRange = 2f;
        LayerNumber = LayerMask.NameToLayer("canPick");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0)) // for picking up objects
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange)) 
                {
                    if (hit.transform.gameObject.tag == "canPick")
                    {
                        PickUpObject(hit.transform.gameObject);

                    }
                }
            }
        }
        else
        {
            if (canDrop == true)
            {
                DropObject();
                NoClipping();

            }
        }
        if (heldObj != null)
        {

            KeepPos();
            RotateObject();
        }
    }
    #region Features
    void PickUpObject(GameObject pickUpObj)
    {
        if (pickUpObj.GetComponent<Rigidbody>())
        {
            heldObj = pickUpObj;
            heldObjrb = pickUpObj.GetComponent<Rigidbody>();
            heldObjrb.isKinematic = true;
            heldObjrb.transform.parent = Holdpos.transform;
            heldObj.layer = LayerNumber;
            

        }

    }
    void DropObject()
    {
        heldObj.layer = 0; 
        heldObjrb.isKinematic = false;
        heldObj.transform.parent = null; 
        heldObj = null;
       
    }

    void NoClipping()
    {
        var clipRange = Vector3.Distance(heldObj.transform.position, transform.position);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.TransformDirection(Vector3.forward), clipRange);
        if (hits.Length > 1)
        {

            heldObj.transform.position = transform.position + new Vector3(0f, -0.1f, 0f);
        }

    }
    void KeepPos()
    {

        heldObj.transform.position = Holdpos.transform.position;
    }

    void RotateObject()
    {
        if (Input.GetKey(KeyCode.R))
        {
            heldObj.transform.Rotate(Vector3.down, 1f);
            heldObj.transform.Rotate(Vector3.right, 1f);
        }
    }
    #endregion
}

