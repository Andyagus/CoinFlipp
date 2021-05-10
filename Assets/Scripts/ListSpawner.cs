using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
public class ListSpawner : MonoBehaviour
{

    public ButtonHandler buttonHandlerScript;
    [SerializeField] GameObject parentPanel;
    private Image panelImage;
    [SerializeField] GameObject bgBlur;
    [SerializeField] GameObject scrollView;
    [SerializeField] Sprite newImageSprite;
    [SerializeField] Sprite headsSprite;
    [SerializeField] Sprite tailsSprite;
    [SerializeField] Sprite redPanel;
    [SerializeField] Sprite greenPanel;

    [SerializeField] TextMeshProUGUI positionNumber;
    
    GameObject obj;

    private void Start()
    {
        var buttonScript = GameObject.FindGameObjectWithTag("ButtonHandler");
        buttonHandlerScript = buttonScript.GetComponent<ButtonHandler>();
    }

    public void CloseList()
    {
        scrollView.SetActive(false);
        bgBlur.SetActive(false);
        ObjectPooler.Instance.ReturnToPool(tag: "green");


    }


    public void ListPopulate()
    {
        scrollView.SetActive(true);
        bgBlur.SetActive(true);


        var turnsList = buttonHandlerScript.turnsList;
        for (int i = 0; i < turnsList.Count; i++)
        {

            var correct = turnsList[i].bet == turnsList[i].cameUp;
            
            obj = ObjectPooler.Instance.SpawnFromPool("green", parentPanel.transform.position, Quaternion.identity);

            var objImage = obj.GetComponent<Image>();

            objImage.sprite = correct ? greenPanel : redPanel;
            var turnCounter = obj.GetComponentsInChildren<TextMeshProUGUI>();
            //turnCounter.GetComponent<TextMeshProUGUI>();
            var cameUpSide = obj.transform.GetChild(1);
            var betSide = obj.transform.GetChild(0);
            betSide.GetChild(turnsList[i].bet == true ? 0 : 1).gameObject.SetActive(true);
            cameUpSide.GetChild(turnsList[i].cameUp == true ? 0 : 1).gameObject.SetActive(true);
          
            turnCounter[2].text = ($"#{i+1}");
        }

    }


}
