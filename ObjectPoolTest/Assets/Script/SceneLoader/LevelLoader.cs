using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public Slider loadingSlider;
    public Text enterLevelText;

    private AsyncOperation currentLoadingData;
    private bool loadFininsh = false;

    private void Update()
    {
        if (loadFininsh && Input.GetKeyDown(KeyCode.E))
        {
            currentLoadingData.allowSceneActivation = false;
            Debug.Log("press");
        }
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadLevelAsync(sceneIndex));
    }

    // Async load level 
    private IEnumerator LoadLevelAsync(int sceneIndex)
    {
        currentLoadingData = SceneManager.LoadSceneAsync(sceneIndex);

        loadingSlider.gameObject.SetActive(true);

        currentLoadingData.allowSceneActivation = false;

        while (!currentLoadingData.isDone)
        {
            loadingSlider.value = Mathf.Clamp(currentLoadingData.progress / 0.9f, 0.0f, 1.0f);

            if (currentLoadingData.progress >= 0.9f)
            {
                loadingSlider.value = 1.0f;
                enterLevelText.gameObject.SetActive(true);
                loadFininsh = true;
            }
            Debug.Log(loadingSlider.value);
            yield return null;
        }
    }
}
