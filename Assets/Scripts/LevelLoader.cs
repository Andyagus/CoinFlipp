using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

using UnityEngine.UI;

public class LevelLoader : MonoBehaviour{

    private readonly float fillSpeed = 0.2f;
    private Slider progressSlider;

    public IEnumerator Start()
    {
        progressSlider = gameObject.GetComponent<Slider>();
        progressSlider.value = 0;

        do
        {
            progressSlider.value += fillSpeed * Time.deltaTime;
            yield return null;
        } while (progressSlider.value < 1);
            SceneManager.LoadScene("Scene2");
    }

}   
    