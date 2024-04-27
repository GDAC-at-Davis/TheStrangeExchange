using UnityEngine;
using UnityEngine.Events;

public class PointAndClickInteractable : MonoBehaviour
{
    [HelpBox("An object that can be interacted with through aiming and clicking.\n" +
             "Make sure there's a collider on this gameObject or its children.\n" +
             "Assign listeners to the events below to make something happen when interacted with!")]
    public bool helpBox;

    [SerializeField]
    [Tooltip("How far away the player can be from this object and still interact with it.")]
    private float _interactRadius = 5;

    public UnityEvent OnInteractStart;
    public UnityEvent OnInteractEnd;

    public float InteractRadius => _interactRadius;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _interactRadius);
    }

    public void InteractStart()
    {
        Debug.Log("Point interacting with " + name);

        OnInteractStart.Invoke();
    }

    public void InteractEnd()
    {
        Debug.Log("Point interacting with " + name);

        OnInteractEnd.Invoke();
    }
}