using System.Collections;
using System.Collections.Generic;
using OVR;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        [SerializeField] public ScreenFader _CenterEyeAnchor;

        Vector3 _localstartPos;
        private GameObject arrow;
        [SerializeField] public int arrow_max = 5;
        [SerializeField] public int arrow_num = 0;

        [SerializeField]
        SoundPlayer sfxPlayer;

        [SerializeField]
        ScoreUIView uIView;

        // Start is called before the first frame update
        void Start()
        {
            _localstartPos = stringBone.localPosition;

            StartCoroutine(StartUICoroutine());
        }


        IEnumerator StartUICoroutine()
        {
                sfxPlayer.PlayJoyChorus();
            yield return new WaitForSeconds(2f);
            uIView.FadeIn();
            yield return new WaitForSeconds(5f);


            uIView.FadeOut();

            yield return new WaitForSeconds(3f);

            ShooterManager.Shottable = true;
        }

        // Update is called once per frame
        void Update()
        {
            /*
            if (!TerunoManager.IsHost)
                return;

            if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
            {
                arrow = Network.NetworkUtility.Instantiate("Prefabs/Arrow_Bow", _RightHand.transform.position, _RightHand.transform.rotation * Quaternion.Euler(0f, 0.0f, 0f));
                arrow.transform.parent = _RightHand.transform;
            }
            */


        }

        /// <summary>
        /// 弓を引く距離を指定する。距離はワールド座標系での距離
        /// </summary>
        /// <param name="worldDistance">World distance.</param>
        public void BowDrawing(float worldDistance)
        {
            stringBone.localPosition =
                new Vector3(
                    (_localstartPos.x + worldDistance * 0.8f * (1f / stringBone.lossyScale.x)),
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

        public void MainSceneFinish()
        {
            Network.NetworkUtility.ExitRoom();
            SceneManager.LoadScene("Kawasaki_Title");
        }

        public void CountArrow(bool wasSuccess)
        {
            arrow_num++;

            StartCoroutine(CountUICoroutine(wasSuccess));

            if (arrow_num == arrow_max)
            {
                StartCoroutine(FadeCoroutine());
            }
        }
        IEnumerator CountUICoroutine(bool success)
        {
            uIView.SetCountText(arrow_num);

            if (!success)
                sfxPlayer.PlaySadChorus();

            if (success)
            {
                Time.timeScale = 0.2f;
                yield return new WaitForSecondsRealtime(1.0f);
                Time.timeScale = 1f;

                sfxPlayer.PlayJoyChorus();
            }
            yield return new WaitForSeconds(2f);
            uIView.FadeIn();
            yield return new WaitForSeconds(3f);


            if (success)
                uIView.AddSuccessIcon();
            else
                uIView.AddFailedIcon();

            yield return new WaitForSeconds(2f);
            uIView.FadeOut();


            ShooterManager.Shottable = true;
        }

        IEnumerator FadeCoroutine()
        {
            yield return new WaitForSecondsRealtime(12f);

            yield return _CenterEyeAnchor.FadeOut();
            yield return new WaitForSeconds(2.0f);
            MainSceneFinish();
        }

    }

}

