using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAOdev2
{

    public enum Floor
    {
        None = 0,
        Green = 1,
        Purple = 2,
        Red = 3
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        Floor Zemin;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Bahis hesaplamaları ve çıkarma işlemleri iki kullanıcı içinde burdaki metodların içinde yapılır.
        private void BahisHesapla2(double at)
        {
            if (at == atBirOran)
            {
                bahisIkiSonucu = bahis2 * atBirOran;
            }
            else if (at == atIkiOran)
            {
                bahisIkiSonucu = bahis2 * atIkiOran;
            }
            else if (at == atUcOran)
            {
                bahisIkiSonucu = bahis2 * atUcOran;
            }
            else
            {
                bahisIkiSonucu = bahis2 * atDortOran;
            }
            bakiye2 = (bakiye2 - bahis2) + bahisIkiSonucu;
            lblBahis2Sonucu.Text = bahisIkiSonucu.ToString();
            lblBakiye2.Text = bakiye2.ToString();
        }
        private void BahisHesapla1(double at)
        {
            if (at == atBirOran)
            {
                bahisBirSonucu = bahis1 * atBirOran;
            }
            else if (at == atIkiOran)
            {
                bahisBirSonucu = bahis1 * atIkiOran;
            }
            else if (at == atUcOran)
            {
                bahisBirSonucu = bahis1 * atUcOran;
            }
            else
            {
                bahisBirSonucu = bahis1 * atDortOran;
            }
            bakiye1 = (bakiye1 - bahis1) + bahisBirSonucu;
            lblBahis1Sonucu.Text = bahisBirSonucu.ToString();
            lblBakiye1.Text = bakiye1.ToString();
        }
        double BahisCikar1()
        {
            double cikar1 = 0;
            bakiye1 -= bahis1;
            bahisBirSonucu = bahis1;
            lblBahis1Sonucu.Text = "-" + bahisBirSonucu.ToString();
            lblBakiye1.Text = bakiye1.ToString();
            return cikar1;

        }
        double BahisCikar2()
        {
            double cikar2 = 0;
            bakiye2 -= bahis2;
            bahisIkiSonucu = bahis2;
            lblBahis2Sonucu.Text = "-" + bahisIkiSonucu.ToString();
            lblBakiye2.Text = bakiye2.ToString();
            return cikar2;
        }

        // atların kazandığına ve koşularının bitmesi gerektiği kısım burdaki metodla yapılır. 
        string Bitir()
        {
            string bosluk = "";
            if (pbAt1.Right > lblBitis.Left)
            {
                if (cmbKumarbaz1.SelectedIndex == 0 && cmbKumarbaz2.SelectedIndex == 0)
                {
                    BahisHesapla1(atBirOran);
                    BahisHesapla2(atBirOran);
                }

                else if (cmbKumarbaz1.SelectedIndex != 0 && cmbKumarbaz2.SelectedIndex == 0)
                {
                    BahisCikar1();
                    BahisHesapla2(atBirOran);
                }
                else if (cmbKumarbaz1.SelectedIndex == 0 && cmbKumarbaz2.SelectedIndex != 0)
                {
                    BahisHesapla1(atBirOran);
                    BahisCikar2();
                }

                else
                {
                    BahisCikar1();
                    BahisCikar2();
                }

                pbAt1.Enabled = pbAt2.Enabled = pbAt3.Enabled = pbAt4.Enabled = false;
                tmrAtlar.Stop();
                DialogResult dr = MessageBox.Show("Birinci at kazandı.\nYeniden oynamak ister misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    pbAt1.Left = pbAt2.Left = pbAt3.Left = pbAt4.Left = 0;
                    Zemin = 0;
                    gbZemin.BackColor = Color.White;
                    btnBaslat.Enabled = false;
                    btnBahisKapatma.Enabled = true;
                    btnSifirla.Enabled = true;
                    cmbbahis1.Enabled = true;
                    cmbKumarbaz1.Enabled = true;
                    cmbbahis2.Enabled = true;
                    cmbKumarbaz2.Enabled = true;
                    lblAt1Oran.Text = (oranlar[rnd.Next(0, 10)]).ToString();
                    lblAt2Oran.Text = (oranlar[rnd.Next(0, 10)]).ToString();
                    lblAt3Oran.Text = (oranlar[rnd.Next(0, 10)]).ToString();
                    lblAt4Oran.Text = (oranlar[rnd.Next(0, 10)]).ToString();


                }
                else
                {
                    Application.Exit();
                }

            }
            else if (pbAt2.Right > lblBitis.Left)
            {
                if (cmbKumarbaz1.SelectedIndex == 1 && cmbKumarbaz2.SelectedIndex == 1)
                {
                    BahisHesapla1(atIkiOran);
                    BahisHesapla2(atIkiOran);
                }

                else if (cmbKumarbaz1.SelectedIndex != 1 && cmbKumarbaz2.SelectedIndex == 1)
                {
                    BahisHesapla2(atIkiOran);
                    BahisCikar1();
                }
                else if (cmbKumarbaz1.SelectedIndex == 1 && cmbKumarbaz2.SelectedIndex != 1)
                {
                    BahisHesapla1(atIkiOran);
                    BahisCikar2();
                }

                else
                {
                    BahisCikar2();
                    BahisCikar1();
                }

                pbAt1.Enabled = pbAt2.Enabled = pbAt3.Enabled = pbAt4.Enabled = false;
                tmrAtlar.Stop();
                DialogResult dr = MessageBox.Show("İkinci at kazandı.\nYeniden oynamak ister misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    pbAt1.Left = pbAt2.Left = pbAt3.Left = pbAt4.Left = 0;
                    Zemin = 0;
                    gbZemin.BackColor = Color.White;
                    btnBaslat.Enabled = false;
                    btnBahisKapatma.Enabled = true;
                    btnSifirla.Enabled = true;
                    cmbbahis1.Enabled = true;
                    cmbKumarbaz1.Enabled = true;
                    cmbbahis2.Enabled = true;
                    cmbKumarbaz2.Enabled = true;
                    lblAt1Oran.Text = (oranlar[rnd.Next(0, 10)]).ToString();
                    lblAt2Oran.Text = (oranlar[rnd.Next(0, 10)]).ToString();
                    lblAt3Oran.Text = (oranlar[rnd.Next(0, 10)]).ToString();
                    lblAt4Oran.Text = (oranlar[rnd.Next(0, 10)]).ToString();


                }
                else
                {
                    Application.Exit();
                }

            }
            else if (pbAt3.Right > lblBitis.Left)
            {
                if (cmbKumarbaz1.SelectedIndex == 2 && cmbKumarbaz2.SelectedIndex == 2)
                {
                    BahisHesapla1(atUcOran);
                    BahisHesapla2(atUcOran);
                }

                else if (cmbKumarbaz1.SelectedIndex != 2 && cmbKumarbaz2.SelectedIndex == 2)
                {
                    BahisHesapla2(atUcOran);
                    BahisCikar1();
                }
                else if (cmbKumarbaz1.SelectedIndex == 2 && cmbKumarbaz2.SelectedIndex != 2)
                {
                    BahisHesapla1(atUcOran);
                    BahisCikar2();
                }

                else
                {
                    BahisCikar2();
                    BahisCikar1();
                }
                pbAt1.Enabled = pbAt2.Enabled = pbAt3.Enabled = pbAt4.Enabled = false;
                tmrAtlar.Stop();
                DialogResult dr = MessageBox.Show("Üçüncü at kazandı.\nYeniden oynamak ister misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    pbAt1.Left = pbAt2.Left = pbAt3.Left = pbAt4.Left = 0;
                    Zemin = 0;
                    gbZemin.BackColor = Color.White;
                    btnBaslat.Enabled = false;
                    btnBahisKapatma.Enabled = true;
                    btnSifirla.Enabled = true;
                    cmbbahis1.Enabled = true;
                    cmbKumarbaz1.Enabled = true;
                    cmbbahis2.Enabled = true;
                    cmbKumarbaz2.Enabled = true;
                    lblAt1Oran.Text = (oranlar[rnd.Next(0, 10)]).ToString();
                    lblAt2Oran.Text = (oranlar[rnd.Next(0, 10)]).ToString();
                    lblAt3Oran.Text = (oranlar[rnd.Next(0, 10)]).ToString();
                    lblAt4Oran.Text = (oranlar[rnd.Next(0, 10)]).ToString();


                }
                else
                {
                    Application.Exit();
                }

            }
            else if (pbAt4.Right > lblBitis.Left)
            {
                if (cmbKumarbaz1.SelectedIndex == 3 && cmbKumarbaz2.SelectedIndex == 3)
                {
                    BahisHesapla1(atUcOran);
                    BahisHesapla2(atUcOran);
                }

                else if (cmbKumarbaz1.SelectedIndex != 3 && cmbKumarbaz2.SelectedIndex == 3)
                {
                    BahisHesapla2(atUcOran);
                    BahisCikar1();
                }
                else if (cmbKumarbaz1.SelectedIndex == 3 && cmbKumarbaz2.SelectedIndex != 3)
                {
                    BahisHesapla1(atUcOran);
                    BahisCikar2();
                }

                else
                {
                    BahisCikar2();
                    BahisCikar1();
                }
                pbAt1.Enabled = pbAt2.Enabled = pbAt3.Enabled = pbAt4.Enabled = false;
                tmrAtlar.Stop();
                DialogResult dr = MessageBox.Show("Dördüncü at kazandı.\nYeniden oynamak ister misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    pbAt1.Left = pbAt2.Left = pbAt3.Left = pbAt4.Left = 0;
                    Zemin = 0;
                    gbZemin.BackColor = Color.White;
                    btnBaslat.Enabled = false;
                    btnBahisKapatma.Enabled = true;
                    btnSifirla.Enabled = true;
                    cmbbahis1.Enabled = true;
                    cmbKumarbaz1.Enabled = true;
                    cmbbahis2.Enabled = true;
                    cmbKumarbaz2.Enabled = true;
                    lblAt1Oran.Text = (oranlar[rnd.Next(0, 10)]).ToString();
                    lblAt2Oran.Text = (oranlar[rnd.Next(0, 10)]).ToString();
                    lblAt3Oran.Text = (oranlar[rnd.Next(0, 10)]).ToString();
                    lblAt4Oran.Text = (oranlar[rnd.Next(0, 10)]).ToString();


                }
                else
                {
                    Application.Exit();
                }

            }

            return bosluk;
        }

        //Atların koşmalarının ayarlandığı timer eventinin olduğu kısım.
        private void tmrAtlar_Tick(object sender, EventArgs e)
        {
            switch (Zemin)
            {
                case Floor.Green:
                    gbZemin.BackColor = Color.Green;
                    pbAt1.Left += rnd.Next(4, 10);
                    pbAt2.Left += rnd.Next(3, 10);
                    pbAt3.Left += rnd.Next(1, 10);
                    pbAt4.Left += rnd.Next(1, 10);
                    if (pbAt1.Right > pbAt2.Right && pbAt1.Right > pbAt3.Right && pbAt1.Right > pbAt4.Right)
                    {
                        lblBilgi.Text = "Şahtı Şahbaz Oldu birinci sırada son sürat ilerliyor.";
                    }
                    else if (pbAt2.Right > pbAt1.Right && pbAt2.Right > pbAt3.Right && pbAt2.Right > pbAt4.Right)
                    {
                        lblBilgi.Text = "Gazoz Kapağı birinci sırada son sürat ilerliyor.";
                    }
                    else if (pbAt3.Right > pbAt1.Right && pbAt3.Right > pbAt2.Right && pbAt3.Right > pbAt4.Right)
                    {
                        lblBilgi.Text = "Ofis Lambası inanılmaz bir hızla birinci sırada ilerliyor";
                    }
                    else if (pbAt4.Right > pbAt1.Right && pbAt4.Right > pbAt2.Right && pbAt4.Right > pbAt3.Right)
                    {
                        lblBilgi.Text = "Mouse Sağ Tık kendini aştı birinci sırada ilerliyor.";
                    }


                    Bitir();
                    break;
                case Floor.Purple:
                    gbZemin.BackColor = Color.DarkMagenta;
                    pbAt1.Left += rnd.Next(1, 10);
                    pbAt2.Left += rnd.Next(4, 10);
                    pbAt3.Left += rnd.Next(3, 10);
                    pbAt4.Left += rnd.Next(1, 10);
                    if (pbAt1.Right > pbAt2.Right && pbAt1.Right > pbAt3.Right && pbAt1.Right > pbAt4.Right)
                    {
                        lblBilgi.Text = "Şahtı Şahbaz Oldu birinci sırada son sürat ilerliyor.";
                    }
                    else if (pbAt2.Right > pbAt1.Right && pbAt2.Right > pbAt3.Right && pbAt2.Right > pbAt4.Right)
                    {
                        lblBilgi.Text = "Gazoz Kapağı birinci sırada son sürat ilerliyor.";
                    }
                    else if (pbAt3.Right > pbAt1.Right && pbAt3.Right > pbAt2.Right && pbAt3.Right > pbAt4.Right)
                    {
                        lblBilgi.Text = "Ofis Lambası inanılmaz bir hızla birinci sırada ilerliyor";
                    }
                    else if (pbAt4.Right > pbAt1.Right && pbAt4.Right > pbAt2.Right && pbAt4.Right > pbAt3.Right)
                    {
                        lblBilgi.Text = "Mouse Sağ Tık kendini aştı birinci sırada ilerliyor.";
                    }
                    Bitir();
                    break;
                case Floor.Red:
                    gbZemin.BackColor = Color.Red;
                    pbAt1.Left += rnd.Next(1, 10);
                    pbAt2.Left += rnd.Next(1, 10);
                    pbAt3.Left += rnd.Next(4, 10);
                    pbAt4.Left += rnd.Next(3, 10);
                    if (pbAt1.Right > pbAt2.Right && pbAt1.Right > pbAt3.Right && pbAt1.Right > pbAt4.Right)
                    {
                        lblBilgi.Text = "Şahtı Şahbaz Oldu birinci sırada son sürat ilerliyor.";
                    }
                    else if (pbAt2.Right > pbAt1.Right && pbAt2.Right > pbAt3.Right && pbAt2.Right > pbAt4.Right)
                    {
                        lblBilgi.Text = "Gazoz Kapağı birinci sırada son sürat ilerliyor.";
                    }
                    else if (pbAt3.Right > pbAt1.Right && pbAt3.Right > pbAt2.Right && pbAt3.Right > pbAt4.Right)
                    {
                        lblBilgi.Text = "Ofis Lambası inanılmaz bir hızla birinci sırada ilerliyor";
                    }
                    else if (pbAt4.Right > pbAt1.Right && pbAt4.Right > pbAt2.Right && pbAt4.Right > pbAt3.Right)
                    {
                        lblBilgi.Text = "Mouse Sağ Tık kendini aştı birinci sırada ilerliyor.";
                    }
                    Bitir();
                    break;
            }
        }

        //Convert işleminden önceki değişken tanımlama 

        double atBirOran;
        double atIkiOran;
        double atUcOran;
        double atDortOran;
        double bakiye1;
        double bakiye2;
        double bahisBirSonucu;
        double bahisIkiSonucu;
        double bahis1;
        double bahis2;
        double[] oranlar = { 1.20, 1.30, 1.50, 1.60, 1.70, 2.00, 2.10, 1.80, 1.90, 2.30 };

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            tmrAtlar.Start();
            Zemin += rnd.Next(1, 4);
            btnBaslat.Enabled = false;
            pbAt1.Enabled = pbAt2.Enabled = pbAt3.Enabled = pbAt4.Enabled = true;



            //Bahis kısmındaki lbl ve indexlerin integera çevrilmesi kısmı
            atBirOran = Convert.ToDouble(lblAt1Oran.Text);
            atIkiOran = Convert.ToDouble(lblAt2Oran.Text);
            atUcOran = Convert.ToDouble(lblAt3Oran.Text);
            atDortOran = Convert.ToDouble(lblAt4Oran.Text);
            bakiye1 = Convert.ToDouble(lblBakiye1.Text);
            bakiye2 = Convert.ToDouble(lblBakiye2.Text);
            bahisBirSonucu = Convert.ToDouble(lblBahis1Sonucu.Text);
            bahisIkiSonucu = Convert.ToDouble(lblBahis2Sonucu.Text);
            bahis1 = Convert.ToDouble(cmbbahis1.SelectedItem);
            bahis2 = Convert.ToDouble(cmbbahis2.SelectedItem);


        }


        private void btnBahisKapatma_Click(object sender, EventArgs e)
        {
            double bahis1Karsilastirma = Convert.ToDouble(cmbbahis1.SelectedItem);
            double bakiye1Karsilastirma = Convert.ToDouble(lblBakiye1.Text);

            double bahis2Karsilastirma = Convert.ToDouble(cmbbahis2.SelectedItem);
            double bakiye2Karsilastirma = Convert.ToDouble(lblBakiye2.Text);

            if (bahis1Karsilastirma <= bakiye1Karsilastirma)
            {
                btnBaslat.Enabled = true;
                btnBahisKapatma.Enabled = false;
                btnSifirla.Enabled = false;
                cmbbahis1.Enabled = false;
                cmbKumarbaz1.Enabled = false;

            }

            else
            {
                cmbKumarbaz2.Enabled = false;
                cmbbahis2.Enabled = false;
                MessageBox.Show("Bahis değeriniz mevcut bakiyenizden yüksek olmaz lütfen mevcut bakiyenize eşit ya da daha az bir bahis değeri seçiniz.");
                btnBaslat.Enabled = false;
                btnBahisKapatma.Enabled = true;
            }

            if (bahis2Karsilastirma <= bakiye2Karsilastirma)
            {
                btnBaslat.Enabled = true;
                btnBahisKapatma.Enabled = false;
                btnSifirla.Enabled = false;
                cmbbahis2.Enabled = false;
                cmbKumarbaz2.Enabled = false;
            }
            else
            {

                MessageBox.Show("Bahis değeriniz mevcut bakiyenizden yüksek olmaz lütfen mevcut bakiyenize eşit ya da daha az bir bahis değeri seçiniz.");
                btnBaslat.Enabled = false;
                btnBahisKapatma.Enabled = true;

            }
        }

        private void btnSifirla_Click(object sender, EventArgs e)
        {
            cmbbahis1.SelectedIndex = -1;
            cmbKumarbaz1.SelectedIndex = -1;
            lblBahis1Sonucu.Text = "0";
            lblBakiye1.Text = "100";

            cmbbahis2.SelectedIndex = -1;
            cmbKumarbaz2.SelectedIndex = -1;
            lblBahis2Sonucu.Text = "0";
            lblBakiye2.Text = "100";
        }
    }
}
