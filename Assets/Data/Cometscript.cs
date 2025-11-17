using UnityEngine;

public class Cometscript : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // ruch komety w dół
        transform.position += Vector3.down * speed * Time.deltaTime;

        // jeśli kometa jest bardzo nisko, usuń ją
        if (transform.position.y < -10f)
        {
            Destroy(gameObject);
        }
    }
}
