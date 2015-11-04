using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Subtitles : MonoBehaviour
{

    public AudioSource audioSource;
    List<string> subtitlesLines = new List<string>();
    List<float> subtitlesTimes = new List<float>();
    List<string> subtitlesLine = new List<string>();

    private string[] fileLines;

    public bool isPause = true;

    private float timeNow = 0;
    private int lineNow = 0;

    public Text textViewer;

    public void StartSubtitles()
    {
        subtitlesLines = new List<string>();
        subtitlesTimes = new List<float>();

        TextAsset subtitlesFile = Resources.Load("Subtitles/" + audioSource.clip.name) as TextAsset;
        fileLines = subtitlesFile.text.Split('\n');
        Debug.Log(fileLines.Length);

        foreach (string line in fileLines)
        {
            if (line.Length > 9)
                subtitlesLines.Add(line);
        }
        Debug.Log(subtitlesLines.Count);

        for (int i = 0; i < subtitlesLines.Count; i++)
        {
            char[] timeCh = subtitlesLines[i].ToCharArray(0, 10);
            float min = float.Parse(timeCh[1].ToString() + timeCh[2].ToString());
            float sec = float.Parse(timeCh[4].ToString() + timeCh[5].ToString() + timeCh[6].ToString() + timeCh[7].ToString());
            min *= 60;
            float time = min + sec;
            subtitlesTimes.Add(time);
            subtitlesLine.Add(subtitlesLines[i].Substring(10));
        }
        timeNow = 0;
        lineNow = 0;
        isPause = false;
    }
    void Start()
    {
        StartSubtitles();
    }

    void Update()
    {
        if (audioSource.isPlaying)
        {
            if (timeNow > audioSource.time)
                StartSubtitles();

            timeNow = audioSource.time;
            if (subtitlesTimes[lineNow] < timeNow)
            {
                if (lineNow < subtitlesLine.Count)
                {
                    textViewer.text = subtitlesLine[lineNow];
                    lineNow += 1;
                }

            }

        }
    }
}