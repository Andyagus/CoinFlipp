using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
public class ListSpawner : MonoBehaviour
{

    public ButtonHandler buttonHandlerScript;
    [SerializeField] GameObject parentPanel;
    [SerializeField] GameObject panel;
    private Image panelImage;
    [SerializeField] GameObject bgBlur;
    [SerializeField] GameObject scrollView;
    [SerializeField] TextMeshProUGUI scoreText1;
    [SerializeField] Image betImageComponent;
    [SerializeField] Image cameUpImageComponent;
    [SerializeField] Sprite newImageSprite;
    [SerializeField] Sprite headsSprite;
    [SerializeField] Sprite tailsSprite;
    [SerializeField] Sprite redPanel;
    [SerializeField] Sprite greenPanel;
    ObjectPooler objectPooler;
    GameObject obj ;
    private bool listActive = false; 

    private void Start()
    {
        
        panelImage = panel.GetComponent<Image>();
        var buttonScript = GameObject.FindGameObjectWithTag("ButtonHandler");
        buttonHandlerScript = buttonScript.GetComponent<ButtonHandler>();
    }

    public void CloseList()
    {
        //var turnsList = buttonHandlerScript.turnsList;

        scrollView.SetActive(false);
        bgBlur.SetActive(false);
        //for(int i = 0; i < turnsList.Count; i++)
        //{
        //}
        ObjectPooler.Instance.ReturnToPool(tag: "green");

        //Debug.Log(turnsList.Count);

    }

    private void FixedUpdate()
    {
        //obj = ObjectPooler.Instance.SpawnFromPool("green", parentPanel.transform.position, Quaternion.identity);


    }

    public void ListPopulate()
    {
        scrollView.SetActive(true);
        bgBlur.SetActive(true);

        //if (ObjectPooler.Instance != null) {
        //    ObjectPooler.Instance.ReturnToPool(tag: "green");
        //    ObjectPooler.Instance.ReturnToPool(tag: "red");
        //}

        //if(ObjectPooler.Instance != null)
        //{
        //}
        

        var turnsList = buttonHandlerScript.turnsList;
        for (int i = 0; i < turnsList.Count; i++)
        {

            scoreText1.text = ($"#{i+1}");
            var correct = turnsList[i].bet == turnsList[i].cameUp;

            obj = ObjectPooler.Instance.SpawnFromPool("green", parentPanel.transform.position, Quaternion.identity);
            var objImage = obj.GetComponent<Image>();
            objImage.sprite = correct ? greenPanel : redPanel;
            var cameUpSide = obj.transform.GetChild(1);
            var betSide = obj.transform.GetChild(0);

            betSide.GetChild(turnsList[i].bet == true ? 0 : 1).gameObject.SetActive(true);
            cameUpSide.GetChild(turnsList[i].cameUp == true ? 0 : 1).gameObject.SetActive(true);



        }

    }


}
