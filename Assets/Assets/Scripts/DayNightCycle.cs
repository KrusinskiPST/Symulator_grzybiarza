using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light directionalLight; // Kierunkowe Ÿród³o œwiat³a reprezentuj¹ce s³oñce
    public float dayDuration = 120f; // Czas trwania ca³ego cyklu w sekundach

    private float time;
    private float intensity;

    void Update()
    {
        // Aktualizacja czasu
        time += Time.deltaTime / dayDuration;

        // Obliczanie intensywnoœci œwiat³a w zale¿noœci od pory dnia
        if (time < 0.25f || time > 0.75f)
            intensity = Mathf.Clamp01(1 - Mathf.Abs(0.5f - time) * 4);
        else
            intensity = Mathf.Clamp01((time - 0.25f) * 4);

        // Ustawianie intensywnoœci i k¹ta œwiat³a
        directionalLight.intensity = intensity;
        directionalLight.transform.rotation = Quaternion.Euler(new Vector3((time - 0.5f) * 360, -30, 0));

        // Resetowanie czasu
        if (time >= 1)
            time = 0;
    }
}
