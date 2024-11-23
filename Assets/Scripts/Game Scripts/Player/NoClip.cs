using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class NoClip : MonoBehaviour
{
    [SerializeField] private float distance, radius;
    [SerializeField] private LayerMask clippLayerMask;
    [SerializeField] private Vector3 originalpos;
    [SerializeField] private AnimationCurve clipCurve;
    // Start is called before the first frame update
    void Start() => originalpos = transform. localPosition;
   

    // Update is called once per frame
    void Update()
    {
        if (Physics.SphereCast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.0f)), radius, out RaycastHit hit, distance,
            clippLayerMask))
        {
            transform.localPosition = originalpos - new Vector3(0.0f, 0.0f, clipCurve.Evaluate(hit.distance/distance));
        }
        else
        {
            transform.localPosition = originalpos;
        }
    }
}
