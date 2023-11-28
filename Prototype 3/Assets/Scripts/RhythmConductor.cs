using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmConductor : MonoBehaviour
{
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float songBpm;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    public NewSpawner spawner;

    bool hasSpawned = false;
    float timeSinceLastSpawn;

    void Start()
    {
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();
        if (musicSource == null)
        {
            Debug.LogError("No AudioSource found on the GameObject.");
            // Handle the error, maybe disable the script or provide a default AudioSource.
        }

        //Calculate the number of seconds in each beat
        secPerBeat = songBpm/ 60f;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;
        

        //Start the music
        musicSource.Play();
    }

    void Update()
    {
       // Debug.Log("Update method called");
        UpdateSpawningLogic();
    }

    public void UpdateSpawningLogic()
    {
       // Debug.Log("UpdateSpawningLogic method called");
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        songPositionInBeats = songPosition / secPerBeat;
        // Debug.Log("Current Song Position in beats: " + songPositionInBeats/secPerBeat);

        // Check if it's time to spawn a new enemy
        if ((((int)songPosition / (int)secPerBeat) % 2 == 0) && !hasSpawned && timeSinceLastSpawn >= secPerBeat)
        {
            spawner.SpawnEnemyPair();
            hasSpawned = true;  // Set the flag to indicate that spawning has occurred
            timeSinceLastSpawn = 0f;  // Reset the timer
            Debug.Log("Spawned Enemy Pair at Beat: " + songPositionInBeats);
        }

        // Update the timer
        timeSinceLastSpawn += Time.deltaTime;

        // Check if the time since last spawn exceeds secPerBeat
        if (hasSpawned && timeSinceLastSpawn >= secPerBeat)
        {
            hasSpawned = false;  // Reset the flag for the next spawn cycle
        }
    }
}