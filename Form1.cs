/****************************************************************************
**					      SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				     BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				    NESNEYE DAYALI PROGRAMLAMA DERSİ
**					     2023-2024 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI: BAHAR DÖNEMİ-1
**				ÖĞRENCİ ADI: NİSA NUR GÜREL
**				ÖĞRENCİ NUMARASI: G221210079
**              DERSİN ALINDIĞI GRUP: 2.ÖĞRETİM/C
****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wform1
{
    public partial class Form1 : Form
    {
        string currentFilePath; // Şu anda üzerinde çalışılan dosyanın yolu
        public Form1()
        {
            InitializeComponent();
        }

        // Dosya Açma işlemi için tetiklenen olay
        private void dosyaAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = openFileDialog.FileName;
                {
                    currentFilePath = openFileDialog.FileName; // Seçilen dosyanın yolu currentFilePath değişkenine atanıyor
                    richTextBox1.Text = System.IO.File.ReadAllText(currentFilePath); // Seçilen dosyanın içeriği richTextBox1'e yükleniyor
                }
            }
        }

        // Dosya Kaydetme işlemi için tetiklenen olay
        private void dosyaKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFilePath != null) // Eğer zaten bir dosya üzerinde çalışılıyorsa
            {
                SaveToFile(currentFilePath); // Mevcut dosyayı kaydet
            }
            else // Eğer henüz bir dosya seçilmemişse
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Metin Dosyaları|*.txt|Tüm Dosyalar|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = saveFileDialog.FileName; // Dosya yolunu sakla
                    SaveToFile(currentFilePath); // Dosyayı kaydet
                }
            }
        }

        // Dosyayı belirtilen bir yola kaydetme işlemi
        private void SaveToFile(string filePath)
        {
            if (File.Exists(filePath)) // Eğer dosya zaten varsa
            {
                var result = MessageBox.Show("Bu dosya zaten var. Mevcut içeriği korumak istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Cancel)
                    return;
                else if (result == DialogResult.No) // Dosyayı yeniden yaz
                    File.WriteAllText(filePath, richTextBox1.Text);
                else if (result == DialogResult.Yes) // Mevcut dosyanın sonuna ekle
                    File.AppendAllText(filePath, richTextBox1.Text); 
            }
            else // Eğer dosya yoksa
            {
                File.WriteAllText(filePath, richTextBox1.Text); // Dosyayı oluştur ve içeriği yaz
            }
        }

        // Çıkış işlemi için tetiklenen olay
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Modified) // Eğer richTextBox1'in içeriği değiştirilmişse
            {
                DialogResult result = MessageBox.Show("Dosyayı kaydetmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    dosyaKaydetToolStripMenuItem_Click(sender, e); // Dosyayı kaydet
                }
                else if (result == DialogResult.Cancel)
                {
                    return; // İptal et
                }
            }

            Application.Exit(); // Uygulamayı kapat
        }

        // Kes işlemi için tetiklenen olay
        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut(); // Seçili metni kes
        }

        // Kopyalama işlemi için tetiklenen olay
        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy(); // Seçili metni kopyala
        }

        // Yapıştırma işlemi için tetiklenen olay
        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste(); // Seçili metni yapıştır
        }

        // Yazı rengi değiştirme işlemi için tetiklenen olay
        private void yazıRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = colorDialog.Color; // Yazı rengini değiştir
            }
        }

        // Zemin rengi değiştirme işlemi için tetiklenen olay
        private void zeminRengiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.BackColor = colorDialog.Color; // Zemin rengini değiştir
            }
        }

        // Yazı tipi değiştirme işlemi için tetiklenen olay
        private void yazıÇeşidiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();

            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog.Font; // Yazı tipini değiştir
            }
        }
    }
}
