using UnityEngine;
using OscJack;

public class ClientExample : MonoBehaviour
{

    OscClient client = new OscClient("192.168.10.18", 9000);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Send");
            client.Send("/unity", "ok");
        }
    }

    private void OnDestroy()
    {
        client.Dispose();
    }
}