using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace AIMovement
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class Brain : MonoBehaviour
    {
        public int DNALength = 1;
        public float timeAlive;
        internal DNA dna;

        private ThirdPersonCharacter m_character;
        private Vector3 m_Move;
        private bool m_Jump;

        bool alive = true;

        private void OnCollisionEnter(Collision obj)
        {
            if (obj.gameObject.tag == "dead")
            {
                alive = false;
            }
        }

        public void Init()
        {
            dna = new DNA(DNALength, 6);
            m_character = GetComponent<ThirdPersonCharacter>();
            timeAlive = 0;
            alive = true;
        }

        private void Update()
        {

        }

        private void FixedUpdate()
        {
            float h = 0;
            float v = 0;
            bool crouch = false;
            if (dna.GetGene(0) == 0) v = 1;
            else if (dna.GetGene(0) == 1) v = -1;
            else if (dna.GetGene(0) == 2) v = -1;
            else if (dna.GetGene(0) == 3) v = 1;
            else if (dna.GetGene(0) == 4) m_Jump = true;
            else if (dna.GetGene(0) == 5) crouch = true;

            m_Move = v * Vector3.forward + h * Vector3.right;
            m_character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
            if(alive)
            {
                timeAlive = Time.deltaTime;
            }
        }
    }
}