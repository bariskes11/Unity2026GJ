using PrimeTween;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject levelCompletedPanel;
    [SerializeField] GameObject warningPanel;
    [SerializeField] Button btnRetry;
    [SerializeField] Button btnNextLevel;
    private void Start()
    {
        gameOverPanel.SetActive(false);
        levelCompletedPanel.SetActive(false);
        warningPanel.gameObject.SetActive(false);
        EventManager.OnPlayerDead.AddListener(EnableGameOverPanel);
        btnRetry.onClick.RemoveAllListeners();
        btnRetry.onClick.AddListener(ReloadCurrentScene);
        btnNextLevel.onClick.RemoveAllListeners();
        btnNextLevel.onClick.AddListener(LoadNextLevel);
    }

    private void LoadNextLevel()
    {
        Scene activeScene = SceneManager.GetActiveScene();
       int nextScene= activeScene.buildIndex + 1; // this will change we need to mae sure next Scenario exists
        SceneManager.LoadScene(nextScene); //  
    }

    private void ReloadCurrentScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex);
    }

    public void EnableGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }

    public void LevelCompleted()
    {
        levelCompletedPanel.SetActive(true);
    }

    public void ShowWarning()
    {
        warningPanel.gameObject.SetActive(true);
        warningPanel.transform.localScale = Vector3.zero;
        Tween.Scale(warningPanel.transform, Vector3.one, .2F);

        Tween.StopAll(transform); 

        Sequence.Create().Chain(Tween.Scale(warningPanel.transform, Vector3.one, 0.35f,  Ease.OutQuad))
            .ChainDelay(3f)
            .Chain(Tween.Scale(warningPanel.transform, Vector3.zero,  0.3f, Ease.InQuad)).OnComplete(()=>
            {
                warningPanel.gameObject.SetActive(true);
                warningPanel.transform.localScale = Vector3.zero;
            });

    }

}
