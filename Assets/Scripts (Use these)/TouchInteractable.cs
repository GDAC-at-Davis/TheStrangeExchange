using UnityEngine;
using UnityEngine.Events;

public class TouchInteractable : MonoBehaviour
{
    [HelpBox("An object that can be interacted with by touching a collider\n" +
             "Make sure there's a solid collider on this gameObject or its children.\n" +
             "Assign listeners to the events below to make something happen when interacted with!")]
    public bool helpBox;

    public UnityEvent OnInteractStart;

    public UnityEvent OnInteractEnd;

    private void OnValidate()
    {
        var coll = GetComponentInChildren<Collider>();

        if (coll == null)
        {
            Debug.Log("Touch interactables require a solid collider on the same gameObject or its children!",
                gameObject);
        }
    }

    public void InteractStart()
    {
        Debug.Log("Touch interacting with " + name);

        OnInteractStart.Invoke();
    }

    public void InteractEnd()
    {
        Debug.Log("Touch interacting with " + name);

        OnInteractEnd.Invoke();
    }
}