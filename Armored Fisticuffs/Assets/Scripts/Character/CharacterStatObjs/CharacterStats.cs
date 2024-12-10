using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character Creation")]
public class CharacterStats : ScriptableObject
{
    [SerializeField] 
    public Basic_Settings Basic_Info;
    [SerializeField] 
    public Grounded_Moves_Settings Grounded_Moves;

    [System.Serializable]
    public struct Basic_Settings
    {
        public string Character_Name;
        public int Character_Health;
        public float Character_Speed;
        public float Character_Jump;
    }

    [System.Serializable]
    public struct Grounded_Moves_Settings
    {
        [SerializeField]
        public Grounded_Jab Jab;
        [SerializeField]
        public Grounded_SideTilt SideTilt;
        [SerializeField]
        public Grounded_Heavy_SideTilt Heavy_SildeTilt;
        [SerializeField]
        public Grounded_DownTilt DownTilt;
        [SerializeField] 
        public Grounded_Heavy_Down_Tilt Heavy_Down_Tilt;
        [SerializeField]
        public Grounded_UpTilt UpTilt;
        [SerializeField] 
        public Grounded_Heavy_Up_Tilt Heavy_Up_Tilt;


        [System.Serializable]
        public struct Grounded_Jab
        {
            public AnimationClip Hit_Anim;
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
        }

        [System.Serializable]
        public struct Grounded_SideTilt
        {
            public AnimationClip Hit_Anim;
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
        }

        [System.Serializable]
        public struct Grounded_Heavy_SideTilt
        {
            public AnimationClip Hit_Anim;
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
        }

        [System.Serializable]
        public struct Grounded_DownTilt
        {
            public AnimationClip Hit_Anim;
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
        }

        [System.Serializable]
        public struct Grounded_Heavy_Down_Tilt
        {
            public AnimationClip Hit_Anim;
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
        }

        [System.Serializable]
        public struct Grounded_UpTilt
        {
            public AnimationClip Hit_Anim;
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
        }

        [System.Serializable]
        public struct Grounded_Heavy_Up_Tilt
        {
            public AnimationClip Hit_Anim;
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
        }
    }
}
