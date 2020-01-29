
using UnityEngine;
using UnityEngine.UI;

public class HeartBar : MonoBehaviour
{
    public Image fullHeart;
    public Image[] quarterHeart;
    private int maxLife = 40;
    private int maxHearts {
        get {
            return maxLife / 4;
        }
    }
    public int currentLife = 12;
    public int quarterHearts {
        get {
            return currentLife % 4;
        }
    }
    public int fullHearts {
        get {
            return currentLife / 4;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateHearts ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Clear ()
    {
        foreach (Transform child in transform) {
            Destroy (child.gameObject);
        }
    }

    public void UpdateHearts ()
    {
        Clear ();
        for (int i=0;i<fullHearts;i++) {
            Instantiate<Image> (fullHeart,transform);
        }

        if(quarterHearts > 0) {
            Instantiate<Image> (quarterHeart[quarterHearts], transform);
        }
        int currentHearts = fullHearts + (quarterHearts > 0?1:0);
        int emptyheartCount = maxHearts - currentHearts;
 
        for(int i = 0; i < emptyheartCount; i++) {
             Instantiate<Image> (quarterHeart[0], transform);
         }
        
    }

}
