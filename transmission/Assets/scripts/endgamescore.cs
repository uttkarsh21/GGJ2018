using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endgamescore : MonoBehaviour {

    public Text end_score_text;

    private void Start()
    {
        end_score_text.text = PlayerPrefs.GetInt("final_score").ToString();
    }
}
