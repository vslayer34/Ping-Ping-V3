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
        private float _phonePixelWidth;
        private const float _mobilesSizeModifier = 2.3f;
        private const float _tabletsSizeModifierMultiplier = 6.4f;

        private const float _standardCameraSize = 8.5f;
        private const float _standardPixelWidth = 2048;


        private void Start()
        {

            //  Size 8.5 is suitable for 2048 pixel width
            _cameraAspect = Camera.main.aspect;
            _phonePixelWidth = Camera.main.pixelWidth;
            Debug.Log(Camera.main.scaledPixelWidth);

            _virtualCamera.m_Lens.OrthographicSize = _phonePixelWidth * _standardCameraSize / _standardPixelWidth;

            // if (_cameraAspect < 2)
            // {
            //     _virtualCamera.m_Lens.OrthographicSize = _tabletsSizeModifierMultiplier * _cameraAspect;
            // }
            // else
            // {
            //     _virtualCamera.m_Lens.OrthographicSize = _mobilesSizeModifier * _cameraAspect;
            // }
        }
    }
}
