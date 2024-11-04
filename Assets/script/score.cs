using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class score : MonoBehaviour
{
    public TextMeshProUGUI score_show;
    public TextMeshProUGUI final_score_show;
    public static int points = 0;


    // Update is called once per frame
    void Update()
    {
        score_show.text = points.ToString();
        if (fail_trigger.ending)
        {
            final_score_show.text = "You got " + score.points.ToString() + " !!!";
            Destroy(score_show);
        }
    }
}
