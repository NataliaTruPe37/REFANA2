using UnityEngine;

public class CharacterMoveAndSpin : MonoBehaviour
{
    [Header("Configuración de Movimiento")]
    public float moveSpeed = 5f;

    [Header("Configuración de Giro (Spin)")]
    public float spinSpeed = 360f; // Grados por segundo
    public KeyCode spinKey = KeyCode.R;

    private bool isSpinning = false;

    void Update()
    {
        //WASD
        float moveX = Input.GetAxis("Horizontal"); 
        float moveZ = Input.GetAxis("Vertical");


        Vector3 move = new Vector3(moveX, 0f, moveZ) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.World);

        //spinning
        if (Input.GetKeyDown(spinKey))
        {
            isSpinning = !isSpinning;
        }

       
        if (isSpinning)
        {
        
            transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
        }
    }
}