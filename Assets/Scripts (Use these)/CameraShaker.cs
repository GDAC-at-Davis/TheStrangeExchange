using System.Collections;
using Cinemachine;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(CinemachineImpulseSource))]
public class CameraShaker : MonoBehaviour
{
    [HelpBox("Call this script's PlayShake method to shake the camera, and StopShaking to stop it if looping.")]
    public bool helpBox;

    [SerializeField]
    private float _duration = 0.1f;

    [SerializeField]
    private float _amplitude = 0.1f;

    [SerializeField]
    private bool _loop = true;

    private CinemachineImpulseSource _impulseSource;

    private Coroutine _loopShakeCoroutine;

    private void Awake()
    {
        _impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public void PlayShake()
    {
        _impulseSource.m_ImpulseDefinition.m_TimeEnvelope.m_SustainTime = _duration;

        if (_loop)
        {
            if (_loopShakeCoroutine != null)
            {
                StopCoroutine(_loopShakeCoroutine);
            }

            _loopShakeCoroutine = StartCoroutine(LoopShake());
        }
        else
        {
            _impulseSource.GenerateImpulse(Random.onUnitSphere * _amplitude);
        }
    }

    public void StopShaking()
    {
        if (_loop)
        {
            if (_loopShakeCoroutine != null)
            {
                StopCoroutine(_loopShakeCoroutine);
            }
        }
    }

    private IEnumerator LoopShake()
    {
        while (true)
        {
            _impulseSource.GenerateImpulse(Random.onUnitSphere * _amplitude);
            yield return new WaitForSeconds(_duration);
        }
    }
}