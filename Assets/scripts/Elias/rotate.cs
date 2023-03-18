using UnityEngine;

public class rotate : MonoBehaviour
{

    // Reference til din spiller
    [SerializeField]
    private GameObject _player;


    private void FixedUpdate()
    {
        // Find forskellen mellem hvor din mus er (lavet om til worldpoint) og denne placering. 
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        // Normalis�r (f� kun en retningsvektor)
        difference.Normalize();

        // Brug Atan2 til at bruge retningsvektors x og y til at f� resultatet i grader
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        //S�t graderne p� Z aksen.
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        //Her tjekker vi om rotationenen er komme over / under 90/-90 for at s�rge for at 
        if (rotationZ < -90 || rotationZ > 90)
        {
            if (_player.transform.eulerAngles.y == 0)
            {
                transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }
            else if (_player.transform.eulerAngles.y == 180)
            {
                transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }
        }

    }
}