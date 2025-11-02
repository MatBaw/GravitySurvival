using UnityEngine;

public class Comet : MonoBehaviour
{
    public CometData data;        
    public Transform orbitCenter;

    private float _angle;

    private void Start()
    {
        if (data == null)
        {
            Debug.LogWarning("Brak CometData na " + gameObject.name);
            return;
        }

        if (orbitCenter == null)
        {
            GameObject center = new GameObject("OrbitCenterAuto");
            orbitCenter = center.transform;
            orbitCenter.position = Vector3.zero;
        }

        // startową pozycja
        transform.position = orbitCenter.position + Vector3.right * data.orbitRadius;

        // kolor ze ScriptableObject
        var sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = data.tint;
        }
    }

    private void Update()
    {
        if (data == null || orbitCenter == null) return;

        _angle += data.orbitSpeed * Time.deltaTime;          // rośnij kąt
        float rad = _angle * Mathf.Deg2Rad;                  // na radiany

        Vector3 offset = new Vector3(
            Mathf.Cos(rad),
            Mathf.Sin(rad),
            0f
        ) * data.orbitRadius;

        transform.position = orbitCenter.position + offset;
    }
}
