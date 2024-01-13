using UnityEngine;

public class Menu_Anim : MonoBehaviour
{
    public float transitionSpeed = 1.0f; // Szybko�� przesuni�cia kamery
    public float transitionDistance = 5.0f; // Odleg�o�� do przesuni�cia w jednostkach

    private Vector3 targetPosition; // Docelowa pozycja kamery

    void Start()
    {
        // Oblicz docelow� pozycj� kamery
        targetPosition = transform.position + new Vector3(0, transitionDistance, 0);
    }

    void Update()
    {
        // Przesuwaj kamer� w kierunku docelowej pozycji z u�yciem interpolacji liniowej
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
    }
}
