using System;
using System.Collections;
using UnityEngine;

namespace BBQ.Cooking
{
    public class Arm : MonoBehaviour
    {
        [SerializeField] private Vector3[] jointOffsetDirection = new Vector3[3];

        [SerializeField] private Vector3[] jointStroke = new Vector3[3];

        [SerializeField] private float strokeTime;

        public bool followMouse;
        private Vector3 mouseAttraction;

        private LineRenderer renderer;

        private Camera mainCam;

        private void Awake()
        {
            renderer = GetComponentInChildren<LineRenderer>();
            mainCam = Camera.main;

            StartCoroutine(WiggleJoint(0f, 1));
            StartCoroutine(WiggleJoint(.2f, 2));
        }

        private Vector3 GetMouseDirection(Vector3 offset)
        {
            Vector3 mousePos = (mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                Vector3.Distance(transform.position, mainCam.transform.position))));

            return transform.InverseTransformDirection(mousePos - ((transform.rotation * offset) + transform.position))
                .normalized * .02f;
        }

        private IEnumerator WiggleJoint(float delay, int jointIndex)
        {
            while (true)
            {
                Vector3 offset = (Mathf.PingPong(Time.time + delay, strokeTime)) * jointStroke[jointIndex];

                renderer.SetPosition(jointIndex,
                    followMouse
                        ? jointOffsetDirection[jointIndex] + offset +
                          GetMouseDirection(jointOffsetDirection[jointIndex])
                        : jointOffsetDirection[jointIndex] + offset);
                yield return null;
            }
        }
    }
}