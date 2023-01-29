using System.Runtime.InteropServices;

namespace SymulatorDaltonizmu1
{
    public partial class Form1 : Form
    {
        private Simulator simulator;
        public Form1()
        {
            InitializeComponent();
        }


        private void start_Click(object sender, EventArgs e)
        {
            if (defaultView.Image != null)
            {
                time.Text = simulator.start() + " ms";
                colorBlindView.Image = simulator.GetBlindImage();
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Title = "Wybierz obraz";
            opf.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(opf.FileName);
                simulator = new Simulator(image);
                defaultView.Image = simulator.GetImage();
            }
        }

        private void cLibrary_CheckedChanged(object sender, EventArgs e)
        {
            if (simulator != null)
            {
                simulator.setLibrary(true); // Load c++ lib - true

            }
        }

        private void asmLibrary_CheckedChanged(object sender, EventArgs e)
        {
            if (simulator != null)
            {
                simulator.setLibrary(false); // Load asm lib - false

            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBar1, trackBar1.Value.ToString());
            if (simulator != null)
            {
                simulator.setThreads(trackBar1.Value);
            }

        }

        private void save_Click(object sender, EventArgs e)
        {
            if (colorBlindView.Image != null)
            {
                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All files (*.*)|*.*";

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    Bitmap image = simulator.GetBlindImage();
                    image.Save(sf.FileName);
                }
            }
        }
    }
}