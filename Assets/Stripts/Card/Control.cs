using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Transform cards;
    public static GameObject onTimeCard;//µ±Ç°¿¨ÅÆ
    private bool CanRight=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {if (!CanRight)
        {
            cards.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(cards.GetComponent<RectTransform>().anchoredPosition, new Vector3(1, -200, 0), Time.deltaTime * 3f);
            if (cards.childCount == 0 && !GameObject.FindWithTag("card"))
            {
                for (int i = 0; i < 5; i++)
                {
                    GameObject n = Instantiate(Resources.Load("card")) as GameObject;
                    n.transform.SetParent(cards.transform, false);
                    n.name = "card";
                }
            }

        }
        else {

            cards.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(cards.GetComponent<RectTransform>().anchoredPosition,new Vector3(890,-200,0),Time.deltaTime*3f);
        }
    }
    public void UpdateCard()
    {
        foreach (Transform item in cards)
        {
            Destroy(item.gameObject);
        }
        Destroy(Control.onTimeCard);
        if (GameObject.Find("tx"))
        {
            GameObject.Find("tx").SetActive(false);
        }
        cards.GetComponent<RectTransform>().anchoredPosition=new Vector3(-889,-200,0);
    }
    public void BoxEat()
    {
        CanRight = true;
        StartCoroutine("StartCard",0);
    }
    private IEnumerator StartCard()
    {
        yield return new WaitForSeconds(1f);
        CanRight = false;
        UpdateCard();
    }
}
