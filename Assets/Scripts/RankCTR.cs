using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RankCTR : MonoBehaviour
{

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Round;
    public TextMeshProUGUI Missed;
    public TextMeshProUGUI Time;

    public void Init(string name, int round,int missed, float time)
    {
        Name.text = name;
        Round.text = round.ToString();
        Missed.text = missed.ToString();
        Time.text = time.ToString();
    }

}
