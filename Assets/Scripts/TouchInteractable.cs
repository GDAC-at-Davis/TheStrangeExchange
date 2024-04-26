using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TouchInteractable : MonoBehaviour
{
    public UnityEvent OnInteractStart;
    public UnityEvent OnInteractEnd;
    
    private TouchInteractor _currentInteractor;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!FindTouchInteractor(other, out var touchInteractor))
        {
            return;
        }
        
        _currentInteractor = touchInteractor;
        
        OnInteractStart.Invoke();
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!FindTouchInteractor(other, out var touchInteractor))
        {
            return;
        }
        
        if(touchInteractor == _currentInteractor)
        {
            _currentInteractor = null;
        }
        
        OnInteractEnd.Invoke();
    }
    
    private bool FindTouchInteractor(Collider other, out TouchInteractor touchInteractor)
    {
        touchInteractor = other.GetComponentInChildren<TouchInteractor>();

        if (touchInteractor == null)
        {
            touchInteractor = other.gameObject.GetComponentInParent<TouchInteractor>();
        }
        
        if (touchInteractor != null)
        {
            return false;
        }
        
        return true;
    }
}
