using CoreSystems.XR.Input;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Serialization;

namespace CoreSystems.XR
{
    [AddComponentMenu("XR/XR Camera")]
    [DisallowMultipleComponent]
    public class XRCamera : MonoBehaviour
    {
        public enum TrackingType
        {
            RotationAndPosition,
            RotationOnly,
            PositionOnly
        }
        public enum UpdateType
        {
            UpdateAndBeforeRender,
            Update,
            BeforeRender,
        }

        public XRInputEventsSO xrInput
        {
            get
            {
                return _xrInputEvents;
            }
            set
            {
                UnbindActions();
                _xrInputEvents = value;
                BindActions();
            }
        }
        public UpdateType updateType
        {
            get { return _updateType; }
            set { _updateType = value; }
        }
        public TrackingType trackingType
        {
            get { return _trackingType; }
            set { _trackingType = value; }
        }


        [SerializeField] XRInputEventsSO _xrInputEvents;
        [SerializeField] UpdateType _updateType = UpdateType.UpdateAndBeforeRender;
        [SerializeField] TrackingType _trackingType = TrackingType.RotationAndPosition;

        public event UnityAction<Vector3> onCameraRealPosChanged;
        public event UnityAction<Quaternion> onCameraRealRotChanged;
        private Vector3 _headCurrentPosition;
        private Quaternion _headCurrentRotation;
        private void OnEnable()
        {
            InputSystem.onAfterUpdate += UpdateCallback;
            BindActions();
        }
        private void OnDisable()
        {
            UnbindActions();
            InputSystem.onAfterUpdate -= UpdateCallback;
        }
        void BindActions()
        {
            _xrInputEvents.onHeadPosition += OnHeadPosition;
            _xrInputEvents.onHeadRotation += OnHeadRotation;
        }
        void UnbindActions()
        {
            _xrInputEvents.onHeadPosition -= OnHeadPosition;
            _xrInputEvents.onHeadRotation -= OnHeadRotation;
        }
        void OnHeadPosition(Vector3 pos)
        {
            _headCurrentPosition = pos;
        }
        void OnHeadRotation(Quaternion rot)
        {
            _headCurrentRotation = rot;
        }
        void UpdateCallback()
        {
            if (InputState.currentUpdateType == InputUpdateType.BeforeRender)
                OnBeforeRender();
            else
                OnUpdate();
        }
        protected virtual void OnBeforeRender()
        {
            if (_updateType == UpdateType.BeforeRender ||
                _updateType == UpdateType.UpdateAndBeforeRender)
            {
                PerformUpdate();
            }
        }
        protected virtual void OnUpdate()
        {
            if (_updateType == UpdateType.Update ||
                _updateType == UpdateType.UpdateAndBeforeRender)
            {
                PerformUpdate();
            }
        }
        protected virtual void PerformUpdate()
        {
            if (TrySetLocalPosition(_headCurrentPosition))
            {
                CamerRealPosChanged(_headCurrentPosition);
            }
            if (TrySetLocalRotation(_headCurrentRotation))
            {
                CamerRealRotChanged(_headCurrentRotation);
            }
        }
        protected virtual bool TrySetLocalPosition(Vector3 position)
        {
            if (_trackingType == TrackingType.RotationAndPosition ||
                _trackingType == TrackingType.PositionOnly)
            {
                transform.localPosition = position;
                _headCurrentPosition = position;
                return true;
            }
            else
            {
                return false;
            }
        }
        protected virtual bool TrySetLocalRotation(Quaternion rotation)
        {
            if (_trackingType == TrackingType.RotationAndPosition ||
                _trackingType == TrackingType.RotationOnly)
            {
                transform.localRotation = rotation;
                return true;
            }
            else
            {
                return false;
            }
        }
        void CamerRealPosChanged(Vector3 currPos)
        {
            onCameraRealPosChanged?.Invoke(currPos);
        }
        void CamerRealRotChanged( Quaternion currRot)
        {
            onCameraRealRotChanged?.Invoke(currRot);
        }
    
    }
}
