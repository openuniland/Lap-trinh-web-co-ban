using System.IO;
using System.Text;

namespace BtlWebForm.Repository
{
    public class FileIO : System.Web.UI.Page
    {
        public string ReadFileJson(string file)
        {
            try 
            {
                FileStream f = new FileStream(Server.MapPath(file), FileMode.Open);
                StreamReader rd = new StreamReader(f, Encoding.UTF8);
                string value = rd.ReadToEnd();
                rd.Close();
                f.Close();
                return value;
            }
            catch (IOException e)
            {
                // not found file or file empty
                return null;
            }
        }

        public bool WriteFileJson(string file, string value)
        {
            try
            {
                System.IO.File.WriteAllText(Server.MapPath(file), value);
                return true;
            }
            catch (IOException e)
            {
                return false;
            }
            
        }
    }
}