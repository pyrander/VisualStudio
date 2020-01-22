using UnityEngine;
using Plataformer;

public class CameraController : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        if (target==null) {
            target = Player.instance.transform;
        }
        Debug.Log (target.name);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate ()
    {
        Vector3 pos = target.position;
        pos.z = -10;
        transform.position = pos;
    }
}
