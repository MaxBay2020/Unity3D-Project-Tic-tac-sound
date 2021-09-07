using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickEvents : MonoBehaviour
{
    public GameObject player01;
    public GameObject player02;

    public void GetLetter()
    {
        GameObject letterObject = EventSystem.current.currentSelectedGameObject;
        letterObject.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        letterObject.GetComponent<Button>().enabled = false;
        if (!GameManger._instance.isPlayer2)
        {
            //if its player01 turn
            
            letterObject.transform.SetParent(player01.transform);
            letterObject.transform.localPosition = new Vector3(player01.transform.position.x + 180, 0,0);

            //player01 = GameObject.Instantiate(letterObject);
            //player01.transform.SetParent(player01.transform,false);
            //player01.transform.localScale = Vector3.one;
            //letterObject.GetComponent<Image>().color = new Color(237 / 255f, 203 / 255f, 109 / 255f);
            //player01.transform.position = player01.transform.position+Vector3.one;
            GameManger._instance.player01Ready = true;
        }
        else
        {
            //if its player02 turn
            letterObject.transform.SetParent(player02.transform);
            letterObject.transform.localPosition = new Vector3(player02.transform.position.x + 120, 0, 0);
            //player02 = GameObject.Instantiate(letterObject);
            //player02.transform.localScale = Vector3.one;
            //player02.transform.SetParent(player02.transform, false);
            //letterObject.GetComponent<Image>().color = Color.blue;
            //player02.transform.position = player02.transform.position + Vector3.one*100;
            GameManger._instance.player02Ready = true;
        }

        GameManger._instance.isPlayer2 = !GameManger._instance.isPlayer2;
    }
}
