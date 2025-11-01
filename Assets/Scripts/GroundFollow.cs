using UnityEngine;

public class GroundFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothSpeed = 5f;

    private void Update()
    {
        Vector3 desiredPosition = _target.position + new Vector3(0, -10f, 0);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
    }
}