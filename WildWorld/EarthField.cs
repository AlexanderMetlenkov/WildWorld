using System;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WildWorld
{
    class EarthField : Field
    {
        public int width, height;
        public List<UnmovableEO> objects = new List<UnmovableEO>();
        public List<Animal> animals = new List<Animal>();
        public List<WaterField> waterFields = new List<WaterField>();
        public Dictionary<string, Bitmap> imagesOfObjects = new Dictionary<string, Bitmap>();

        override public bool isPointIn(PointF point)
        {
            return (point.X > 0 && point.X < width && point.Y > 0 && point.Y < height);
        }

        public EarthField(Logger log, string name, Point[] points) : base(log, name, points)
        {
        // filling list of images of objects
            width = 0;
            height = 0;
            foreach (Point point in border)
            {
                if (point.X > width) width = point.X;
                if (point.Y > height) height = point.Y;
            }
            imagesOfObjects.Add("tiger", new Bitmap("tiger.png"));
            imagesOfObjects.Add("dead tiger", new Bitmap("dead tiger.png"));
            imagesOfObjects.Add("wolf", new Bitmap("wolf.png"));
            imagesOfObjects.Add("dead wolf", new Bitmap("dead wolf.png"));
            imagesOfObjects.Add("deer", new Bitmap("deer.png"));
            imagesOfObjects.Add("dead deer", new Bitmap("dead deer.png"));
            imagesOfObjects.Add("boar", new Bitmap("boar.png"));
            imagesOfObjects.Add("dead boar", new Bitmap("dead boar.png"));
            imagesOfObjects.Add("elephant", new Bitmap("elephant.png"));
            imagesOfObjects.Add("dead elephant", new Bitmap("dead elephant.png"));
            imagesOfObjects.Add("fox", new Bitmap("fox.png"));
            imagesOfObjects.Add("dead fox", new Bitmap("dead fox.png"));
            imagesOfObjects.Add("giraffe", new Bitmap("giraffe.png"));
            imagesOfObjects.Add("dead giraffe", new Bitmap("dead giraffe.png"));
            imagesOfObjects.Add("horse", new Bitmap("horse.png"));
            imagesOfObjects.Add("dead horse", new Bitmap("dead horse.png"));
            imagesOfObjects.Add("kangaroo", new Bitmap("kangaroo.png"));
            imagesOfObjects.Add("dead kangaroo", new Bitmap("dead kangaroo.png"));
            imagesOfObjects.Add("lion", new Bitmap("lion.png"));
            imagesOfObjects.Add("dead lion", new Bitmap("dead lion.png"));
            imagesOfObjects.Add("error", new Bitmap("error.png"));
            imagesOfObjects.Add("dead error", new Bitmap("dead error.png"));
            imagesOfObjects.Add("feces", new Bitmap("feces.png"));
            imagesOfObjects.Add("plant", new Bitmap("plant.png"));
            foreach (Bitmap bmp in imagesOfObjects.Values)
                bmp.MakeTransparent();
        }
        
        public void tick()
        {
            for (int i = 0; i < animals.Count; i++)
            {
                if (animals[i].size < animals[i].maxSize)
                    animals[i].size += 0.03;
                animals[i].mind.striveForGoal();
            }
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].name == "plant" && objects[i].size < objects[i].maxSize)
                    objects[i].size += 0.03;
                if (objects[i].name == "feces")
                {
                    ((Feces)objects[i]).countdown--;
                    if (((Feces)objects[i]).countdown == 0)
                    {
                        objects.Add(new UnmovableEO(Logger.getLogger(), "plant", objects[i].size, objects[i].size * 3, objects[i].coords, "plant"));
                        objects.Remove(objects[i]);
                    }
                }
            }
        }
        public Image paint(PictureBox canvas)
        {
            Graphics gr = Graphics.FromImage(canvas.Image);
            gr.Clear(Color.Green);
            for (int i = 0; i < waterFields.Count; i++)
            {
                gr.FillPolygon(Brushes.Aqua, waterFields[i].border);
            }
            for (int i = 0; i < objects.Count; i++)
            {
                if (imagesOfObjects.ContainsKey(objects[i].name))
                    gr.DrawImage(imagesOfObjects[objects[i].name], (float)(objects[i].coords.X - objects[i].size / 2), (float)(objects[i].coords.Y - objects[i].size / 2), (float)(objects[i].size), (float)(objects[i].size));
                else
                    gr.DrawImage(imagesOfObjects["dead error"], (float)(objects[i].coords.X - objects[i].size / 2), (float)(objects[i].coords.Y - objects[i].size / 2), (float)(objects[i].size), (float)(objects[i].size));
            }
            for (int i = 0; i < animals.Count; i++)
            {
                if(imagesOfObjects.ContainsKey(animals[i].name))
                    gr.DrawImage(imagesOfObjects[animals[i].name], (float)(animals[i].coords.X - animals[i].size / 2), (float)(animals[i].coords.Y - animals[i].size / 2), (float)(animals[i].size), (float)(animals[i].size));
                else
                    gr.DrawImage(imagesOfObjects["error"], new RectangleF((float)(animals[i].coords.X - animals[i].size / 2), (float)(animals[i].coords.Y - animals[i].size / 2), (float)(animals[i].size), (float)(animals[i].size)));
                gr.DrawString(animals[i].mind.goal.type, new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular), Brushes.Black, new PointF((float)(animals[i].coords.X - animals[i].size / 2), (float)(animals[i].coords.Y - animals[i].size / 2 - 11)));
            }
            return canvas.Image;
        }
    }
}
