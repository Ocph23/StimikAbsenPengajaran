
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Support.V4.App;
using Android.Widget;
using System;
using Xamarin.Essentials;

namespace MobileApp.Droid
{
    [BroadcastReceiver]
    public class AlarmReciever : BroadcastReceiver
    {
        [Obsolete]
        public override void OnReceive(Context context, Intent intent)
        {
            try
            {
                Android.Net.Uri alert = RingtoneManager.GetDefaultUri(RingtoneType.Alarm);
                alert = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
                alert = RingtoneManager.GetDefaultUri(RingtoneType.Ringtone);

                // Toast.MakeText(context, "Received intent!", ToastLength.Long).Show();
                var matakuliah = intent.GetStringExtra("matakuliah") + "Saatnya Mengisi Berita Acara";
                var waktu = intent.GetStringExtra("waktu");
                var jadwalId = Convert.ToInt32(intent.GetStringExtra("jadwalId"));
                Android.Net.Uri soundUri = Android.Net.Uri.Parse("android.resource://" + "com.ocph23.absenpembelajaran" + "/raw/alarm");

                if (Build.VERSION.SdkInt < BuildVersionCodes.O)
                {
                    intent.AddFlags(ActivityFlags.ClearTop);
                    var pendingIntent = PendingIntent.GetActivity(context, 0, intent, PendingIntentFlags.OneShot);
                    var notificationBuilder = new Notification.Builder(context)
                                .SetContentTitle(waktu)
                                .SetSmallIcon(Resource.Drawable.Logostimik)
                                .SetContentText(matakuliah)
                                .SetAutoCancel(true)
                                   .SetSound(soundUri)
                                .SetContentIntent(pendingIntent)
                                .SetPriority((int)Notification.PriorityHigh);
                    var notificationManager = NotificationManager.FromContext(context);
                    notificationManager.Notify(jadwalId, notificationBuilder.Build());
                }
                else
                {
                    intent.AddFlags(ActivityFlags.MultipleTask);
                    var pendingIntent = PendingIntent.GetActivity(context, jadwalId, intent, PendingIntentFlags.OneShot);
                    var notificationBuilder = new Android.App.Notification.Builder(context)
                        .SetAutoCancel(true)
                                .SetContentTitle(waktu)
                                .SetSmallIcon(Resource.Drawable.Logostimik)
                                .SetContentText(matakuliah)
                                .SetAutoCancel(true)
                                   .SetSound(soundUri)
                                   .SetVibrate(new long[] { 1000, 1000, 1000 })
                                .SetContentIntent(pendingIntent)
                                .SetChannelId(jadwalId.ToString())
                                .SetPriority((int)Notification.PriorityMax);


                    notificationBuilder.SetSound(Android.Net.Uri.Parse("android.resource://" + context.PackageName + "/" + Resource.Raw.alarm1));//Here is FILE_NAME is the name of file that you want to play


                    var channel = new NotificationChannel(jadwalId.ToString(), matakuliah, NotificationImportance.High)
                    {
                        Description = waktu
                    };
              
                    var notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
                    notificationManager.CreateNotificationChannel(channel);
                    MediaPlayer mp = MediaPlayer.Create(context, Resource.Raw.alarm1);
                    if(!mp.IsPlaying)
                        mp.Start();
                    notificationManager.Notify(jadwalId, notificationBuilder.Build());
                }
            }
            catch (Exception)
            {

//                throw;
            }
        }
       
    }
}