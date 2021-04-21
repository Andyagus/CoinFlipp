using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

using UnityEngine.UI;

public class LevelLoader : MonoBehaviour{

    public int sceneIndex;
    private float fillSpeed = 0.2f;
    private Slider progressSlider;

    //private void Awake()
    //{

    //}

    public void Start()
    {
        progressSlider = gameObject.GetComponent<Slider>();
        progressSlider.value = 0;

        //progressSlider.value += 100;
        //IncrementProgress(0.75f);
    }

    public void Update()
    {
        if(progressSlider.value < 1) {
            progressSlider.value += fillSpeed * Time.deltaTime;
        }
        else
        {
            StartCoroutine(LoadNewScene(waitTime: 1));
        }
    }

    private IEnumerator LoadNewScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene("Scene2");
    }


}   
    