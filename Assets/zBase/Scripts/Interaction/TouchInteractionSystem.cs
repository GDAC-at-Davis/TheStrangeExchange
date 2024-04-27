using System.Collections.Generic;
using UnityEngine;

public class TouchInteractionSystem : MonoBehaviour
{
    private readonly List<TouchInteractable> _touchInteractables = new();

    private void OnTriggerEnter(Collider other)
    {
        if (!FindTouchInteractable(other, out TouchInteractable touchInteractable))
        {
            return;
        }

        touchInteractable.InteractStart();
        _touchInteractables.Add(touchInteractable);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!FindTouchInteractable(other, out TouchInteractable touchInteractable))
        {
            return;
        }

        if (_touchInteractables.Contains(touchInteractable))
        {
            _touchInteractables.Remove(touchInteractable);
            touchInteractable.InteractEnd();
        }
    }

    private bool FindTouchInteractable(Collider other, out TouchInteractable touchInteractable)
    {
        touchInteractable = other.GetComponentInParent<TouchInteractable>();

        if (touchInteractable == null)
        {
            return false;
        }

        return true;
    }
}