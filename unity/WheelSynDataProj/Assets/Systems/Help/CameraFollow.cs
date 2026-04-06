using System;
using UnityEngine;

namespace Systems.Help
{
    public class CameraFollow : MonoBehaviour
    {
        GameObject _wheelPrefab;
        Camera _camera;
        
        [SerializeField]
        private Vector3 _cameraPosOffset;
        [SerializeField]
        private Vector3 _cameraRotOffset;
        
        public void Initialize(GameObject wheelPrefab, Camera cam)
        {
            _wheelPrefab = wheelPrefab;
            _camera = cam;
            
            _cameraPosOffset = new Vector3(5, 5, 6);
            _cameraRotOffset = new Vector3(31, -145, 0);
        }
        
        private void Update()
        {
            _camera.transform.position = _wheelPrefab.transform.position;
            
            _camera.transform.rotation = Quaternion.Euler(_cameraRotOffset);
            _camera.transform.position += _cameraPosOffset;
        }
    }
}