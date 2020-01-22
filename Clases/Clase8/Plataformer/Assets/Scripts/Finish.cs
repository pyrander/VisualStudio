using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D (Collider2D col)
    {
        Debug.Log ("GANO: " + col);
        if (col.tag.Equals("Player")) {
            SceneManager.LoadScene (1);
        }
    }
}
