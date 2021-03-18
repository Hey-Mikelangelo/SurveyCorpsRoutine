// GENERATED AUTOMATICALLY FROM 'Assets/Settings/Default Input Actions/XRInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace CoreSystems.XR.Input
{
    public class @XRInputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @XRInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""XRInputActions"",
    ""maps"": [
        {
            ""name"": ""OpenVR"",
            ""id"": ""442f0a8c-3a55-453e-a10f-db09262ef44a"",
            ""actions"": [
                {
                    ""name"": ""HeadRotation"",
                    ""type"": ""Value"",
                    ""id"": ""d197241e-fc75-4625-b68d-27180fe73fcf"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HeadPosition"",
                    ""type"": ""Value"",
                    ""id"": ""ebed8afd-01c5-411c-b205-48eb8819982f"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightPosition"",
                    ""type"": ""Value"",
                    ""id"": ""1e8b6c52-f328-4689-8e20-b536770747e7"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightRotation"",
                    ""type"": ""Value"",
                    ""id"": ""f157e6bc-8496-4b2e-a2e5-d5c135b81456"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightPrimaryAxis"",
                    ""type"": ""Value"",
                    ""id"": ""ee2e96b8-0ab8-4096-aebb-6fddea9686df"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightGrip"",
                    ""type"": ""Value"",
                    ""id"": ""c34f04ae-9804-4901-8d58-88a72107f2b5"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightTrigger"",
                    ""type"": ""Value"",
                    ""id"": ""aef2cac2-f2d4-4539-99aa-421cebbcdfba"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightGripButton"",
                    ""type"": ""Button"",
                    ""id"": ""66ed4c20-2bf7-418c-816d-bba3e985de38"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightTriggerButton"",
                    ""type"": ""Button"",
                    ""id"": ""f960176b-06ac-4b78-a2a9-0940745f0324"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightPrimaryButton"",
                    ""type"": ""Button"",
                    ""id"": ""b5fa976f-b903-433e-bbdb-c3309b11cd35"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightSecondaryButton"",
                    ""type"": ""Button"",
                    ""id"": ""1282af09-cb83-4718-88fc-e1b8dfdb8a80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightPrimaryAxisClick"",
                    ""type"": ""Button"",
                    ""id"": ""103ebeff-7b2b-4708-90db-4abab3f2fe06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightPrimaryAxisTouch"",
                    ""type"": ""Button"",
                    ""id"": ""ce243026-49e2-4335-8054-cc79b5cb8b8d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftPosition"",
                    ""type"": ""Value"",
                    ""id"": ""949d9316-ce31-4acf-924f-7a9ac7441ab4"",
                    ""expectedControlType"": ""Vector3"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftRotation"",
                    ""type"": ""Value"",
                    ""id"": ""a4894109-7b8f-441e-9a31-51ee632dec75"",
                    ""expectedControlType"": ""Quaternion"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftPrimaryAxis"",
                    ""type"": ""Value"",
                    ""id"": ""f7555399-3d85-4a77-bdf2-32f2cda4e854"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftGrip"",
                    ""type"": ""Value"",
                    ""id"": ""21d9fd8c-bf26-492a-8b9b-29f182b843b2"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftTrigger"",
                    ""type"": ""Value"",
                    ""id"": ""bf5c5f0b-8666-4317-b04d-fe269ecce35d"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftGripButton"",
                    ""type"": ""Button"",
                    ""id"": ""c8040fbb-1c34-4e78-8808-aff057ac40be"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftTriggerButton"",
                    ""type"": ""Button"",
                    ""id"": ""4adacbde-b022-4802-a3c1-8930bc9c3bd0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftPrimaryButton"",
                    ""type"": ""Button"",
                    ""id"": ""4adad690-2a1d-49a3-8850-3809e3cff972"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftSecondaryButton"",
                    ""type"": ""Button"",
                    ""id"": ""7f440a59-3efa-4539-8ba3-1029dc76e1e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftPrimaryAxisClick"",
                    ""type"": ""Button"",
                    ""id"": ""6d3e9c06-7b79-4abe-80ca-4719e6fb7774"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftPrimaryAxisTouch"",
                    ""type"": ""Button"",
                    ""id"": ""2954b2c3-80a8-4061-82a3-29188ec3bee3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""05ab80cb-8321-4f6b-98a3-d79d6c27a35e"",
                    ""path"": ""<XRHMD>/centerEyePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""HeadPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb0e9225-4c32-4552-9d1b-56eac73579fe"",
                    ""path"": ""<XRHMD>/centerEyeRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""HeadRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8575609-bbd0-4de0-b873-b429cbf8d157"",
                    ""path"": ""<XRController>{RightHand}/thumbstickTouched"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightPrimaryAxisTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""798ba10c-316c-4915-91c2-e24c0dba4787"",
                    ""path"": ""<XRController>{RightHand}/trackpadTouched"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightPrimaryAxisTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ee339a0-56dc-4087-9df0-ea25656790f6"",
                    ""path"": ""<XRController>{RightHand}/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""RightPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f12c0cb9-549f-428b-8edc-d038117aa1d5"",
                    ""path"": ""<XRController>{RightHand}/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""RightRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""68824735-4320-4eb9-9c60-15390a6e0b76"",
                    ""path"": ""<XRController>{RightHand}/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightGrip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""55be7168-0b45-4ce7-80d7-90a8e0a256eb"",
                    ""path"": ""<XRController>{RightHand}/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""edaad9d8-ea6a-4aa6-87d1-0638e2c50076"",
                    ""path"": ""<XRController>{RightHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""RightTriggerButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fcbbcb30-8918-4553-b042-569a9137e373"",
                    ""path"": ""<XRController>{RightHand}/triggerButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTriggerButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dcfcb53d-1d37-446d-960f-29ea522db8fb"",
                    ""path"": ""<XRInputV1::Oculus::OculusTouchControllerRight>{RightHand}/triggerpressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightTriggerButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ea1daae-3743-4b2e-aca8-26498dea9521"",
                    ""path"": ""<XRController>{RightHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightSecondaryButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01a6a1f8-eaa4-4cbd-8576-58fbe58f17ec"",
                    ""path"": ""<XRInputV1::Oculus::OculusTouchControllerRight>{RightHand}/secondarybutton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightSecondaryButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfb780cf-4374-4b12-9b37-9c63a4d29ba3"",
                    ""path"": ""<XRController>{RightHand}/primary2DAxisClick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightPrimaryAxisClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cb8bd46e-45e2-43ba-bcf8-aefa4de005ad"",
                    ""path"": ""<XRInputV1::Oculus::OculusTouchControllerRight>{RightHand}/thumbstickclicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightPrimaryAxisClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0e1bcdd-020a-4acd-8369-a260c9039047"",
                    ""path"": ""<XRController>{RightHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightPrimaryButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a330987e-24d3-4aa0-b500-e9a198ba8dd2"",
                    ""path"": ""<XRInputV1::Oculus::OculusTouchControllerRight>{RightHand}/primarybutton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightPrimaryButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e35ebf68-63c9-4b63-aa50-eaf8613bda68"",
                    ""path"": ""<XRController>{RightHand}/gripButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""RightGripButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1e09401-2831-4542-a9e2-c39d52c244bc"",
                    ""path"": ""<XRController>{RightHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightGripButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ad44338a-00e3-48d6-bc11-a08450baf117"",
                    ""path"": ""<XRInputV1::Oculus::OculusTouchControllerRight>{RightHand}/grippressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightGripButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""efdbdb34-67bb-4c89-b544-13592b7ab2fc"",
                    ""path"": ""<XRController>{RightHand}/primary2DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightPrimaryAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0aafe9ba-8062-4e10-bec1-eee7480c1bc7"",
                    ""path"": ""<XRInputV1::Oculus::OculusTouchControllerRight>{RightHand}/thumbstick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightPrimaryAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""709d003f-9e21-42c4-a668-2693d0d7172a"",
                    ""path"": ""<XRController>{LeftHand}/devicePosition"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""LeftPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a034efeb-86da-468e-96d9-f11fc1aa1733"",
                    ""path"": ""<XRController>{LeftHand}/deviceRotation"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""LeftRotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ad7a2c1-0b05-44ee-9818-e3ce7a7c3b4f"",
                    ""path"": ""<XRController>{LeftHand}/grip"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftGrip"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f086a110-95f2-422c-bcf8-8091f5de4ca0"",
                    ""path"": ""<XRController>{LeftHand}/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTrigger"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1db5b994-0a9b-4eba-9df1-af3c031f7cfb"",
                    ""path"": ""<XRController>{RightHand}/gripButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""LeftGripButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""67c7493b-2b00-4206-a5b4-18214c280f85"",
                    ""path"": ""<XRController>{LeftHand}/gripPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftGripButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bdd1938-5b19-4316-8562-b9f7f1011418"",
                    ""path"": ""<XRInputV1::Oculus::OculusTouchControllerLeft>{LeftHand}/grippressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftGripButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03886f35-174c-4709-bd57-1dcef4aa5698"",
                    ""path"": ""<XRController>{LeftHand}/triggerPressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Generic XR Controller"",
                    ""action"": ""LeftTriggerButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e052d6e0-857f-43b7-a5eb-4ad0ebf2f405"",
                    ""path"": ""<XRController>{LeftHand}/triggerButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTriggerButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb62de26-efa3-411e-be5e-a89821894f3d"",
                    ""path"": ""<XRInputV1::Oculus::OculusTouchControllerLeft>{LeftHand}/triggerpressed"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftTriggerButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""727d0860-715c-49ef-9c95-9a6620ddeb96"",
                    ""path"": ""<XRController>{LeftHand}/primaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftPrimaryButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d786c06d-0527-4e6e-87da-7e2ba74da901"",
                    ""path"": ""<XRInputV1::Oculus::OculusTouchControllerLeft>{LeftHand}/primarybutton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftPrimaryButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee7e4e47-455d-454b-98d6-1c332ed9c83a"",
                    ""path"": ""<XRController>{LeftHand}/secondaryButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftSecondaryButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""21dbf68e-5f7e-4052-a85b-d0533d79269f"",
                    ""path"": ""<XRInputV1::Oculus::OculusTouchControllerLeft>{LeftHand}/secondarybutton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftSecondaryButton"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""826e86cb-31ce-4e7f-a0e9-23ba33d14446"",
                    ""path"": ""<XRController>{LeftHand}/primary2DAxisClick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftPrimaryAxisClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""af2b6772-a30c-4467-8af9-98f592f21b4c"",
                    ""path"": ""<XRInputV1::Oculus::OculusTouchControllerLeft>{LeftHand}/thumbstickclicked"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftPrimaryAxisClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97163af8-7228-40b5-a4f1-e38676353b27"",
                    ""path"": ""<XRController>{LeftHand}/thumbstickTouched"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftPrimaryAxisTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""05712632-b675-4603-9388-6a464e1fd8b9"",
                    ""path"": ""<XRController>{LeftHand}/trackpadTouched"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftPrimaryAxisTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""990d080b-47c7-438a-a577-201aaa983eab"",
                    ""path"": ""<XRController>{LeftHand}/primary2DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftPrimaryAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f6e5dd3-e01e-4aeb-8ce0-0468654bf97d"",
                    ""path"": ""<XRInputV1::Oculus::OculusTouchControllerLeft>{LeftHand}/thumbstick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftPrimaryAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // OpenVR
            m_OpenVR = asset.FindActionMap("OpenVR", throwIfNotFound: true);
            m_OpenVR_HeadRotation = m_OpenVR.FindAction("HeadRotation", throwIfNotFound: true);
            m_OpenVR_HeadPosition = m_OpenVR.FindAction("HeadPosition", throwIfNotFound: true);
            m_OpenVR_RightPosition = m_OpenVR.FindAction("RightPosition", throwIfNotFound: true);
            m_OpenVR_RightRotation = m_OpenVR.FindAction("RightRotation", throwIfNotFound: true);
            m_OpenVR_RightPrimaryAxis = m_OpenVR.FindAction("RightPrimaryAxis", throwIfNotFound: true);
            m_OpenVR_RightGrip = m_OpenVR.FindAction("RightGrip", throwIfNotFound: true);
            m_OpenVR_RightTrigger = m_OpenVR.FindAction("RightTrigger", throwIfNotFound: true);
            m_OpenVR_RightGripButton = m_OpenVR.FindAction("RightGripButton", throwIfNotFound: true);
            m_OpenVR_RightTriggerButton = m_OpenVR.FindAction("RightTriggerButton", throwIfNotFound: true);
            m_OpenVR_RightPrimaryButton = m_OpenVR.FindAction("RightPrimaryButton", throwIfNotFound: true);
            m_OpenVR_RightSecondaryButton = m_OpenVR.FindAction("RightSecondaryButton", throwIfNotFound: true);
            m_OpenVR_RightPrimaryAxisClick = m_OpenVR.FindAction("RightPrimaryAxisClick", throwIfNotFound: true);
            m_OpenVR_RightPrimaryAxisTouch = m_OpenVR.FindAction("RightPrimaryAxisTouch", throwIfNotFound: true);
            m_OpenVR_LeftPosition = m_OpenVR.FindAction("LeftPosition", throwIfNotFound: true);
            m_OpenVR_LeftRotation = m_OpenVR.FindAction("LeftRotation", throwIfNotFound: true);
            m_OpenVR_LeftPrimaryAxis = m_OpenVR.FindAction("LeftPrimaryAxis", throwIfNotFound: true);
            m_OpenVR_LeftGrip = m_OpenVR.FindAction("LeftGrip", throwIfNotFound: true);
            m_OpenVR_LeftTrigger = m_OpenVR.FindAction("LeftTrigger", throwIfNotFound: true);
            m_OpenVR_LeftGripButton = m_OpenVR.FindAction("LeftGripButton", throwIfNotFound: true);
            m_OpenVR_LeftTriggerButton = m_OpenVR.FindAction("LeftTriggerButton", throwIfNotFound: true);
            m_OpenVR_LeftPrimaryButton = m_OpenVR.FindAction("LeftPrimaryButton", throwIfNotFound: true);
            m_OpenVR_LeftSecondaryButton = m_OpenVR.FindAction("LeftSecondaryButton", throwIfNotFound: true);
            m_OpenVR_LeftPrimaryAxisClick = m_OpenVR.FindAction("LeftPrimaryAxisClick", throwIfNotFound: true);
            m_OpenVR_LeftPrimaryAxisTouch = m_OpenVR.FindAction("LeftPrimaryAxisTouch", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // OpenVR
        private readonly InputActionMap m_OpenVR;
        private IOpenVRActions m_OpenVRActionsCallbackInterface;
        private readonly InputAction m_OpenVR_HeadRotation;
        private readonly InputAction m_OpenVR_HeadPosition;
        private readonly InputAction m_OpenVR_RightPosition;
        private readonly InputAction m_OpenVR_RightRotation;
        private readonly InputAction m_OpenVR_RightPrimaryAxis;
        private readonly InputAction m_OpenVR_RightGrip;
        private readonly InputAction m_OpenVR_RightTrigger;
        private readonly InputAction m_OpenVR_RightGripButton;
        private readonly InputAction m_OpenVR_RightTriggerButton;
        private readonly InputAction m_OpenVR_RightPrimaryButton;
        private readonly InputAction m_OpenVR_RightSecondaryButton;
        private readonly InputAction m_OpenVR_RightPrimaryAxisClick;
        private readonly InputAction m_OpenVR_RightPrimaryAxisTouch;
        private readonly InputAction m_OpenVR_LeftPosition;
        private readonly InputAction m_OpenVR_LeftRotation;
        private readonly InputAction m_OpenVR_LeftPrimaryAxis;
        private readonly InputAction m_OpenVR_LeftGrip;
        private readonly InputAction m_OpenVR_LeftTrigger;
        private readonly InputAction m_OpenVR_LeftGripButton;
        private readonly InputAction m_OpenVR_LeftTriggerButton;
        private readonly InputAction m_OpenVR_LeftPrimaryButton;
        private readonly InputAction m_OpenVR_LeftSecondaryButton;
        private readonly InputAction m_OpenVR_LeftPrimaryAxisClick;
        private readonly InputAction m_OpenVR_LeftPrimaryAxisTouch;
        public struct OpenVRActions
        {
            private @XRInputActions m_Wrapper;
            public OpenVRActions(@XRInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @HeadRotation => m_Wrapper.m_OpenVR_HeadRotation;
            public InputAction @HeadPosition => m_Wrapper.m_OpenVR_HeadPosition;
            public InputAction @RightPosition => m_Wrapper.m_OpenVR_RightPosition;
            public InputAction @RightRotation => m_Wrapper.m_OpenVR_RightRotation;
            public InputAction @RightPrimaryAxis => m_Wrapper.m_OpenVR_RightPrimaryAxis;
            public InputAction @RightGrip => m_Wrapper.m_OpenVR_RightGrip;
            public InputAction @RightTrigger => m_Wrapper.m_OpenVR_RightTrigger;
            public InputAction @RightGripButton => m_Wrapper.m_OpenVR_RightGripButton;
            public InputAction @RightTriggerButton => m_Wrapper.m_OpenVR_RightTriggerButton;
            public InputAction @RightPrimaryButton => m_Wrapper.m_OpenVR_RightPrimaryButton;
            public InputAction @RightSecondaryButton => m_Wrapper.m_OpenVR_RightSecondaryButton;
            public InputAction @RightPrimaryAxisClick => m_Wrapper.m_OpenVR_RightPrimaryAxisClick;
            public InputAction @RightPrimaryAxisTouch => m_Wrapper.m_OpenVR_RightPrimaryAxisTouch;
            public InputAction @LeftPosition => m_Wrapper.m_OpenVR_LeftPosition;
            public InputAction @LeftRotation => m_Wrapper.m_OpenVR_LeftRotation;
            public InputAction @LeftPrimaryAxis => m_Wrapper.m_OpenVR_LeftPrimaryAxis;
            public InputAction @LeftGrip => m_Wrapper.m_OpenVR_LeftGrip;
            public InputAction @LeftTrigger => m_Wrapper.m_OpenVR_LeftTrigger;
            public InputAction @LeftGripButton => m_Wrapper.m_OpenVR_LeftGripButton;
            public InputAction @LeftTriggerButton => m_Wrapper.m_OpenVR_LeftTriggerButton;
            public InputAction @LeftPrimaryButton => m_Wrapper.m_OpenVR_LeftPrimaryButton;
            public InputAction @LeftSecondaryButton => m_Wrapper.m_OpenVR_LeftSecondaryButton;
            public InputAction @LeftPrimaryAxisClick => m_Wrapper.m_OpenVR_LeftPrimaryAxisClick;
            public InputAction @LeftPrimaryAxisTouch => m_Wrapper.m_OpenVR_LeftPrimaryAxisTouch;
            public InputActionMap Get() { return m_Wrapper.m_OpenVR; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(OpenVRActions set) { return set.Get(); }
            public void SetCallbacks(IOpenVRActions instance)
            {
                if (m_Wrapper.m_OpenVRActionsCallbackInterface != null)
                {
                    @HeadRotation.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnHeadRotation;
                    @HeadRotation.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnHeadRotation;
                    @HeadRotation.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnHeadRotation;
                    @HeadPosition.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnHeadPosition;
                    @HeadPosition.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnHeadPosition;
                    @HeadPosition.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnHeadPosition;
                    @RightPosition.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightPosition;
                    @RightPosition.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightPosition;
                    @RightPosition.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightPosition;
                    @RightRotation.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightRotation;
                    @RightRotation.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightRotation;
                    @RightRotation.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightRotation;
                    @RightPrimaryAxis.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightPrimaryAxis;
                    @RightPrimaryAxis.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightPrimaryAxis;
                    @RightPrimaryAxis.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightPrimaryAxis;
                    @RightGrip.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightGrip;
                    @RightGrip.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightGrip;
                    @RightGrip.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightGrip;
                    @RightTrigger.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightTrigger;
                    @RightTrigger.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightTrigger;
                    @RightTrigger.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightTrigger;
                    @RightGripButton.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightGripButton;
                    @RightGripButton.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightGripButton;
                    @RightGripButton.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightGripButton;
                    @RightTriggerButton.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightTriggerButton;
                    @RightTriggerButton.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightTriggerButton;
                    @RightTriggerButton.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightTriggerButton;
                    @RightPrimaryButton.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightPrimaryButton;
                    @RightPrimaryButton.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightPrimaryButton;
                    @RightPrimaryButton.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightPrimaryButton;
                    @RightSecondaryButton.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightSecondaryButton;
                    @RightSecondaryButton.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightSecondaryButton;
                    @RightSecondaryButton.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightSecondaryButton;
                    @RightPrimaryAxisClick.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightPrimaryAxisClick;
                    @RightPrimaryAxisClick.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightPrimaryAxisClick;
                    @RightPrimaryAxisClick.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightPrimaryAxisClick;
                    @RightPrimaryAxisTouch.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightPrimaryAxisTouch;
                    @RightPrimaryAxisTouch.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightPrimaryAxisTouch;
                    @RightPrimaryAxisTouch.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnRightPrimaryAxisTouch;
                    @LeftPosition.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftPosition;
                    @LeftPosition.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftPosition;
                    @LeftPosition.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftPosition;
                    @LeftRotation.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftRotation;
                    @LeftRotation.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftRotation;
                    @LeftRotation.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftRotation;
                    @LeftPrimaryAxis.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftPrimaryAxis;
                    @LeftPrimaryAxis.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftPrimaryAxis;
                    @LeftPrimaryAxis.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftPrimaryAxis;
                    @LeftGrip.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftGrip;
                    @LeftGrip.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftGrip;
                    @LeftGrip.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftGrip;
                    @LeftTrigger.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftTrigger;
                    @LeftTrigger.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftTrigger;
                    @LeftTrigger.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftTrigger;
                    @LeftGripButton.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftGripButton;
                    @LeftGripButton.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftGripButton;
                    @LeftGripButton.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftGripButton;
                    @LeftTriggerButton.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftTriggerButton;
                    @LeftTriggerButton.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftTriggerButton;
                    @LeftTriggerButton.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftTriggerButton;
                    @LeftPrimaryButton.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftPrimaryButton;
                    @LeftPrimaryButton.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftPrimaryButton;
                    @LeftPrimaryButton.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftPrimaryButton;
                    @LeftSecondaryButton.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftSecondaryButton;
                    @LeftSecondaryButton.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftSecondaryButton;
                    @LeftSecondaryButton.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftSecondaryButton;
                    @LeftPrimaryAxisClick.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftPrimaryAxisClick;
                    @LeftPrimaryAxisClick.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftPrimaryAxisClick;
                    @LeftPrimaryAxisClick.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftPrimaryAxisClick;
                    @LeftPrimaryAxisTouch.started -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftPrimaryAxisTouch;
                    @LeftPrimaryAxisTouch.performed -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftPrimaryAxisTouch;
                    @LeftPrimaryAxisTouch.canceled -= m_Wrapper.m_OpenVRActionsCallbackInterface.OnLeftPrimaryAxisTouch;
                }
                m_Wrapper.m_OpenVRActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @HeadRotation.started += instance.OnHeadRotation;
                    @HeadRotation.performed += instance.OnHeadRotation;
                    @HeadRotation.canceled += instance.OnHeadRotation;
                    @HeadPosition.started += instance.OnHeadPosition;
                    @HeadPosition.performed += instance.OnHeadPosition;
                    @HeadPosition.canceled += instance.OnHeadPosition;
                    @RightPosition.started += instance.OnRightPosition;
                    @RightPosition.performed += instance.OnRightPosition;
                    @RightPosition.canceled += instance.OnRightPosition;
                    @RightRotation.started += instance.OnRightRotation;
                    @RightRotation.performed += instance.OnRightRotation;
                    @RightRotation.canceled += instance.OnRightRotation;
                    @RightPrimaryAxis.started += instance.OnRightPrimaryAxis;
                    @RightPrimaryAxis.performed += instance.OnRightPrimaryAxis;
                    @RightPrimaryAxis.canceled += instance.OnRightPrimaryAxis;
                    @RightGrip.started += instance.OnRightGrip;
                    @RightGrip.performed += instance.OnRightGrip;
                    @RightGrip.canceled += instance.OnRightGrip;
                    @RightTrigger.started += instance.OnRightTrigger;
                    @RightTrigger.performed += instance.OnRightTrigger;
                    @RightTrigger.canceled += instance.OnRightTrigger;
                    @RightGripButton.started += instance.OnRightGripButton;
                    @RightGripButton.performed += instance.OnRightGripButton;
                    @RightGripButton.canceled += instance.OnRightGripButton;
                    @RightTriggerButton.started += instance.OnRightTriggerButton;
                    @RightTriggerButton.performed += instance.OnRightTriggerButton;
                    @RightTriggerButton.canceled += instance.OnRightTriggerButton;
                    @RightPrimaryButton.started += instance.OnRightPrimaryButton;
                    @RightPrimaryButton.performed += instance.OnRightPrimaryButton;
                    @RightPrimaryButton.canceled += instance.OnRightPrimaryButton;
                    @RightSecondaryButton.started += instance.OnRightSecondaryButton;
                    @RightSecondaryButton.performed += instance.OnRightSecondaryButton;
                    @RightSecondaryButton.canceled += instance.OnRightSecondaryButton;
                    @RightPrimaryAxisClick.started += instance.OnRightPrimaryAxisClick;
                    @RightPrimaryAxisClick.performed += instance.OnRightPrimaryAxisClick;
                    @RightPrimaryAxisClick.canceled += instance.OnRightPrimaryAxisClick;
                    @RightPrimaryAxisTouch.started += instance.OnRightPrimaryAxisTouch;
                    @RightPrimaryAxisTouch.performed += instance.OnRightPrimaryAxisTouch;
                    @RightPrimaryAxisTouch.canceled += instance.OnRightPrimaryAxisTouch;
                    @LeftPosition.started += instance.OnLeftPosition;
                    @LeftPosition.performed += instance.OnLeftPosition;
                    @LeftPosition.canceled += instance.OnLeftPosition;
                    @LeftRotation.started += instance.OnLeftRotation;
                    @LeftRotation.performed += instance.OnLeftRotation;
                    @LeftRotation.canceled += instance.OnLeftRotation;
                    @LeftPrimaryAxis.started += instance.OnLeftPrimaryAxis;
                    @LeftPrimaryAxis.performed += instance.OnLeftPrimaryAxis;
                    @LeftPrimaryAxis.canceled += instance.OnLeftPrimaryAxis;
                    @LeftGrip.started += instance.OnLeftGrip;
                    @LeftGrip.performed += instance.OnLeftGrip;
                    @LeftGrip.canceled += instance.OnLeftGrip;
                    @LeftTrigger.started += instance.OnLeftTrigger;
                    @LeftTrigger.performed += instance.OnLeftTrigger;
                    @LeftTrigger.canceled += instance.OnLeftTrigger;
                    @LeftGripButton.started += instance.OnLeftGripButton;
                    @LeftGripButton.performed += instance.OnLeftGripButton;
                    @LeftGripButton.canceled += instance.OnLeftGripButton;
                    @LeftTriggerButton.started += instance.OnLeftTriggerButton;
                    @LeftTriggerButton.performed += instance.OnLeftTriggerButton;
                    @LeftTriggerButton.canceled += instance.OnLeftTriggerButton;
                    @LeftPrimaryButton.started += instance.OnLeftPrimaryButton;
                    @LeftPrimaryButton.performed += instance.OnLeftPrimaryButton;
                    @LeftPrimaryButton.canceled += instance.OnLeftPrimaryButton;
                    @LeftSecondaryButton.started += instance.OnLeftSecondaryButton;
                    @LeftSecondaryButton.performed += instance.OnLeftSecondaryButton;
                    @LeftSecondaryButton.canceled += instance.OnLeftSecondaryButton;
                    @LeftPrimaryAxisClick.started += instance.OnLeftPrimaryAxisClick;
                    @LeftPrimaryAxisClick.performed += instance.OnLeftPrimaryAxisClick;
                    @LeftPrimaryAxisClick.canceled += instance.OnLeftPrimaryAxisClick;
                    @LeftPrimaryAxisTouch.started += instance.OnLeftPrimaryAxisTouch;
                    @LeftPrimaryAxisTouch.performed += instance.OnLeftPrimaryAxisTouch;
                    @LeftPrimaryAxisTouch.canceled += instance.OnLeftPrimaryAxisTouch;
                }
            }
        }
        public OpenVRActions @OpenVR => new OpenVRActions(this);
        public interface IOpenVRActions
        {
            void OnHeadRotation(InputAction.CallbackContext context);
            void OnHeadPosition(InputAction.CallbackContext context);
            void OnRightPosition(InputAction.CallbackContext context);
            void OnRightRotation(InputAction.CallbackContext context);
            void OnRightPrimaryAxis(InputAction.CallbackContext context);
            void OnRightGrip(InputAction.CallbackContext context);
            void OnRightTrigger(InputAction.CallbackContext context);
            void OnRightGripButton(InputAction.CallbackContext context);
            void OnRightTriggerButton(InputAction.CallbackContext context);
            void OnRightPrimaryButton(InputAction.CallbackContext context);
            void OnRightSecondaryButton(InputAction.CallbackContext context);
            void OnRightPrimaryAxisClick(InputAction.CallbackContext context);
            void OnRightPrimaryAxisTouch(InputAction.CallbackContext context);
            void OnLeftPosition(InputAction.CallbackContext context);
            void OnLeftRotation(InputAction.CallbackContext context);
            void OnLeftPrimaryAxis(InputAction.CallbackContext context);
            void OnLeftGrip(InputAction.CallbackContext context);
            void OnLeftTrigger(InputAction.CallbackContext context);
            void OnLeftGripButton(InputAction.CallbackContext context);
            void OnLeftTriggerButton(InputAction.CallbackContext context);
            void OnLeftPrimaryButton(InputAction.CallbackContext context);
            void OnLeftSecondaryButton(InputAction.CallbackContext context);
            void OnLeftPrimaryAxisClick(InputAction.CallbackContext context);
            void OnLeftPrimaryAxisTouch(InputAction.CallbackContext context);
        }
    }
}
