using UnityEngine;
using UnityEngine.Events;

public class PointAndClickInteractionSystem : MonoBehaviour
{
    public enum InteractorState
    {
        Idle,
        Hover,
        Interact
    }

    [SerializeField]
    private LayerMask _interactableLayer;

    [SerializeField]
    private Transform _aimTransform;

    public UnityEvent<InteractorState> OnStateChange;

    private readonly RaycastHit[] raycastHits = new RaycastHit[20];
    private PointAndClickInteractable _currentInteraction;

    private InteractorState _currentState = InteractorState.Idle;
    private PointAndClickInteractable _hoveredPnCInteractable;

    private void Update()
    {
        PointAndClickInteractable closestPnCInteractable = GetClosestInteractables();

        if (closestPnCInteractable == null)
        {
            if (_currentState == InteractorState.Interact)
            {
                StopInteract();
                OnStateChange?.Invoke(InteractorState.Idle);
            }
            else if (_currentState == InteractorState.Hover)
            {
                OnStateChange?.Invoke(InteractorState.Idle);
            }

            _currentState = InteractorState.Idle;
        }
        else
        {
            if (_currentState == InteractorState.Idle)
            {
                OnStateChange?.Invoke(InteractorState.Hover);
                _currentState = InteractorState.Hover;
            }
        }

        _hoveredPnCInteractable = closestPnCInteractable;

        if (Input.GetMouseButtonDown(0))
        {
            TryStartInteract();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopInteract();
        }
    }

    public bool TryStartInteract()
    {
        if (_currentState != InteractorState.Hover)
        {
            return false;
        }

        _hoveredPnCInteractable.InteractStart();
        _currentInteraction = _hoveredPnCInteractable;

        _currentState = InteractorState.Interact;
        OnStateChange?.Invoke(InteractorState.Interact);

        return true;
    }

    public void StopInteract()
    {
        if (_currentState != InteractorState.Interact)
        {
            return;
        }

        _currentInteraction.InteractEnd();
        _currentInteraction = null;

        if (_hoveredPnCInteractable != null)
        {
            _currentState = InteractorState.Hover;
            OnStateChange?.Invoke(InteractorState.Hover);
        }
        else
        {
            _currentState = InteractorState.Idle;
            OnStateChange?.Invoke(InteractorState.Idle);
        }
    }

    private PointAndClickInteractable GetClosestInteractables()
    {
        int hitCount = Physics.RaycastNonAlloc(
            _aimTransform.position,
            _aimTransform.forward,
            raycastHits,
            100f,
            _interactableLayer);

        PointAndClickInteractable closestPnCInteractable = null;
        var closestDistance = float.MaxValue;

        for (var i = 0; i < hitCount; i++)
        {
            RaycastHit hit = raycastHits[i];

            if (hit.distance > closestDistance)
            {
                break;
            }

            Collider coll = hit.collider;

            if (coll == null)
            {
                continue;
            }

            var interactable = coll.GetComponentInParent<PointAndClickInteractable>();

            if (interactable == null || interactable.InteractRadius < hit.distance)
            {
                continue;
            }

            closestPnCInteractable = interactable;
            closestDistance = hit.distance;
        }

        return closestPnCInteractable;
    }
}