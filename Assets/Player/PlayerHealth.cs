using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Utils;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace Player
{
    public class PlayerHealth : MonoBehaviour
    {
        public int max;
        public int hp {get; private set;}
       // public TextMeshProUGUI text;
        public Image[] hearts;
        AudioController audioController;

        private void Awake()
        {
            audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
        }
        void Start()
        {
            hp = max;
           // text.text = "" + hp;
            UpdateHeartVisibility();
        }

        public void Reduce()
        {
            audioController.PlaySFX(audioController.player_hurt);
            hp--;
            //  text.text = "" + hp;
            UpdateHeartVisibility();
        }

        public void Reset()
        {
            hp = max;
           // text.text = "" + hp;
            UpdateHeartVisibility();
        }

        void Update()
        {
            if (hp <= 0)
            {
                audioController.PlaySFX(audioController.lose);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        void UpdateHeartVisibility()
        {
            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < hp)
                {
                    hearts[i].gameObject.SetActive(true); // Show heart
                }
                else
                {
                    hearts[i].gameObject.SetActive(false); // Hide heart
                }
            }
        }

    }
}
