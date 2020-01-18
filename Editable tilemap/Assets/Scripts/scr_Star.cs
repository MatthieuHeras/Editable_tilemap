using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_Star : MonoBehaviour
{

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, 5));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Player"))
        {
            int currentIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentIndex >= SceneManager.sceneCountInBuildSettings - 1)
                SceneManager.LoadScene(0);
            else
                SceneManager.LoadScene(currentIndex + 1);
        }
    }
}
