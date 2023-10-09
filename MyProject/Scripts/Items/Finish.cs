using UnityEngine.SceneManagement;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private Animator anima;

    private void Awake()
    {
        anima = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anima.SetTrigger("finish");
        Invoke(nameof(NextLevel), 2f);
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
