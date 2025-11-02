using UnityEngine;

[CreateAssetMenu(
    fileName = "NewCometData",
    menuName = "MyGame/Comet Data")]
public class CometData : ScriptableObject
{
    [Header("Ruch")]
    public float orbitRadius = 3f;   // odległość od środka
    public float orbitSpeed = 30f;   // stopnie na sekundę

    [Header("Wygląd")]
    public Color tint = Color.white;
}
