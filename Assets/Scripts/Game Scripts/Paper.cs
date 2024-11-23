using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour
{
    [SerializeField] private float rayLength = 5;
    [SerializeField] private RawImage crosshair;
    [SerializeField] private KeyCode interactKey;
    private Camera _camera;
    private PaperController paper;
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(_camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f)), transform.forward, out RaycastHit hit, rayLength))
        {
            var readableItem = hit.collider.GetComponent<PaperController>();
            if (readableItem != null)
            {
                paper = readableItem;
            }
            else
            {
                ClearNote();
            }
        }
        else
        {
            ClearNote();
        }
        if (paper != null)
        {
            if(Input.GetKey(interactKey))
            {
                paper.ShowNote();
            }

        }
    }

    void ClearNote()
    {
        if (paper != null)
        {
            paper = null;
        }
    }

   
}
