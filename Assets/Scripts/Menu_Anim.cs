using UnityEngine;

public class Menu_Anim : MonoBehaviour
{
    public float transitionSpeed = 1.0f; // Szybkoœæ przesuniêcia kamery
    public float transitionDistance = 5.0f; // Odleg³oœæ do przesuniêcia w jednostkach

    private Vector3 targetPosition; // Docelowa pozycja kamery

    void Start()
    {
        // Oblicz docelow¹ pozycjê kamery
        targetPosition = transform.position + new Vector3(0, transitionDistance, 0);
    }

    void Update()
    {
        // Przesuwaj kamerê w kierunku docelowej pozycji z u¿yciem interpolacji liniowej
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * transitionSpeed);
    }
}
