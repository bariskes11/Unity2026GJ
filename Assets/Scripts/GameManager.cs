using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void EnableGameOverPanel()
    {
        gameObject.SetActive(true);
    }

}
