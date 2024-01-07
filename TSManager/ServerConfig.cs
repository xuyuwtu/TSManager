using System.IO;

namespace GameLauncher
{
    public class ServerConfig
    {
        public string world = string.Empty;
        public CultureName lang = CultureName.English;
        public int maxPlayer = 8;
        public ushort port = 7777;
        public string ip = "0.0.0.0";
        public string password = string.Empty;
        public string[] parameters = Array.Empty<string>();
        public string[] plugins = Array.Empty<string>();
        public enum CultureName
        {
            English = 1,
            German,
            Italian,
            French,
            Spanish,
            Russian,
            Chinese,
            Portuguese,
            Polish
        }

        public string[] CreateArgs(string worldDir)
        {
            var result = new List<string>
            {
                "-ip",
                ip,
                "-port",
                port.ToString(),
                "-lang",
                ((int)lang).ToString(),
                "-maxplayer",
                maxPlayer.ToString()
            };
            if (!string.IsNullOrEmpty(world))
            {
                result.Add("-world");
                result.Add($"{Path.Combine(worldDir, world)}.wld");
            }
            if (!string.IsNullOrEmpty(password))
            {
                result.Add("-pass");
                result.Add(password);
            }
            result.AddRange(parameters);
            return result.ToArray();
        }
    }
}