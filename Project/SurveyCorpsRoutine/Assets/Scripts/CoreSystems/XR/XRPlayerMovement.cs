using CoreSystems.XR.Input;
using Helpers;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace CoreSystems.XR
{
    public class XRPlayerMovement : MonoBehaviour
    {
        public XRInputSO input;
        public Rigidbody locomotionRb;
        public Transform rotationDirTransform;
        public GameObject playerCamera;
        public float speed = 1;

        private Rigidbody locomotionSphereRb;
        private float _locomotionSphereMass = 10;

        private Vector3 _prevHeadPos;
        private Quaternion _prevHeadRot;
        private void Awake()
        {
            SetupLocomotionSphere();
        }
        private void OnEnable()
        {
            InputSystem.onAfterUpdate += UpdateCallback;
        }
        private void OnDisable()
        {
            InputSystem.onAfterUpdate -= UpdateCallback;
        }
        private void Start()
        {
            locomotionRb.velocity = rotationDirTransform.forward * 2.5f;
        }
        void SetupLocomotionSphere()
        {
           /* locomotionSphereRb.mass = _locomotionSphereMass;
            locomotionSphereRb.isKinematic = false;
            locomotionSphereRb.useGravity = true;
            locomotionSphereRb.angularDrag = 1;
            locomotionSphereRb.collisionDetectionMode = CollisionDetectionMode.Continuous;
            locomotionSphereRb.constraints = RigidbodyConstraints.None;*/
        }
        bool camNotInit = false;
        void UpdateCallback()
        {
            if (InputState.currentUpdateType == InputUpdateType.BeforeRender)
                OnBeforeRender();
        }
        private void FixedUpdate()
        {
            Vector3 headMovementAmount = MathHelper.GetPositionOffset(input.headPosition, _prevHeadPos);
            _prevHeadPos = input.headPosition;
            Vector3 headVelocity = headMovementAmount / Time.fixedDeltaTime;
            headVelocity.y = 0;
            Vector3 joystickMoveAmount = new Vector3(input.joystickMoveValue.x, 0, input.joystickMoveValue.y);
            Debug.Log(joystickMoveAmount);
            Vector3 joystickVelocity = joystickMoveAmount * speed * Time.fixedDeltaTime;
            locomotionRb.velocity = headVelocity + joystickVelocity;

        }
        private void OnBeforeRender()
        {
            playerCamera.transform.position = new Vector3(
                locomotionRb.transform.position.x, 
                input.headPosition.y,
                locomotionRb.transform.position.z);
            playerCamera.transform.rotation = input.headRotation;

        }
       
       
        void OnJump()
        {

        }
        void OnMove(Vector2 direction)
        {
            
        }
    }
}
