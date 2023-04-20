using SevenZipExtractor;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace MinecraftLauncherBackendByAeris
{
    internal class Program
    {
        static string[] Links = { "" };
        static string MinecraftCachePath = "Cache\\MinecraftBase.zip";
        static string ModsCachePath = "Cache\\Mods\\mods.zip";
        static string Git_GetLinks = @"https://raw.githubusercontent.com/maksgranko/Inda2Client/additional/links";
        static string MinecraftPath = "MinecraftGame\\game\\";

        static (ushort,ushort) resolution = (1280, 720);
        static (ushort, ushort) Memory = (512, 4096);

        static string Username = "_Katoshi_";
        static string UUID = "e76bb5cb25ad3e6ba102e6422bace27b";
        static string assetsDir = $"{Environment.CurrentDirectory}\\{MinecraftPath}assets";
        static string gameDir = $"{Environment.CurrentDirectory}\\MinecraftGame\\game";
        static string Argsm = $"-XX:+UnlockExperimentalVMOptions -XX:+UseG1GC -XX:G1NewSizePercent=20 -XX:G1ReservePercent=20 -XX:MaxGCPauseMillis=50 -XX:G1HeapRegionSize=32M -XX:+DisableExplicitGC -XX:+AlwaysPreTouch -XX:+ParallelRefProcEnabled";

        static void Main(string[] args)
        {
            //onStartSettings();
            //DownloadMinecraft(true);
            //DownloadModifications();
            // Thread.Sleep(9999);
            if (StartMinecraft() == false)
            {
                Console.WriteLine("Произошла ошибка при работе Minecraft.");
            }
            
        }
        static bool StartMinecraft()
        {
            if (!Argsm.ToLower().Contains("-xmx"))
            {
                Argsm += $" -Xmx{Memory.Item2}M";
            }
            if (!Argsm.ToLower().Contains("-xms"))
            {
                Argsm += $" -Xms{Memory.Item1}M";
            }
            Process Minecraft = new Process();
            Minecraft.StartInfo.UseShellExecute = false;
            Minecraft.StartInfo.RedirectStandardOutput = true;
            Minecraft.StartInfo.FileName = $"{Environment.CurrentDirectory}\\MinecraftGame\\jre\\jre-legacy\\windows-x64\\jre-legacy\\bin\\java.exe";
            Minecraft.StartInfo.Arguments = $"{Argsm} " +
                $"-Dfile.encoding=UTF-8 " +
                $"-Dfml.ignoreInvalidMinecraftCertificates=true " +
                $"-Dfml.ignorePatchDiscrepancies=true " +
                $"-Djava.net.useSystemProxies=true " +
                $"-XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump " +
                $"-Dos.version=10.0 \"" +
                $"-Djava.library.path={Environment.CurrentDirectory}\\{MinecraftPath}versions\\Forge 1.12.2\\natives\" " +
                $"\"" +
                $"-Dminecraft.client.jar={Environment.CurrentDirectory}\\{MinecraftPath}versions\\Forge 1.12.2\\Forge 1.12.2.jar\" " +
                $"-cp \"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\com\\turikhay\\ca-fixer\\1.0\\ca-fixer-1.0.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\net\\minecraftforge\\forge\\1.12.2-14.23.5.2860\\forge-1.12.2-14.23.5.2860.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\ow2\\asm\\asm-debug-all\\5.2\\asm-debug-all-5.2.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\net\\minecraft\\launchwrapper\\1.12\\launchwrapper-1.12.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\jline\\jline\\3.5.1\\jline-3.5.1.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\com\\typesafe\\akka\\akka-actor_2.11\\2.3.3\\akka-actor_2.11-2.3.3.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\com\\typesafe\\config\\1.2.1\\config-1.2.1.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\scala-lang\\scala-actors-migration_2.11\\1.1.0\\scala-actors-migration_2.11-1.1.0.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\scala-lang\\scala-compiler\\2.11.1\\scala-compiler-2.11.1.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\scala-lang\\plugins\\scala-continuations-library_2.11\\1.0.2_mc\\scala-continuations-library_2.11-1.0.2_mc.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\scala-lang\\plugins\\scala-continuations-plugin_2.11.1\\1.0.2_mc\\scala-continuations-plugin_2.11.1-1.0.2_mc.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\scala-lang\\scala-library\\2.11.1\\scala-library-2.11.1.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\scala-lang\\scala-parser-combinators_2.11\\1.0.1\\scala-parser-combinators_2.11-1.0.1.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\scala-lang\\scala-reflect\\2.11.1\\scala-reflect-2.11.1.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\scala-lang\\scala-swing_2.11\\1.0.1\\scala-swing_2.11-1.0.1.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\scala-lang\\scala-xml_2.11\\1.0.2\\scala-xml_2.11-1.0.2.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\lzma\\lzma\\0.0.1\\lzma-0.0.1.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\java3d\\vecmath\\1.5.2\\vecmath-1.5.2.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\net\\sf\\trove4j\\trove4j\\3.0.3\\trove4j-3.0.3.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\apache\\maven\\maven-artifact\\3.5.3\\maven-artifact-3.5.3.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\net\\sf\\jopt-simple\\jopt-simple\\5.0.3\\jopt-simple-5.0.3.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\apache\\logging\\log4j\\log4j-api\\2.15.0\\log4j-api-2.15.0.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\apache\\logging\\log4j\\log4j-core\\2.15.0\\log4j-core-2.15.0.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\ru\\tlauncher\\patchy\\1.0.0\\patchy-1.0.0.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\oshi-project\\oshi-core\\1.1\\oshi-core-1.1.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\net\\java\\dev\\jna\\jna\\4.4.0\\jna-4.4.0.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\net\\java\\dev\\jna\\platform\\3.4.0\\platform-3.4.0.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\com\\ibm\\icu\\icu4j-core-mojang\\51.2\\icu4j-core-mojang-51.2.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\com\\paulscode\\codecjorbis\\20101023\\codecjorbis-20101023.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\com\\paulscode\\codecwav\\20101023\\codecwav-20101023.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\com\\paulscode\\libraryjavasound\\20101123\\libraryjavasound-20101123.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\com\\paulscode\\librarylwjglopenal\\20100824\\librarylwjglopenal-20100824.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\com\\paulscode\\soundsystem\\20120107\\soundsystem-20120107.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\io\\netty\\netty-all\\4.1.9.Final\\netty-all-4.1.9.Final.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\com\\google\\guava\\guava\\21.0\\guava-21.0.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\apache\\commons\\commons-lang3\\3.5\\commons-lang3-3.5.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\commons-io\\commons-io\\2.5\\commons-io-2.5.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\commons-codec\\commons-codec\\1.10\\commons-codec-1.10.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\net\\java\\jinput\\jinput\\2.0.5\\jinput-2.0.5.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\net\\java\\jutils\\jutils\\1.0.0\\jutils-1.0.0.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\com\\google\\code\\gson\\gson\\2.8.0\\gson-2.8.0.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\by\\ely\\authlib\\3.11.49.2\\authlib-3.11.49.2.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\com\\mojang\\realms\\1.10.22\\realms-1.10.22.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\apache\\commons\\commons-compress\\1.8.1\\commons-compress-1.8.1.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\apache\\httpcomponents\\httpclient\\4.3.3\\httpclient-4.3.3.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\commons-logging\\commons-logging\\1.1.3\\commons-logging-1.1.3.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\apache\\httpcomponents\\httpcore\\4.3.2\\httpcore-4.3.2.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\it\\unimi\\dsi\\fastutil\\7.1.0\\fastutil-7.1.0.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\apache\\logging\\log4j\\log4j-api\\2.8.1\\log4j-api-2.8.1.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\apache\\logging\\log4j\\log4j-core\\2.8.1\\log4j-core-2.8.1.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\lwjgl\\lwjgl\\lwjgl\\2.9.4-nightly-20150209\\lwjgl-2.9.4-nightly-20150209.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\org\\lwjgl\\lwjgl\\lwjgl_util\\2.9.4-nightly-20150209\\lwjgl_util-2.9.4-nightly-20150209.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}libraries\\com\\mojang\\text2speech\\1.10.3\\text2speech-1.10.3.jar;" +
                $"{Environment.CurrentDirectory}\\{MinecraftPath}versions\\Forge 1.12.2\\Forge 1.12.2.jar\" net.minecraft.launchwrapper.Launch " +
                $"--username {Username} --version \"Forge 1.12.2\" " +
                $"--gameDir \"{gameDir}\" " +
                $"--assetsDir \"{assetsDir}\" " +
                $"--assetIndex 1.12 --uuid {UUID} --accessToken null " +
                $"--userType legacy --tweakClass net.minecraftforge.fml.common.launcher.FMLTweaker --versionType Forge --width {resolution.Item1} --height {resolution.Item2}\"";
            try { Minecraft.Start(); }
            catch { return false; }
            while (!Minecraft.StandardOutput.EndOfStream)
            {
                Console.WriteLine(Minecraft.StandardOutput.ReadLine());
            }
            Thread.Sleep(99999);
            return true;
        }
        

        static string RequestInfo(string sendingdata, string HTTPRequest, ushort timeoutms = 30000, bool POST = false, bool isJSON = false)
        {
            string getResponse = "null";
            ushort attempt = 0;

            while (attempt < 10)
            {
                try
                {
                    attempt++;
                    if (string.IsNullOrEmpty(HTTPRequest))
                    {
                        Console.WriteLine("Bad Request.");
                        break;
                    }

                    WebRequest request = WebRequest.Create(HTTPRequest);
                    request.Timeout = timeoutms;

                    if (POST == true)
                    {
                        request.Method = "POST";
                        byte[] data = Encoding.GetEncoding(1251).GetBytes(sendingdata);
                        request.ContentLength = data.Length;

                        if (isJSON)
                        {
                            request.ContentType = "application/json";
                        }
                        else
                        {
                            request.ContentType = "text/html";
                        }

                        using (Stream postStream = request.GetRequestStream())
                        {
                            postStream.Write(data, 0, data.Length);
                        }
                    }
                    else
                    {
                        request.Method = "GET";
                    }

                    using (WebResponse response = request.GetResponse())
                    {
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                getResponse = reader.ReadToEnd();
                            }
                        }
                    }

                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Thread.Sleep(500);
                }
            }

            return getResponse;
        }
        static void onStartSettings()
        {
            Process[] processlist = Process.GetProcessesByName(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
            ushort g = 0;
            foreach (Process process in processlist)
            {
                g++;
                if (g >= 2)
                {
                    Environment.Exit(2);
                }
            }
            Environment.CurrentDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            while (Links[0].Length < 10)
            {
                Console.WriteLine("Getting links for download...");
                Links = RequestInfo("", Git_GetLinks, 15000, false, false).Split('|');
            }

        }
        static bool DownloadMinecraft(bool DeleteCache)
        {
            if (!Directory.Exists("Cache")) Directory.CreateDirectory("Cache");
            if (!File.Exists(MinecraftCachePath))
            {
                for (int i = 0; i <= 5; i++)
                {
                    if (i == 5)
                    {
                        Console.WriteLine("Minecraft can't be downloaded.");
                        return false;
                    }
                    using (var client = new WebClient())
                    {
                        try
                        {
                            Console.WriteLine(i + 1 + " attempt to download MinecraftGame.");
                            client.DownloadFile(Links[0], MinecraftCachePath);
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error when trying to download MinecraftGame.");
                            Console.WriteLine(e.Message);
                            Thread.Sleep(3000);
                        }
                    }
                }
            }
            using (ArchiveFile archiveFile = new ArchiveFile(MinecraftCachePath))
            {
                if (!Directory.Exists("Temp")) Directory.CreateDirectory("Temp");
                archiveFile.Extract("Temp"); 
                if (Directory.Exists(Environment.CurrentDirectory + "\\MinecraftGame")) Directory.Delete(Environment.CurrentDirectory + "\\MinecraftGame", true);
                foreach (string dir in Directory.GetDirectories("Temp"))
                {
                    Directory.Move(dir, Environment.CurrentDirectory + "\\MinecraftGame");
                }
            }
            return true;
        }
        static bool DownloadModifications()
        {

            if (!Directory.Exists("Cache\\Mods\\")) Directory.CreateDirectory("Cache\\Mods\\");
            if (!Directory.Exists("Temp")) Directory.CreateDirectory("Temp");
            for (int i = 0; i <= 5; i++)
            {
                if (i == 5)
                {
                    Console.WriteLine("Mods can't be downloaded.");
                    return false;
                }
                using (var client = new WebClient())
                {
                    try
                    {
                        Console.WriteLine(i + 1 + " attempt to download Mods.");
                        client.DownloadFile(Links[1], ModsCachePath);
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error when trying to download Mods.");
                        Console.WriteLine(e.Message);
                        Thread.Sleep(3000);
                    }
                }
            }

            using (ArchiveFile archiveFile = new ArchiveFile(ModsCachePath))
            {
                if (!Directory.Exists("Temp")) Directory.CreateDirectory("Temp");
                archiveFile.Extract("Temp");
                foreach (string dira in Directory.GetDirectories("Temp"))
                {
                    foreach (string dirb in Directory.GetDirectories(dira))
                    {
                        string[] dirba = dirb.Split('\\');
                        if (!Directory.Exists(Environment.CurrentDirectory + "\\MinecraftGame")) DownloadMinecraft(false);
                        Directory.Move(dirb, Environment.CurrentDirectory + "\\MinecraftGame\\" + dirba[dirba.Length-1]);
                    }
                }
            }
            return true;
        }

    }
}