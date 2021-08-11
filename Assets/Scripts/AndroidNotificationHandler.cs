using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;

public class AndroidNotificationHandler : MonoBehaviour
{
#if UNITY_ANDROID
    public void ScheduleNotification(DateTime date){
        AndroidNotificationChannel channel = new AndroidNotificationChannel{
            Id = "notification_channel",
            Name = "Channel_1",
            Description = "Energy Notifications",
            Importance = Importance.Default
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
        AndroidNotification n1 = new AndroidNotification{
            Title = "Full Energy!",
            Text = "Your Energy has recharged!, come back to play",
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = date
        };
        AndroidNotificationCenter.SendNotification(n1,"notification_channel");
    }
#endif
}
