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
            simulator.start();
            colorBlindView.Image = simulator.GetBlindImage();
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
            simulator.setLibrary(true); // Load c++ lib - true
        }

        private void asmLibrary_CheckedChanged(object sender, EventArgs e)
        {
            simulator.setLibrary(false); // Load asm lib - false
        }
    }
}