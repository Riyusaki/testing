using UnityEngine;
using System.Collections;
using Vuforia;

public class ImageTargetPlaySUB : MonoBehaviour, ITrackableEventHandler
{
    private TrackableBehaviour mTrackableBehaviour;


    void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            // Play audio when target is found
        }
        else
        {
            // Stop audio when target is lost ну вроде все, какой шрифт выбрать и куда этот текст переместить уже тебе решать, а насчет сплешскрина хз это из твоих скриптов, он там ругается на недостаток треков какихто
            // не, все норм, сплеш стал пропадать нормально. Я сейчас деньги тебе переведу. Если у меня возникнут вопросы при переносе, я тебе в вк напишу, ок?
       //     ок сек жду
           
        }


    }
}

