using UnityEngine;
using System.Collections;

namespace BLabTexasHoldEmProject
{
    public class BBSoundController : MonoBehaviour
    {
        public AudioClip pickCard;
        public AudioClip moveCard;
        public AudioClip chipHandle;
        public AudioClip cardsShuffle;
        public AudioClip genBip;
        public AudioClip rotateCard;
        [Header("Only Multiplayer")]
        public AudioClip cleanCards;
        [Header("Only Multiplayer")]
        public AudioClip cleanChips;

        // Use this for initialization
        void Start() { }

        // Update is called once per frame
        void Update() { }

        public void playClip(AudioClip ac)
        {
            GetComponent<AudioSource>().PlayOneShot(ac);
        }
    }
}
