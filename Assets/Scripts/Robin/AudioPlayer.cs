using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    public enum AudioResource
    {
        NULL,
        EquipMask,
        Interact
    }
    public AudioResource AudioPlayerResource;

    [SerializeField] private AudioClip equipMask;
    [SerializeField] private AudioClip interact;

    private AudioSource aPlayer;

    private bool AudioPlayed;

    private float DestructionTimer = 3;


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        aPlayer = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (AudioPlayerResource == AudioResource.NULL)
        {
            DestructionTimer = DestructionTimer - Time.deltaTime;

            if (DestructionTimer < 0)
            {
                Debug.Log("NullAudio, cannot play");
                Destroy(gameObject);
            }
        }
        else
        {
            //Select the clip
            if (AudioPlayerResource == AudioResource.EquipMask)
            {
                aPlayer.clip = equipMask;
            }
            else if (AudioPlayerResource == AudioResource.Interact)
            {
                aPlayer.clip = interact;
            }
        }

        if (!AudioPlayed & !aPlayer.isPlaying)
        {
            aPlayer.Play();
        }
        else if (aPlayer.isPlaying)
        {
            AudioPlayed = true;
        }
        else if (AudioPlayed & !aPlayer.isPlaying)
        {
            //if audio has played, and has now stopped, destroy the player
            Destroy(this.gameObject);
        }
    }
}
