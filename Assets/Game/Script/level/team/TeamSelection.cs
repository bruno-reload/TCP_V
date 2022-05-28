using Character.Control;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Team
{
    public enum TEAM { Red, Blue };
    public class TeamSelection : MonoBehaviour
    {
        public TEAM team = TEAM.Red;
        public bool Captain;

        private void Start()
        {
            gameObject.tag = team.ToString();
            GetComponent<CharacterControl>().feedback.enabled = Captain;
            if (Captain)
            {
                GetComponent<CharacterControl>().SetControl(GetComponent<PlayerInput>());
            }
            else
            {
                GetComponent<CharacterControl>().SetControl(GetComponent<AIControl>());
            }
        }

        internal void Swap()
        {
            string teamName = gameObject.tag.ToString();
            GameObject[] team = GameObject.FindGameObjectsWithTag(teamName);
            foreach (GameObject go in team)
            {
                go.GetComponent<CharacterControl>().SetControl(GetComponent<AIControl>());
                go.GetComponent<CharacterControl>().feedback.enabled = false;
            }
            GetComponent<CharacterControl>().SetControl(GetComponent<PlayerInput>());
            GetComponent<CharacterControl>().feedback.enabled = true;
        }
    }
}
