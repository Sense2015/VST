using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace VoiceSymbol
{
    
    class MediaPlayerThree
    {
        public static void play(string p)
        {
            MediaPlayer player = new MediaPlayer();
            player.Open(new Uri(p, UriKind.Relative));
            Console.WriteLine("撥放開始:" + p);
            player.Play();
            player.MediaEnded += new EventHandler(player_MediaEnded);
        }
        public static void player_MediaEnded(object sender, EventArgs e)
        {
            Console.WriteLine("撥放完畢:" + Global.path);
            Console.WriteLine("index:" + Global.index);
            if (Global.index >= 9 || Global.content[Global.index] == null)
            {
                Global.index = 1;
                Console.WriteLine("index=1");
                return;
            }

            Global.path = @"C:\Sense2015\VoiceSymbol\VoiceSymbol\Sounds\" + Global.content[Global.index] + ".mp3";
            Global.index++;
            //player.MediaEnded -= new EventHandler(player_MediaEnded);
            play(Global.path);
        }
    }
}
