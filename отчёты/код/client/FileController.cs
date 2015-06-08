using Assets.myScript.interfaceUrl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assets.myScript
{
    public class FileController
    {
#if UNITY_STANDALONE_WIN
        public static string patch = Directory.GetCurrentDirectory() + "/sopg/";
#endif
#if UNITY_ANDROID
        public static string patch = "/sdcard/sopg/";
#endif
        public static bool fileExist(int id) 
        {
            Directory.CreateDirectory(patch);
            var p = patch+id;
            return File.Exists(p);
        }

        public static bool fileEquals(long val, int id) 
        {
            var p = patch + id;
            FileInfo fi = new FileInfo(p);
            return (val == fi.Length);

        }

        public static void fileSave(byte[] pngBytes, int id)
        {
            try
            {
                var p = patch + id;
                // Open file for reading
                if (fileExist(id)) File.Delete(p);
                FileStream _FileStream =
                   new FileStream(p, FileMode.Create, FileAccess.Write);
                // Writes a block of bytes to this stream using data from
                // a byte array.
                _FileStream.Write(pngBytes, 0, pngBytes.Length);

                // close file stream
                _FileStream.Close();
            }
            catch (Exception _Exception)
            {

            }
        }
        public static byte[] fileLoad(int id)
        {
            var p = patch + id;
            return File.ReadAllBytes(p);
        }

        public static byte[] getFile(int id) 
        {
            byte[] pngBytes = null;
            try
            {
                if (fileExist(id))
                {
                    MapsController mc = new MapsController();
                    var val = mc.mapSize(id);
                    if (fileEquals(val, id))
                    {
                        pngBytes = fileLoad(id);
                    }
                    else throw new Exception();
                }
                else throw new Exception();
            }
            catch (Exception e)
            {
                pngBytes = getMap(id);
                fileSave(pngBytes, id);
            }
            return pngBytes;
        }

        private static byte[] getMap(int id)
        {
            MapsController mc = new MapsController();
            return mc.sendMapOUT(id);
        }
    }
}
