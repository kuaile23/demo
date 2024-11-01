using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basecard : MonoBehaviour
{
    private Transform tx;
    public Sprite[] cardsprites;
    public int cardtype;
    // Start is called before the first frame update
    void Start()
    {
     tx=GameObject.Find("Control").GetComponent<Tx>()._Tx;
     cardtype = Random.Range(0, cardsprites.Length);
    GetComponent<Image>().sprite = cardsprites[cardtype];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Enter()
    {
        transform.localScale =new Vector3(1.2f,1.2f,1.2f);
    }
    public void Exit() 
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    public void Draw()
    {
        if (Control.onTimeCard!=null&&Control.onTimeCard!=this.gameObject)
        {
            return;
        }
        transform.position=Input.mousePosition;
        transform.SetParent(GameObject.Find("TempCard").transform);
        if(Vector3.Distance(tx.position,transform.position) < 80)
        {
            tx.gameObject.SetActive(true);
        }
        else
        {
            tx.gameObject.SetActive(false);
        }
    }
    public void up()
    {if (Vector3.Distance(tx.position, transform.position) < 80) 
        { 
            transform.position = tx.position;
            Control.onTimeCard = this.gameObject;
        }
        else
        {
            transform.SetParent(GameObject.Find("cards").transform);
            if (Control.onTimeCard == this.gameObject)
            {
                Control.onTimeCard = null;
            }
        }
    }

}
