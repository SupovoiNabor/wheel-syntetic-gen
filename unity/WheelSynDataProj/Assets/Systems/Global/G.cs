using System;
using Systems.Help;
using Systems.Simulata;
using Unity.VisualScripting;
using UnityEngine;

namespace Systems.Global
{
    public class G : MonoBehaviour
    {
        public static G Instance {get; private set;}
        
        [SerializeField]
        private GameObject _wheelPrefab;
        
        private void Awake()
        {
            Application.targetFrameRate = 60;
            
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            
            parentCameraToPair();
            
            setupPairMovement();
        }
        
        private void parentCameraToPair()
        {
            if (_wheelPrefab  == null) return;
            
            Camera cam = Camera.main;
            
            if (cam == null) return;

            CameraFollow followSCR = cam.AddComponent<CameraFollow>();
            
            followSCR.Initialize(_wheelPrefab, cam);
        }

        private void setupPairMovement()
        {
            PairMovement pmSCR = _wheelPrefab.AddComponent<PairMovement>();
            
            pmSCR.Initialize(_wheelPrefab);
        }
    }
}
