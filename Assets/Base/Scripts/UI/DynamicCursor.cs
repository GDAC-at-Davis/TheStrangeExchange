using UnityEngine;
using UnityEngine.UI;

public class DynamicCursor : MonoBehaviour
{
    [SerializeField]
    private Image _cursorImage;

    [SerializeField]
    private PointInteractor _pointInteractor;

    [SerializeField]
    private float _idleScale = 1f;

    [SerializeField]
    private float _hoverScale = 1.5f;

    [SerializeField]
    private float _interactScale = 2f;

    private float _targetScale = 1f;

    private void Awake()
    {
        _pointInteractor.OnStateChange.AddListener(OnStateChange);
    }

    private void Update()
    {
        _cursorImage.transform.localScale = Vector3.Lerp(
            _cursorImage.transform.localScale, Vector3.one * _targetScale,
            Time.deltaTime * 10f);
    }

    private void OnDestroy()
    {
        _pointInteractor.OnStateChange.RemoveListener(OnStateChange);
    }

    private void OnStateChange(PointInteractor.InteractorState newState)
    {
        switch (newState)
        {
            case PointInteractor.InteractorState.Idle:
                _targetScale = _idleScale;
                break;
            case PointInteractor.InteractorState.Hover:
                _targetScale = _hoverScale;
                break;
            case PointInteractor.InteractorState.Interact:
                _targetScale = _interactScale;
                break;
        }
    }
}