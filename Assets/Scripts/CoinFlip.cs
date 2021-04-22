using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
public class CoinFlip : MonoBehaviour
{
    // Start is called before the first frame update

    public ButtonHandler buttonHandlerScript;
    public Sprite badSprite;
    public Sprite goodSprite;
    public GameObject contentPanel;
    public GameObject parentPanel;
    public GameObject greenPanel;
    public GameObject redPanel;
    public GameObject scrollView;
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI scoreText2;
    public Image betImageComponent;
    public Image cameUpImageComponent;
    public Image betImageComponentRed;
    public Image cameUpImageComponentRed;
    public GameObject bgBlur;
    public Sprite newImageSprite;
    public Sprite heads;
    public Sprite tails;


    //public int spriteLocation = 1;

    private void Start()
    {
        GameObject buttonScript = GameObject.Find("GameObject");
        buttonHandlerScript = buttonScript.GetComponent<ButtonHandler>();
        
    }

    public void Update()
    {

    }
    public void CloseList()
    {
        scrollView.SetActive(false);
        bgBlur.SetActive(false);
        //zamerican = parentPanel.transform.Find("content");
        //Destroy(contentPanel.gameObject);
        foreach (Transform child in parentPanel.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void CheckList()
    {

        Debug.Log(buttonHandlerScript.turnsList.Count);
        scrollView.SetActive(true);
        bgBlur.SetActive(true);
        greenPanel.SetActive(true);
        redPanel.SetActive(true);
        int i = 0;
        foreach (var item in buttonHandlerScript.turnsList) {
            i++;


            //GameObject newObja = Instantiate(greenPanel);
            //newObja.GetComponent<RectTransform>().SetParent(parentPanel.transform);



            if (item.bet == item.cameUp)
            {

                scoreText1.text = ("#" + i);

                if (item.bet == "tails")
                {
                    betImageComponent.sprite = tails;
                    cameUpImageComponent.sprite = tails;

                }
                if (item.bet == "heads")
                {
                    betImageComponent.sprite = heads;
                    cameUpImageComponent.sprite = heads;

                }

                GameObject newObject = Instantiate(greenPanel);

                newObject.GetComponent<RectTransform>().SetParent(parentPanel.transform);

                //newObject.transform(new Vector2(0, 0, 0));

            }
            else if (item.bet != item.cameUp)
            {
                scoreText2.text = ("#" + i);

                if (item.bet == "tails")
                {
                    betImageComponentRed.sprite = tails;
                    cameUpImageComponentRed.sprite = heads;

                }
                if (item.bet == "heads")
                {
                    betImageComponentRed.sprite = heads;
                    cameUpImageComponentRed.sprite = tails;

                }

                GameObject newObject = Instantiate(redPanel);

                newObject.GetComponent<RectTransform>().SetParent(parentPanel.transform);
                //newObject.transform.localPosition = new Vector3(0, spriteLocation, 0);

            }
        }
        
      
            
    }

}
