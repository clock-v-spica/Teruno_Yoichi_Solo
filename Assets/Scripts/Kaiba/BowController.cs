using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Kaiba.Teruno_System
{
    public class BowController : MonoBehaviour
    {
        [SerializeField] public GameObject _bow; // 弓本体
        [SerializeField] public GameObject _arrow; // 矢本体
        [SerializeField] public GameObject _bowCenter; // 弓の中心、矢の発射点
        [SerializeField] public GameObject _LeftHand;
        [SerializeField] public GameObject _RightHand;
        [SerializeField] Transform stringBone; // 弓のRig

        Vector3 _localstartPos;
        private GameObject arrow;

        // Start is called before the first frame update
        void Start()
        {
            _localstartPos = stringBone.localPosition;
        }

        // Update is called once per frame
        void Update()
        {
            if (!TerunoManager.IsHost)
                return;

            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                arrow = Network.NetworkUtility.Instantiate("Arrow_Bow", _RightHand.transform.position, _RightHand.transform.rotation * Quaternion.Euler(0f, -90.0f, 0f));
                arrow.transform.parent = _RightHand.transform;
            }

        }

        /// <summary>
        /// 弓を引く距離を指定する。距離はワールド座標系での距離
        /// </summary>
        /// <param name="worldDistance">World distance.</param>
        public void BowDrawing(float worldDistance)
        {
            stringBone.localPosition =
                new Vector3(
                    -(_localstartPos.x + worldDistance * (1f / stringBone.lossyScale.x)),
                    stringBone.localPosition.y,
                    stringBone.localPosition.z
                );
        }

        /// <summary>
        /// 弓の位置を元に戻す
        /// </summary>
        public void Reset()
        {
            stringBone.transform.localPosition = _localstartPos;
        }
    }

}

