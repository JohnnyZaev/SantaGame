using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityAtoms.SceneMgmt;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private SceneFieldConstant gameScene;
    [SerializeField] private Image progressBar;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        
    }

    private void Start()
    {
        LoadScene(gameScene);
    }
    
    private async void LoadScene(SceneFieldConstant s)
    {
        var scene = SceneManager.LoadSceneAsync(s.Value.BuildIndex);
        scene.allowSceneActivation = false;

        do
        {
            await Task.Delay(100);
            progressBar.fillAmount = scene.progress;
        } while (scene.progress < 0.9f);

        await Task.Delay(1500);
        progressBar.fillAmount = 1f;
        scene.allowSceneActivation = true;
    }
}
