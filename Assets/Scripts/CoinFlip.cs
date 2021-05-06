using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
public class CoinFlip : MonoBehaviour
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

    private void Start()
    {
        panelImage = panel.GetComponent<Image>();
        var buttonScript = GameObject.FindGameObjectWithTag("ButtonHandler");
        buttonHandlerScript = buttonScript.GetComponent<ButtonHandler>();
    }

    public void CloseList()
    {
        scrollView.SetActive(false);
        bgBlur.SetActive(false);
        //ObjectPooler.Instance.SetActive(false);
        //ObjectPooler.Instance.ReturnToPool("green", transform.position, Quaternion.identity);
    }

    public void ListPopulate()
    {
        scrollView.SetActive(true);
        bgBlur.SetActive(true);

        var turnsList = buttonHandlerScript.turnsList;
        for (int i = 0; i < turnsList.Count; i++)
        {
            scoreText1.text = ($"#{i+1}");
            var correct = turnsList[i].bet == turnsList[i].cameUp;
            panelImage.sprite = (correct ? greenPanel : redPanel);
            var obj = ObjectPooler.Instance.SpawnFromPool(correct ? "green" : "red", parentPanel.transform.position, Quaternion.identity);
            var cameUpSide = obj.transform.GetChild(1);
            var betSide = obj.transform.GetChild(0);
            obj.transform.SetParent(parentPanel.transform);
            betSide.GetChild(turnsList[i].bet == true ? 0 : 1).gameObject.SetActive(true);
            cameUpSide.GetChild(turnsList[i].cameUp == true ? 0 : 1).gameObject.SetActive(true);  
        }

    }


}
