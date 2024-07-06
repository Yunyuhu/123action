using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class ARBodyTrackingAvatarMapper : MonoBehaviour
    {
        [SerializeField]
        private ARHumanBodyManager humanBodyManager;
        
        [SerializeField]
        private Animator avatarAnimator;

        private Dictionary<HumanBodyBones, int> humanBodyBoneIndexMap;

        void Start()
        {
            if (humanBodyManager == null)
            {
                Debug.LogError("ARHumanBodyManager component is missing.");
                return;
            }

            if (avatarAnimator == null)
            {
                Debug.LogError("Animator component is missing.");
                return;
            }

            InitializeBoneIndexMap();
        }

        void Update()
        {
            if (humanBodyManager == null || avatarAnimator == null) return;

            foreach (var humanBody in humanBodyManager.trackables)
            {
                UpdateAvatarPose(humanBody);
            }
        }

        private void InitializeBoneIndexMap()
        {
            humanBodyBoneIndexMap = new Dictionary<HumanBodyBones, int>
            {
                { HumanBodyBones.Hips, 0 },
                { HumanBodyBones.LeftUpperLeg, 1 },
                { HumanBodyBones.LeftLowerLeg, 2 },
                { HumanBodyBones.LeftFoot, 3 },
                { HumanBodyBones.RightUpperLeg, 4 },
                { HumanBodyBones.RightLowerLeg, 5 },
                { HumanBodyBones.RightFoot, 6 },
                { HumanBodyBones.Spine, 7 },
                { HumanBodyBones.Chest, 8 },
                { HumanBodyBones.Neck, 9 },
                { HumanBodyBones.Head, 10 },
                { HumanBodyBones.LeftShoulder, 11 },
                { HumanBodyBones.LeftUpperArm, 12 },
                { HumanBodyBones.LeftLowerArm, 13 },
                { HumanBodyBones.LeftHand, 14 },
                { HumanBodyBones.RightShoulder, 15 },
                { HumanBodyBones.RightUpperArm, 16 },
                { HumanBodyBones.RightLowerArm, 17 },
                { HumanBodyBones.RightHand, 18 }
            };
        }

        private void UpdateAvatarPose(ARHumanBody body)
        {
            foreach (var boneMapping in humanBodyBoneIndexMap)
            {
                int jointIndex = boneMapping.Value;
                XRHumanBodyJoint joint = body.joints[jointIndex];

                Transform boneTransform = avatarAnimator.GetBoneTransform(boneMapping.Key);
                if (boneTransform != null)
                {
                    boneTransform.localPosition = joint.localPose.position;
                    boneTransform.localRotation = joint.localPose.rotation;
                }
            }
        }
    }
}
