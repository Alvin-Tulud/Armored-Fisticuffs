using UnityEngine;

public class MatchData : MonoBehaviour
{
    private GameObject p1Char;
    private GameObject p2Char;

    private int LevelIndex;

    public static MatchData instance;

    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }
}
