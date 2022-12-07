using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace LoginApplication
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            setBackgroundImage();
        }

        private void setBackgroundImage()
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://random.imagecdn.app/800/600");
            Bitmap bitmap; bitmap = new Bitmap(stream);
            roundePanel2.BackgroundImage = bitmap;
        }

        private void label1_Click(object sender, System.EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
