using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light directionalLight; // Kierunkowe �r�d�o �wiat�a reprezentuj�ce s�o�ce
    public float dayDuration = 120f; // Czas trwania ca�ego cyklu w sekundach

    private float time;
    private float intensity;

    void Update()
    {
        // Aktualizacja czasu
        time += Time.deltaTime / dayDuration;

        // Obliczanie intensywno�ci �wiat�a w zale�no�ci od pory dnia
        if (time < 0.25f || time > 0.75f)
            intensity = Mathf.Clamp01(1 - Mathf.Abs(0.5f - time) * 4);
        else
            intensity = Mathf.Clamp01((time - 0.25f) * 4);

        // Ustawianie intensywno�ci i k�ta �wiat�a
        directionalLight.intensity = intensity;
        directionalLight.transform.rotation = Quaternion.Euler(new Vector3((time - 0.5f) * 360, -30, 0));

        // Resetowanie czasu
        if (time >= 1)
            time = 0;
    }
}
