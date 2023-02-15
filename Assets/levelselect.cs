using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelselect : MonoBehaviour
{


    public int level;
    public TextMesh leveltext;
    // Start is called before the first frame update
    void Start()
    {
        leveltext.text = level.ToString();
    }
public void openScene()
    {



        SceneManager.LoadScene("Level "+ level.ToString());

    }
    
}
