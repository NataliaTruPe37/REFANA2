using UnityEngine;

public class CharacterMoveAndColor : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float moveSpeed = 5f;

    [Header("Configuración de Color")]
    public KeyCode colorKey = KeyCode.C; // Tecla C para cambiar de color

    private Renderer charRenderer;

    void Start()
    {
        // Buscamos el componente que le da color a la figura al iniciar
        charRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // --- PARTE 1: MOVIMIENTO (Igual al de Regina) ---
        float moveX = Input.GetAxis("Horizontal"); 
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0f, moveZ) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);

        // --- PARTE 2: SUPERPODER DE COLOR ---
        // Si presionas la tecla asignada (C por defecto)
        if (Input.GetKeyDown(colorKey))
        {
            if (charRenderer != null)
            {
                // Genera un color al azar y se lo aplica al material
                Color randomColor = new Color(Random.value, Random.value, Random.value);
                charRenderer.material.color = randomColor;
            }
        }
    }
}