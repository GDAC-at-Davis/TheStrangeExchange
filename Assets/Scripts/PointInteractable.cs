using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointInteractable : MonoBehaviour
{
    [SerializeField]
    private float _radius;
    
    public UnityEvent OnInteractStart;
    public UnityEvent OnInteractEnd;
    
    public void InteractStart()
    {
        Debug.Log("Interacting with " + name);
        
        OnInteractStart.Invoke();
    }
    
    public void InteractEnd()
    {
        Debug.Log("Stopped interacting with " + name);
        
        OnInteractEnd.Invoke();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
