using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI score;
    int scoreInt = 0;
    // Start is called before the first frame update
    void Start()
    {
        score.text = scoreInt.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreInt++; //Temp until we get hazards in
        score.text = scoreInt.ToString();
    }
}
