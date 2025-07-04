using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform cameraTransform;
    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.03f;

    private Vector3 originalCameraPosition;
    private float shakeTimer = 0f;

    void Awake()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void OnEnable()
    {
        originalCameraPosition = cameraTransform.localPosition;
    }

    void Update()
    {
        if (shakeTimer > 0)
        {
            cameraTransform.localPosition = originalCameraPosition + Random.insideUnitSphere * shakeMagnitude;
            shakeTimer -= Time.deltaTime;
        }
        else
        {
            shakeTimer = 0f;
            cameraTransform.localPosition = originalCameraPosition;
        }
    }

    public void ShakeCamera()
    {
        originalCameraPosition = cameraTransform.localPosition;
        shakeTimer = shakeDuration;
    }
}
