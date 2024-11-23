using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToyBox_Counter : MonoBehaviour
{
    [SerializeField] private List<GameObject> requiredObjects;
    [SerializeField] private Collider _collider;
    [SerializeField] private string Ending;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         if (ToyBlockCounter())
        {
            ending();
        }
    }
    private bool ToyBlockCounter()
    {
        foreach (GameObject obj in requiredObjects)
        {
            if (obj == null)
            {
              
                continue;
        }
            Collider objCollider = obj.GetComponent<Collider>();
if (objCollider != null && !_collider.bounds.Intersects(objCollider.bounds))
{
   
    return false;
}

        }
       
        return true;
    }
    
            public void ending()
    {
        SceneManager.LoadScene(Ending);
    }

}




