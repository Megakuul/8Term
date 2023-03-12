using System.Text;
using _8Term.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace _8Term.Config
{
    public static class JsonInterface
    {
        public static JObject deserializeJsonConfig(string configFilePath)
        {
            //Use the default file from RESX if there is no valid config file
            if (!File.Exists(configFilePath))
            {
                return JObject.Parse(Encoding.UTF8.GetString(Resources.conf));
            }
            //Deserialize JSON file
            using (StreamReader sr = new StreamReader(configFilePath))
            {
                //Init JSON variables
                string json = sr.ReadToEnd();
                return JObject.Parse(json);
            }
        }

        public static bool serializeJsonConfig(string configFilePath, JObject Jconfig)
        {
            if (!File.Exists(configFilePath))
            {
                try
                {
                    File.Create(configFilePath).Dispose();
                } catch
                {
                    return false;
                }
            }
            try
            {
                File.WriteAllText(configFilePath, JsonConvert.SerializeObject(Jconfig));
            }
            catch (Exception ex)
            {
                MessageBox.Show("cannot write to conf.eterm file \r\n\r\nError:\r\n" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
