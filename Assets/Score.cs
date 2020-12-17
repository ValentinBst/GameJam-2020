using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour

{
    [SerializeField]
    int ScoreBase;

    TMP_Text textscore;

    [SerializeField]
    int SoustractionParTir;

    int ScoreN;
    public void Shoot()

    {
        ScoreN -= SoustractionParTir;
        if (ScoreN < 0)
        {
            ScoreN = 0;
        }
        textscore.text = "Score : " + ScoreN;
    }

    private void Start()
    {
        ScoreN = ScoreBase;
        textscore = GetComponent<TMP_Text>();
        textscore.text = "Score : " + ScoreN;
    }
}
