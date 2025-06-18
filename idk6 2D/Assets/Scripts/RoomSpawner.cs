using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    private RoomTemplates roomTemplates;

    [SerializeField][Range(1, 4)] private int openingDirection;

    private bool spawned = false;
    private int rand;

    private void Start()
    {
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        Invoke("Spawn", .1f);
    }

    void Spawn()
    {
        rand = Random.Range(0, roomTemplates.bottomRooms.Length);

        if (!spawned)
        {
            switch (openingDirection)
            {
                case 1:
                    rand = Random.Range(0, roomTemplates.bottomRooms.Length);
                    Instantiate(roomTemplates.bottomRooms[rand], transform.position, transform.rotation);
                    break;

                case 2:
                    rand = Random.Range(0, roomTemplates.topRooms.Length);
                    Instantiate(roomTemplates.topRooms[rand], transform.position, transform.rotation);
                    break;

                case 3:
                    rand = Random.Range(0, roomTemplates.leftRooms.Length);
                    Instantiate(roomTemplates.leftRooms[rand], transform.position, transform.rotation);
                    break;

                case 4:
                    rand = Random.Range(0, roomTemplates.rightRooms.Length);
                    Instantiate(roomTemplates.rightRooms[rand], transform.position, transform.rotation);
                    break;
            }

            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }
}
