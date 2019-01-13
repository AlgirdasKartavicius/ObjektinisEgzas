using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();

           
        }
    }
    public interface Image
    {
        void ShowImage();
    }
    public class ImageProxy : Image
    {
        string Path = "";
        RealImage RealImage;
        public ImageProxy(string path)
        {
            Path = path;
        }

        public void ShowImage()
        {
            RealImage = new RealImage(Path);
            Console.WriteLine(Path + "showing");
        }
    }
    public class RealImage : Image
    {
        string Path = "";
        public RealImage(string p)
        {
            Path = p;
            Console.WriteLine(p + "loading image");
        }
        public void ShowImage()
        {
            Console.WriteLine(Path + "showing");
        }
    }
}
