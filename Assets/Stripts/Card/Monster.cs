using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Monster : MonoBehaviour
{
    public int HP;
    public Text hpText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "ÉúÃü£º"+HP;
    }
    public void Check()
    {
        if (Control.onTimeCard == null)
        {
            return;
        }
        if (Control.onTimeCard.GetComponent<Basecard>().cardtype == 0)
        {
            HP++;
        }
        else if (Control.onTimeCard.GetComponent<Basecard>().cardtype == 1)
        {

            HP--;
        }
        Destroy(Control.onTimeCard);
        if (GameObject.Find("tx"))
        {
           GameObject.Find("tx").SetActive(false);
        }
    }
}
