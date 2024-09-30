using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character Creation")]
public class CharacterStats : ScriptableObject
{
    [SerializeField] Basic_Settings Basic_Info;
    [SerializeField] Grounded_Moves_Settings Grounded_Moves;
    [SerializeField] Aerial_Moves_Settings Aerial_Moves;

    [System.Serializable]
    public struct Basic_Settings
    {
        public string Character_Name;
        public int Character_Health;
        public int Character_Speed;
    }

    [System.Serializable]
    public struct Grounded_Moves_Settings
    {
        [SerializeField] Grounded_Jab Jab;
        [SerializeField] Grounded_Heavy_Jab Heavy_Jab;
        [SerializeField] Grounded_SideTilt SideTilt;
        [SerializeField] Grounded_Heavy_SildeTilt Heavy_SildeTilt;
        [SerializeField] Grounded_DownTilt DownTilt;
        [SerializeField] Grounded_Heavy_Down_Tilt Heavy_Down_Tilt;
        [SerializeField] Grounded_UpTilt UpTilt;
        [SerializeField] Grounded_Heavy_Up_Tilt Heavy_Up_Tilt;


        [System.Serializable]
        public struct Grounded_Jab
        {
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
            public int Frames_StartUp;
            public int Frames_Active;
            public int Frames_Recovery;
        }

        [System.Serializable]
        public struct Grounded_Heavy_Jab
        {
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
            public int Frames_StartUp;
            public int Frames_Active;
            public int Frames_Recovery;
        }

        [System.Serializable]
        public struct Grounded_SideTilt
        {
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
            public int Frames_StartUp;
            public int Frames_Active;
            public int Frames_Recovery;
        }

        [System.Serializable]
        public struct Grounded_Heavy_SildeTilt
        {
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
            public int Frames_StartUp;
            public int Frames_Active;
            public int Frames_Recovery;
        }

        [System.Serializable]
        public struct Grounded_DownTilt
        {
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
            public int Frames_StartUp;
            public int Frames_Active;
            public int Frames_Recovery;
        }

        [System.Serializable]
        public struct Grounded_Heavy_Down_Tilt
        {
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
            public int Frames_StartUp;
            public int Frames_Active;
            public int Frames_Recovery;
        }

        [System.Serializable]
        public struct Grounded_UpTilt
        {
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
            public int Frames_StartUp;
            public int Frames_Active;
            public int Frames_Recovery;
        }

        [System.Serializable]
        public struct Grounded_Heavy_Up_Tilt
        {
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
            public int Frames_StartUp;
            public int Frames_Active;
            public int Frames_Recovery;
        }
    }

    [System.Serializable]
    public struct Aerial_Moves_Settings
    {
        [SerializeField] Aerial_Jab Jab;
        [SerializeField] Aerial_SideTilt SideTilt;
        [SerializeField] Aerial_DownTilt DownTilt;
        [SerializeField] Aerial_UpTilt UpTilt;


        [System.Serializable]
        public struct Aerial_Jab
        {
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
            public int Frames_StartUp;
            public int Frames_Active;
            public int Frames_Recovery;
        }

        [System.Serializable]
        public struct Aerial_SideTilt
        {
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
            public int Frames_StartUp;
            public int Frames_Active;
            public int Frames_Recovery;
        }

        [System.Serializable]
        public struct Aerial_DownTilt
        {
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
            public int Frames_StartUp;
            public int Frames_Active;
            public int Frames_Recovery;
        }

        [System.Serializable]
        public struct Aerial_UpTilt
        {
            public int Damage;
            public Vector2 Hit_Size;
            public Vector3 Hit_Location;
            public Vector2 Hurt_Size;
            public Vector3 Hurt_Location;
            public Vector2 Launch_Angle;
            public float Launch_Magnitude;
            public int Frames_StartUp;
            public int Frames_Active;
            public int Frames_Recovery;
        }
    }
}
