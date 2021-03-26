using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasixzCrypter
{
    public partial class Form1 : Form
    {

        bool mousedown;
        private Point offset;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (label8.ForeColor == Color.Crimson)
            {
                label8.ForeColor = Color.Black;
                label8.Text = "veinz ❤️ Luna"
                ;
            }
            else
            {
                label8.ForeColor = Color.Crimson;
                label8.Text = "veinz ❤️ Basixz";
            }
        }
        string hash = "b4s1xz";
        private void btnSifre_Click(object sender, EventArgs e)
        {
            if (txtMetin.Text == "")
            {
                MessageBox.Show("The 'text field' cannot be empty. Please fill it then try again.");
                return;
            }
            else if (txtMetin.Text == "luna")
            {
                MessageBox.Show("Bu kişi buraya yazılamayacak kadar değerli lütfen tekrar denemeyiniz");
                return;
            }
            else
            {
                byte[] data = UTF8Encoding.UTF8.GetBytes(txtMetin.Text);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateEncryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        txtSifre.Text = Convert.ToBase64String(results, 0, results.Length);
                    }
                }
            }
        }

        private void btnCoz_Click(object sender, EventArgs e)
        {
            if(txtSifre.Text == "")
            {
                MessageBox.Show("Crypted text cannot be empty! Please write your crypted text or if you want to crypt a text, write your text in text.");
                return;
            }
            else if (txtMetin.Text == "luna")
            {
                MessageBox.Show("Bu kişi buraya yazılamayacak kadar değerli lütfen tekrar denemeyiniz");
                return;
            }
            else
            {
                byte[] data = Convert.FromBase64String(txtSifre.Text);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateDecryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        txtCozum.Text = UTF8Encoding.UTF8.GetString(results);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            offset.X = e.X;
            offset.Y = e.Y;
            mousedown = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mousedown == true)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                Location = new Point(currentScreenPos.X - offset.X, currentScreenPos.Y - offset.Y);
            }

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/pjSEpTU");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            hash = hashText.Text;
        }
    }
}
