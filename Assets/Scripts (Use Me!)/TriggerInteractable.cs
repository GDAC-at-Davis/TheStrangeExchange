using UnityEngine;
using UnityEngine.Events;

public class TriggerInteractable : MonoBehaviour
{
    [HelpBox("An object that can be interacted with by entering its trigger.\n" +
             "Make sure there's a trigger collider on THIS gameobject\n" +
             "Assign listeners to the events below to make something happen when interacted with!")]
    public bool helpBox;

    public UnityEvent OnInteractStart;

    public UnityEvent OnInteractEnd;

    private TouchInteractionSystem _currentInteractor;

    private void OnTriggerEnter(Collider other)
    {
        if (!FindTouchInteractor(other, out TouchInteractionSystem touchInteractor))
        {
            return;
        }

        _currentInteractor = touchInteractor;

        OnInteractStart.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!FindTouchInteractor(other, out TouchInteractionSystem touchInteractor))
        {
            return;
        }

        if (touchInteractor == _currentInteractor)
        {
            _currentInteractor = null;
        }

        OnInteractEnd.Invoke();
    }

    private void OnValidate()
    {
        var coll = GetComponent<Collider>();

        if (coll == null)
        {
            Debug.Log("Touch interactables require a trigger collider on the same gameobject." +
                      " Adding a sphere collider to this gameobject.", gameObject);
            var sphereColl = gameObject.AddComponent<SphereCollider>();
            sphereColl.isTrigger = true;
            sphereColl.radius = 3f;
        }
        else
        {
            coll.isTrigger = true;
        }
    }

    private bool FindTouchInteractor(Collider other, out TouchInteractionSystem touchInteractor)
    {
        touchInteractor = other.GetComponentInParent<TouchInteractionSystem>();

        if (touchInteractor != null)
        {
            return false;
        }

        return true;
    }
}