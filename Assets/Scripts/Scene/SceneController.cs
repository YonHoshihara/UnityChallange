using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject fade;
    [SerializeField] private GameObject credits;
    [SerializeField] private float loadSceneTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScece(string sceneName)
    {
        StartCoroutine(LoadSceneOnTime(sceneName, loadSceneTime));
    }
    private IEnumerator LoadSceneOnTime(string sceneName, float loadTime)
    {
        fade.SetActive(true);
        yield return new WaitForSeconds(loadTime);
        SceneManager.LoadScene(sceneName);
    }

    public void ShowCredits()
    {
        if (credits.activeSelf)
        {
            credits.SetActive(false);
        }
        else
        {
            credits.SetActive(true);
        }
    }
}
