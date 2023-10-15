using System;
using System.Collections;
using TMPro;
using UnityEngine;


    [RequireComponent(typeof(TMP_Text))]
    public class FPSDisplay : MonoBehaviour
    {
        private TMP_Text fpsText;
        public float updateInterval = 0.2f;
        private void Start()
        {
            fpsText = GetComponent<TMP_Text>();
            StartCoroutine(FramesPerSecond());
        }

        private IEnumerator FramesPerSecond()
        {
            while (true)
            {
                float fps = 1f / Time.deltaTime;
                DisplayFPS(fps.ToString("F2"));
                yield return new WaitForSeconds(updateInterval);
            }
        }

        private void DisplayFPS(string fps)
        {
            fpsText.text = $"{fps} FPS \nDebug Version 0.0.1";
        }
    }

