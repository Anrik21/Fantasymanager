using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fantasymanager
{
    public partial class Dungeonportal : Form
    {
        Random random;

        public Dungeonportal()
        {
            InitializeComponent();
            random = new Random();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int currentSound = random.Next(1, 4);

            if (currentSound == 1)
                System.Media.SystemSounds.Beep.Play();
            if (currentSound == 2)
                System.Media.SystemSounds.Asterisk.Play();
            if (currentSound == 3)
                System.Media.SystemSounds.Exclamation.Play();
            if (currentSound == 4)
                System.Media.SystemSounds.Hand.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GeneratorForm generator = new GeneratorForm();

            generator.Show();
        }
    }
}
