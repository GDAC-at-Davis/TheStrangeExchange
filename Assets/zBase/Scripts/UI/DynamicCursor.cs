using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DynamicCursor : MonoBehaviour
{
    [SerializeField]
    private Image _cursorImage;

    [FormerlySerializedAs("_pointInteractor")]
    [SerializeField]
    private PointAndClickInteractionSystem _pointAndClickInteractor;

    [SerializeField]
    private float _idleScale = 1f;

    [SerializeField]
    private float _hoverScale = 1.5f;

    [SerializeField]
    private float _interactScale = 2f;

    private float _targetScale = 1f;

    private void Awake()
    {
        _pointAndClickInteractor.OnStateChange.AddListener(OnStateChange);

        OnStateChange(PointAndClickInteractionSystem.InteractorState.Idle);
    }

    private void Update()
    {
        _cursorImage.transform.localScale = Vector3.Lerp(
            _cursorImage.transform.localScale, Vector3.one * _targetScale,
            Time.deltaTime * 10f);
    }

    private void OnDestroy()
    {
        _pointAndClickInteractor.OnStateChange.RemoveListener(OnStateChange);
    }

    private void OnStateChange(PointAndClickInteractionSystem.InteractorState newState)
    {
        switch (newState)
        {
            case PointAndClickInteractionSystem.InteractorState.Idle:
                _targetScale = _idleScale;
                break;
            case PointAndClickInteractionSystem.InteractorState.Hover:
                _targetScale = _hoverScale;
                break;
            case PointAndClickInteractionSystem.InteractorState.Interact:
                _targetScale = _interactScale;
                break;
        }
    }
}