using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WildWorld
{
    public partial class MainForm : Form
    {
        EarthField EF;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            Canvas.Top = 0;
            Canvas.Left = 0;
            Canvas.Width = Width - 16;
            Canvas.Height = Height - 38;
            EF = new EarthField(Logger.getNewLogger("test.txt"), "Main field", new Point[] { new Point(0,0), new Point(Canvas.Width, 0), new Point(Canvas.Width, Canvas.Height), new Point(0, Canvas.Height) });
            Canvas.Image = new Bitmap(Canvas.Width, Canvas.Height);
            Canvas.Image = EF.paint(Canvas);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        // all animals are striving for goal and painting result
            Graphics gr = Graphics.FromImage(Canvas.Image);
            EF.tick();
            Canvas.Image = EF.paint(Canvas);
        }

        private void AddAnimalBtn_Click(object sender, EventArgs e)
        {
            addAnimalPanel.Visible = !addAnimalPanel.Visible;
            addWaterFieldPanel.Visible = false;
            settingsPanel.Visible = false;
        }

        private void addWaterFieldBtn_Click(object sender, EventArgs e)
        {
            addAnimalPanel.Visible = false;
            addWaterFieldPanel.Visible = !addWaterFieldPanel.Visible;
            settingsPanel.Visible = false;
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            addAnimalPanel.Visible = false;
            addWaterFieldPanel.Visible = false;
            settingsPanel.Visible = !settingsPanel.Visible;
        }

        private void addWaterField_Click(object sender, EventArgs e)
        {
            try {
                WaterField waterField = new WaterField(Logger.getLogger(), "Water field", new Point[] { new Point(Convert.ToInt32(x1TB.Text), (string)y1CB.SelectedItem == "top" ? 0 : EF.height), new Point((string)x2CB.SelectedItem == "left" ? 0 : EF.width, Convert.ToInt32(y2TB.Text)) }, EF);
                foreach(Animal animal in EF.animals)
                {
                    if (waterField.isPointIn(animal.coords))
                        throw new Exception();
                }
                EF.waterFields.Add(waterField);
                Canvas.Image = EF.paint(Canvas);
            }
            catch(Exception)
            {
                MessageBox.Show("Wrong coords!");
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
        // starting or stopping imitation
            if (!timer.Enabled) {
                timer.Enabled = true;
                addAnimalBtn.Visible = false;
                addWaterFieldBtn.Visible = false;
                settingsBtn.Visible = false;
                addAnimalPanel.Visible = false;
                addWaterFieldPanel.Visible = false;
                settingsPanel.Visible = false;
                startBtn.Text = "Stop";
            }
            else
            {
                EF.animals.Clear();
                EF.objects.Clear();
                EF.waterFields.Clear();
                addAnimalBtn.Visible = true;
                addWaterFieldBtn.Visible = true;
                settingsBtn.Visible = true;
                timer.Enabled = false;
                startBtn.Text = "Start";
                Canvas.Image = EF.paint(Canvas);
            }
        }

        private void AddAnimal_Click(object sender, EventArgs e)
        {
            try {
                Animal animal = new Animal(Logger.getLogger(), nameTB.Text, Convert.ToInt32(maxSizeTB.Text), Convert.ToInt32(maxSizeTB.Text),
              new PointF((float)Convert.ToDouble(xTB.Text), (float)Convert.ToDouble(yTB.Text)), Convert.ToInt32(hungTB.Text),
              Convert.ToInt32(thirstTB.Text), Convert.ToInt32(libTB.Text), Convert.ToInt32(drowTB.Text),
              Convert.ToDouble(hungIncTB.Text), Convert.ToDouble(thirstIncTB.Text), Convert.ToDouble(libIncTB.Text),
              Convert.ToInt32(walkSpeedTB.Text), Convert.ToInt32(runSpeedTB.Text), ((string)sexCB.SelectedItem)[0], EF, (string)mindTypeCB.SelectedItem);
                if (animal.coords.X <= 0 || animal.coords.X >= EF.width ||
                    animal.coords.Y <= 0 || animal.coords.Y >= EF.height ||
                    animal.drowsiness < 0 || animal.hunger < 0 ||
                    animal.hungerInc < 0 || animal.libido < 0 ||
                    animal.libidoInc < 0 || animal.maxSize <= 0 ||
                    animal.runningSpeed < 0 || animal.walkingSpeed < 0)
                    throw new Exception("Invalid value in textbox");
                    for (int i = 0; i < EF.waterFields.Count; i++)
                {
                    if (EF.waterFields[0].isPointIn(animal.coords))
                        throw new Exception("Can not place animal in water field");
                }
                EF.animals.Add(animal);
                Canvas.Image = EF.paint(Canvas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            EF.animals.Clear();
            EF.objects.Clear();
            EF.waterFields.Clear();
            Canvas.Image = EF.paint(Canvas);
        }

        private void standartBtn_Click(object sender, EventArgs e)
        {
            EF.animals.Clear();
            EF.objects.Clear();
            EF.waterFields.Clear();

            WaterField waterField = new WaterField(Logger.getLogger(), "Water field", new Point[] { new Point(0, 50), new Point(50, 0) }, EF);
            EF.waterFields.Add(waterField);
            waterField = new WaterField(Logger.getLogger(), "Water field", new Point[] { new Point(50, EF.height), new Point(0, EF.height - 50) }, EF);
            EF.waterFields.Add(waterField);
            waterField = new WaterField(Logger.getLogger(), "Water field", new Point[] { new Point(700, EF.height), new Point(EF.width, 200) }, EF);
            EF.waterFields.Add(waterField);
            Animal mAnimal = new Animal(Logger.getLogger(), "deer", 50, 50, new Point(EF.width - 50, 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'm', EF, "herbivorous");
            EF.animals.Add(mAnimal);
            Animal fAnimal = new Animal(Logger.getLogger(), "deer", 40, 40, new Point(50, EF.height - 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'f', EF, "herbivorous");
            EF.animals.Add(fAnimal);
            mAnimal = new Animal(Logger.getLogger(), "lion", 50, 50, new Point(EF.width - 50, 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'm', EF, "carnivore");
            EF.animals.Add(mAnimal);
            fAnimal = new Animal(Logger.getLogger(), "lion", 40, 40, new Point(50, EF.height - 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'f', EF, "carnivore");
            EF.animals.Add(fAnimal);
            mAnimal = new Animal(Logger.getLogger(), "boar", 50, 50, new Point(EF.width - 50, 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'm', EF, "herbivorous");
            EF.animals.Add(mAnimal);
            fAnimal = new Animal(Logger.getLogger(), "boar", 40, 40, new Point(50, EF.height - 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'f', EF, "herbivorous");
            EF.animals.Add(fAnimal);
            mAnimal = new Animal(Logger.getLogger(), "fox", 50, 50, new Point(EF.width - 50, 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'm', EF, "carnivore");
            EF.animals.Add(mAnimal);
            fAnimal = new Animal(Logger.getLogger(), "fox", 40, 40, new Point(50, EF.height - 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'f', EF, "carnivore");
            EF.animals.Add(fAnimal);
            mAnimal = new Animal(Logger.getLogger(), "wolf", 50, 50, new Point(EF.width - 50, 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'm', EF, "carnivore");
            EF.animals.Add(mAnimal);
            fAnimal = new Animal(Logger.getLogger(), "wolf", 40, 40, new Point(50, EF.height - 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'f', EF, "carnivore");
            EF.animals.Add(fAnimal);
            mAnimal = new Animal(Logger.getLogger(), "tiger", 50, 50, new Point(EF.width - 50, 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'm', EF, "carnivore");
            EF.animals.Add(mAnimal);
            fAnimal = new Animal(Logger.getLogger(), "tiger", 40, 40, new Point(50, EF.height - 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'f', EF, "carnivore");
            EF.animals.Add(fAnimal);
            mAnimal = new Animal(Logger.getLogger(), "horse", 50, 50, new Point(EF.width - 50, 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'm', EF, "herbivorous");
            EF.animals.Add(mAnimal);
            fAnimal = new Animal(Logger.getLogger(), "horse", 40, 40, new Point(50, EF.height - 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'f', EF, "herbivorous");
            EF.animals.Add(fAnimal);
            mAnimal = new Animal(Logger.getLogger(), "kangaroo", 50, 50, new Point(EF.width - 50, 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'm', EF, "herbivorous");
            EF.animals.Add(mAnimal);
            fAnimal = new Animal(Logger.getLogger(), "kangaroo", 40, 40, new Point(50, EF.height - 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'f', EF, "herbivorous");
            EF.animals.Add(fAnimal);
            mAnimal = new Animal(Logger.getLogger(), "elephant", 120, 120, new Point(EF.width - 50, 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'm', EF, "herbivorous");
            EF.animals.Add(mAnimal);
            fAnimal = new Animal(Logger.getLogger(), "elephant", 100, 100, new Point(50, EF.height - 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'f', EF, "herbivorous");
            EF.animals.Add(fAnimal);
            mAnimal = new Animal(Logger.getLogger(), "giraffe", 90, 90, new Point(EF.width - 50, 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'm', EF, "herbivorous");
            EF.animals.Add(mAnimal);
            fAnimal = new Animal(Logger.getLogger(), "giraffe", 80, 80, new Point(50, EF.height - 50), 0, 0, 0, 0, 1, 1, 1, 2, 6, 'f', EF, "herbivorous");
            EF.animals.Add(fAnimal);

            Canvas.Image = EF.paint(Canvas);
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Allowed animal names:\n - deer \n - lion \n - boar \n - fox \n - wolf \n - tiger \n - horse \n - kangaroo \n - elephant \n - giraffe", "Names of animals");
        }
    }
}