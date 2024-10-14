// ThrowWrench.cs
using System.Collections;
using UnityEngine;
using TMPro;
using Utils;

namespace Player
{
    public class ThrowWrench : MonoBehaviour
    {
        public int maxWrenches;
        private int wrenchCount;
        public float reloadTime;
        public GameObject wrenchPrefab;
        public float speed;
        public float rotationSpeed;
        public float despawnDistance;
        public TextMeshProUGUI text;
        public CameraShake shake;
        public float shakeAmount;
        public float shakeTime;
        private BuildingPlacementManager bpm;

        void Start()
        {
            UpdateWrenchCountDisplay();
            bpm = GameObject.FindWithTag("BPM").GetComponent<BuildingPlacementManager>();
        }

        void Update()
        {
            UpdateWrenchCountDisplay();

            bool clicking = Input.GetMouseButtonDown(0);

            bool buyMenuIsOpen = false;
            buyMenuIsOpen = bpm.buyMenu.buyMenuPanel.activeInHierarchy;

            bool isPlacing = false;
            isPlacing = bpm.IsPlacing();

            if (clicking && wrenchCount < maxWrenches && !buyMenuIsOpen && !isPlacing)
            {
                ThrowWrenchObject();
            }
        }

        private void UpdateWrenchCountDisplay()
        {
            text.text = (maxWrenches - wrenchCount).ToString();
            if (wrenchCount < 0)
            {
                wrenchCount = 0;
            }
        }

        private void ThrowWrenchObject()
        {
            wrenchCount++;

            GameObject newWrench = Instantiate(wrenchPrefab, transform.position, transform.rotation);
            Wrench wrench = newWrench.GetComponent<Wrench>();

            if (wrench != null)
            {
                wrench.direction = Mouse.getDirection();
                wrench.throwWrench = this;
            }
        }

        public void ReduceWrenchCount()
        {
            StartCoroutine(Reload());
        }

        private IEnumerator Reload()
        {
            yield return new WaitForSeconds(reloadTime);
            wrenchCount--;
            UpdateWrenchCountDisplay();
        }

        public void Reset()
        {
            wrenchCount = 0;
        }
    }
}
