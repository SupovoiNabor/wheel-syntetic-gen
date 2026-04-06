using UnityEngine;

namespace Systems.Simulata
{
    public class WheelDecalPositioner : MonoBehaviour
    {
        [SerializeField] private LayerMask _wheelLayer;
        [SerializeField] private float _raycastDistance = 2f;
        [SerializeField] private float _angle = 0f;        // test angle 0-360
        [SerializeField] private float _heightOffset = 0f; // test height

        private Vector3 _lastHitPoint;
        private Vector3 _lastHitNormal;
        private bool _hasHit;

        // Call this to test a single raycast
        [ContextMenu("Test Raycast")]
        public void TestRaycast()
        {
            _hasHit = GetSurfacePoint(_angle, _heightOffset, out _lastHitPoint, out _lastHitNormal);
        }

        public bool GetSurfacePoint(float angle, float heightOffset,
            out Vector3 position, out Vector3 normal)
        {
            position = Vector3.zero;
            normal = Vector3.up;

            // Rotate around axle (right axis), shoot inward toward wheel surface
            Vector3 direction = Quaternion.AngleAxis(angle, transform.right) * -transform.up;
            Vector3 origin = transform.position
                + transform.right * heightOffset
                + (-direction * _raycastDistance);

            if (Physics.Raycast(origin, direction, out RaycastHit hit, _raycastDistance * 2f, _wheelLayer))
            {
                position = hit.point;
                normal = hit.normal;
                return true;
            }

            return false;
        }

        private void OnDrawGizmos()
        {
            // Draw ray origin and direction
            Vector3 direction = Quaternion.AngleAxis(_angle, transform.right) * -transform.up;
            Vector3 origin = transform.position
                + transform.right * _heightOffset
                + (-direction * _raycastDistance);

            // Ray line
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(origin, origin + direction * _raycastDistance * 2f);

            // Origin point
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(origin, 0.02f);

            if (_hasHit)
            {
                // Hit point
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(_lastHitPoint, 0.03f);

                // Surface normal
                Gizmos.color = Color.green;
                Gizmos.DrawLine(_lastHitPoint, _lastHitPoint + _lastHitNormal * 0.1f);
            }
        }
    }
}