using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float seconds = 1;

    float _timeElapsed = 0;
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed >= seconds)
        {
            Destroy(gameObject);
        }
    }
}
