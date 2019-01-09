using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace advancedMemewareDownloader
{
    class Program
    {
        static int browserTest()
        {
            // This allows us to find the users Local App directory, a home for a lot of google apps
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            var chromeTestSystem = File.Exists(@"C:\Program Files (x86)\Google\Chrome\Applications\chrome.exe)");
            var chromeTestUser = File.Exists(appdata + @"\Google\Chrome\Application\chrome.exe");
            var chromeCanary = File.Exists(appdata + @"\Google\Chrome SxS\Application\chrome.exe");
            var chromium = File.Exists(appdata + @"\Google\Chrome SxS\Application\chromium.exe");
            var firefoxTest = File.Exists(@"C:\Program Files\Mozilla Firefox\firefox.exe");
            var firefoxTestx86 = File.Exists(@"C:\Program Files (x86)\Mozilla Firefox\firefox.exe");
            if (chromeTestSystem == true)
            {
                return 0;
            }
            else if (chromeTestUser == true)
            {
                return 0;
            }
            else if (chromeCanary == true)
            {
                return 0;
            }
            else if (chromium == true)
            {
                return 1;
            }
            else if (firefoxTest == true)
            {
                return 2;        
            }
            else if (firefoxTestx86 == true)
            {
                return 2;
            }
            else
            {
                return 6;
            }
        }
        static void Main(string[] args)
        {
            // This is the URL That will be opened by a browser
            string url = "\"https://www.youtube.com/embed/G1IbRujko-A?=rel=0&amp;autoplay=1;fs=0;autohide=0;hd=0;";
            Console.WriteLine(url);

            // This will set a variable to "browser" from the return of "browserTest" which tests which browser is in use
            var browser = browserTest();

            // ChromeSystemVersion | ChromeUserVersion | ChromeCanary in Kiosk Mode
            if (browser == 0)
            {
                Process.Start("chrome.exe", "--kiosk " + url);
            }

            // Chromium version in Kiosk Mode
            else if (browser == 1)
            {
                Process.Start("chromium.exe", "--kiosk " + url);
            }

            // Firefox which does not have a Kiosk mode
            else if (browser == 2)
            {
                Process.Start("firefox.exe", "--new- window --position=0,0 --start-fullscreen -url=" + url);
            }

            //Final, opens internet explorer, which has kiosk mode weirdly (this only works if the command line arg is parsed first before the url, needs fix)
            else
            {
                Process.Start("iexplore.exe", "-k " + url);
            }
        }
    }
}
