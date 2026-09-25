using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject canvasMenu;

    public void SelectCharacter(GameObject characterPrefab)
    {
        if (characterPrefab == null) return;

        Vector3 spawnPos = spawnPoint != null ? spawnPoint.position : new Vector3(0, 1, 0);
        GameObject player = Instantiate(characterPrefab, spawnPos, Quaternion.identity);

        if (player.GetComponent<PlayerMovement>() == null)
            player.AddComponent<PlayerMovement>();

        Camera mainCam = Camera.main;
        if (mainCam != null)
        {
            CameraFollow followScript = mainCam.GetComponent<CameraFollow>();
            if (followScript == null)
                followScript = mainCam.gameObject.AddComponent<CameraFollow>();

            followScript.SetTarget(player.transform);
        }

        if (canvasMenu != null)
            canvasMenu.SetActive(false);
    }
}