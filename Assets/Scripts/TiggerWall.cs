using UnityEngine;

public class TiggerWall : MonoBehaviour
{
    public GameObject roadSection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerWall"))
        {
            Instantiate(roadSection, new Vector3(-0.200000003f, -224.220001f, 261.019989f), Quaternion.identity);
        }
    }
}
