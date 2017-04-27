using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public static int m_currentScore;
    public static int m_highScore;
 
    public static int m_currentLevel = 0;
    public static int m_unlockedLevel;

    public static void CompleteLevel()
    {
        m_currentLevel += 1;
        Application.LoadLevel(m_currentLevel);
    }
}
