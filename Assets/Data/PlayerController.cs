using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;   // prędkość ruchu
    public float xLimit = 8f;  // ograniczenie ruchu na boki
    public float yLimit = 4f;  // ograniczenie ruchu góra/dół

    void Update()
    {
        // odczyt wciśnięć klawiszy
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical   = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(horizontal, vertical, 0f) * speed * Time.deltaTime;

        transform.position += move;

        // ograniczamy ruch, żeby gracz nie wyszedł poza ekran
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -xLimit, xLimit);
        pos.y = Mathf.Clamp(pos.y, -yLimit, yLimit);
        transform.position = pos;
    }
}
