using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace PingPing.Scripts.CameraScripts
{
    public class CameraSizeAdjuster : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera _virtualCamera;

        private float _cameraAspect;
        private const float _mobilesSizeModifier = 2.3f;
        private const float _tabletsSizeModifierMultiplier = 6.4f;


        private void Start()
        {
            _cameraAspect = Camera.main.aspect;
            Debug.Log(_cameraAspect);

            if (_cameraAspect < 2)
            {
                _virtualCamera.m_Lens.OrthographicSize = _tabletsSizeModifierMultiplier * _cameraAspect;
            }
            else
            {
                _virtualCamera.m_Lens.OrthographicSize = _mobilesSizeModifier * _cameraAspect;
            }
        }
    }
}
