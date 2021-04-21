using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListCrusher : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> highStrung;
    public Sprite badSprite;
    public GameObject parentPanel;
    public GameObject historyPanel;
    int spriteLocation = 1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (string i in highStrung)
            {
                spriteLocation += 30;
                Debug.Log(i);
                GameObject NewObj = new GameObject();
                Image NewImage = NewObj.AddComponent<Image>();
                NewImage.sprite = badSprite;
                NewObj.GetComponent<RectTransform>().SetParent(parentPanel.transform);
                NewObj.transform.localPosition = new Vector3(0, spriteLocation, 0);

            }
        }
        
    }
}
