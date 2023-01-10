using System.Text;
using _8Term.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace _8Term.Config
{
    public static class JsonInterface
    {
        public static JObject deserializeJsonConfig(string configFile)
        {
            //Use the default file from RESX if there is no valid config file
            if (!File.Exists(configFile))
            {
                return JObject.Parse(Encoding.UTF8.GetString(Resources.conf));
            }
            //Deserialize JSON file
            using (StreamReader sr = new StreamReader(configFile))
            {
                //Init JSON variables
                string json = sr.ReadToEnd();
                return JObject.Parse(json);
            }
        }

        public static bool serializeJsonConfig(string configFile, JObject Jconfig)
        {
            if (!File.Exists(configFile))
            {
                try
                {
                    File.Create(configFile).Dispose();
                } catch
                {
                    return false;
                }
            }
            try
            {
                File.WriteAllText(configFile, JsonConvert.SerializeObject(Jconfig));
            }
            catch (Exception ex)
            {
                MessageBox.Show("cannot write to config.json file \r\n\r\nError:\r\n" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
