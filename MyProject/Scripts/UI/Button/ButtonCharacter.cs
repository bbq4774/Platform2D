using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCharacter : MonoBehaviour
{
    public void ChooseCharacter()
    {
        SceneManager.LoadScene("Character");
    }
}
