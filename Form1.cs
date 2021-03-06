using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace korsunovwebchik
{
    public partial class Form1 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        PictureBox pb;
        CheckBox cb_btn1, cb_btn2;
        RadioButton rb_btn1, rb_btn2;
        ListBox lb;
        DataGridView dg;
        TabControl tabC;


        public bool t = false;

        public Form1()
        {
            this.Height = 500;
            this.Width = 700;
            this.Text = "Vorm elemeentidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("Nupp"));
            tn.Nodes.Add(new TreeNode("Silt"));
            tn.Nodes.Add(new TreeNode("PictureBox"));
            tn.Nodes.Add(new TreeNode("CheckBox"));
            tn.Nodes.Add(new TreeNode("RadioButton"));
            tn.Nodes.Add(new TreeNode("TextBox"));
            tn.Nodes.Add(new TreeNode("TabControl"));
            tn.Nodes.Add(new TreeNode("Messagebox"));
            tn.Nodes.Add(new TreeNode("ListBox"));
            tn.Nodes.Add(new TreeNode("DataGridView"));
            tn.Nodes.Add(new TreeNode("MainMenu"));

            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }
        int click = 0;

        private void Pb_DoubleClick1(object sender, EventArgs e)
        {
            //Double_Click -> carusel (3-4 images) 1-2-3-4|1-2-3-4...
            string[] images = { "close_box_blue.jpg", "close_box_green.jpg", "close_box_red.jpg" };
            string fail = images[click];
            pb.Image = Image.FromFile(@"..\..\Images\" + fail);
            click++;
            if (click == 3) { click = 0; }
        }
        private void Lbl_MouseHover(object sender, EventArgs e)
        {
            lbl.BackColor = Color.FromArgb(200, 10, 20);
        }
        private void Lbl_MouseLeave(object sender, EventArgs e)
        {
            lbl.BackColor = Color.Transparent;
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text=="Nupp")
            {
                btn = new Button();
                btn.Text = "Vajuta siia";
                btn.Location = new Point(150, 25);
                btn.Height = 30;
                btn.Width = 100;
                btn.Click += Btn_Click;
                this.Controls.Add(btn);
            }
            else if (e.Node.Text=="Silt")
            {
                lbl = new Label();
                lbl.Text = "Elementide loomine c# abil";
                lbl.Size = new Size(600, 30);
                lbl.Location = new Point(150, 0);
                lbl.MouseHover += Lbl_MouseHover;
                lbl.MouseLeave += Lbl_MouseLeave;
                this.Controls.Add(lbl);
            }
            else if (e.Node.Text == "PictureBox")
            {
                pb = new PictureBox();
                pb.Size = new Size(200, 200);
                pb.Location = new Point(250, 60);
                pb.DoubleClick += Pb_DoubleClick1;
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pb.Image = Image.FromFile(@"..\..\Images\open_box_yellow.jpg");
                pb.DoubleClick += Pb_DoubleClick1;
                this.Controls.Add(pb);
            }
            else if(e.Node.Text == "CheckBox")
            {
                cb_btn1 = new CheckBox();
                cb_btn1.Location = new Point(400, 270);
                cb_btn2 = new CheckBox();
                cb_btn2.Size = new Size(90, 90);
                cb_btn1.Size = new Size(90, 90);
                cb_btn2.Location = new Point(400, 350);

                cb_btn1.CheckedChanged += CB_btn_CheckedChanged;

                cb_btn2.Image = Image.FromFile(@"..\..\Images\vopros.jpg");

                cb_btn1.BackColor = Color.Orange;
                cb_btn1.ForeColor = Color.Black;
                cb_btn1.Text = "Suurem";
                cb_btn2.Text = "Väiksem";
                cb_btn1.Font = new Font("Georgia", 12);

                this.Controls.Add(cb_btn1);
                this.Controls.Add(cb_btn2);
            }
            else if (e.Node.Text == "RadioButton")
            {
                rb_btn1 = new RadioButton();
                rb_btn1.Text = "Must teema";
                rb_btn1.Location = new Point(600, 150);
                rb_btn2 = new RadioButton();
                rb_btn2.Text = "Valge teema";
                rb_btn2.Location = new Point(600, 200);
                this.Controls.Add(rb_btn1);
                this.Controls.Add(rb_btn2);
                rb_btn1.CheckedChanged += new EventHandler(rb_btn_Checked);
                rb_btn2.CheckedChanged += new EventHandler(rb_btn_Checked);
            }
            else if (e.Node.Text == "Messagebox")
            {
                MessageBox.Show("MessageBox", "Kõige lihtsam aken");
                var answer = MessageBox.Show("Tahad InputBoxi näha?", "Aken koos nupudega", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    string text = Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi tekst");
                    if(MessageBox.Show("Kas tahad tekst saaada Tekskastisse?", "Teksti salvestamine", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        lbl.Text = text;
                        Controls.Add(lbl);
                    }
                    else
                    {
                        lbl.Text = "Siis head aega, mu vend!";
                        Controls.Add(lbl);
                    }
                }
                else
                {
                    var answer2 = MessageBox.Show("Ei saa aru, oled sa kindel?!", "Küsimus", MessageBoxButtons.YesNo);
                    if (answer2 == DialogResult.No)
                    {
                        string text = Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi tekst");
                        if (MessageBox.Show("Kas tahad tekst saaada Tekskastisse?", "Teksti salvestamine", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            lbl.Text = text;
                            Controls.Add(lbl);
                        }
                    }
                    else
                    {
                        lbl.Text = "Väga kahju!";
                        Controls.Add(lbl);
                    }
                }
            }
            else if (e.Node.Text == "ListBox")
            {
                lb = new ListBox();
                lb.Items.Add("Roheline");
                lb.Items.Add("Punane");
                lb.Items.Add("Kollane");
                lb.Items.Add("Sinine");
                lb.Items.Add("Hall");
                lb.Location = new Point(120, 120);
                lb.SelectedIndexChanged +=new EventHandler(lb_SelectedIndexChanged);
                this.Controls.Add(lb);
            }
            else if (e.Node.Text == "DataGridView")
            {
                DataSet ds = new DataSet("XML fail. Menüü");
                ds.ReadXml(@"..\..\Images\menu.xml");
                dg = new DataGridView();
                dg.Width = 200;
                dg.Height = 260;
                dg.Location = new Point(100, 280);
                dg.AutoGenerateColumns = true;
                dg.DataSource = ds;
                dg.DataMember = "food";

                this.Controls.Add(dg);
            }
            else if (e.Node.Text == "TabControl")
            {
                tabC = new TabControl();
                tabC.Location = new Point(550, 30);
                tabC.Size = new Size(200, 100);
                TabPage tabP1 = new TabPage("TTHK");
                WebBrowser wb = new WebBrowser();
                wb.Url = new Uri("https://www.tthk.ee/");
                tabP1.Controls.Add(wb);
                TabPage tabP2 = new TabPage("Teine");

                TabPage tabP3 = new TabPage("Kolmas");
                tabP3.DoubleClick += TabP3_DoubleClick;
                tabC.Controls.Add(tabP1);
                tabC.Controls.Add(tabP2);
                tabC.Controls.Add(tabP3);
                this.Controls.Add(tabC);
                tabC.Selected += TabC_Selected;
                tabC.DoubleClick += TabC_DoubleClick;
            }
            else if (e.Node.Text == "MainMenu")
            {
                MainMenu menu = new MainMenu();
                MenuItem menuFile = new MenuItem("File");
                menuFile.MenuItems.Add("Exit", new EventHandler(menuFile_Exit_Select));
                menuFile.MenuItems.Add("Clear", new EventHandler(menuFile_Clear_Select));
                menu.MenuItems.Add(menuFile);
                this.Menu = menu;
            }
        }
        private void menuFile_Clear_Select(object sender, EventArgs e)
        {
            lb.Dispose();
            dg.Dispose();
            btn.Dispose();
            lbl.Dispose();
            tabC.Dispose();
            pb.Dispose();
            cb_btn1.Dispose();
            cb_btn2.Dispose();
            rb_btn1.Dispose();
            rb_btn2.Dispose();

        }

        private void menuFile_Exit_Select(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pass
        }

        private void TabP3_DoubleClick(object sender, EventArgs e)
        {
            TabControl tabC = new TabControl();
            string title = "tabP" + (tabC.TabCount + 1).ToString();
            TabPage tb = new TabPage(title);
            tabC.TabPages.Add(tb);
        }
        private void TabC_DoubleClick(object sender, EventArgs e)
        {
            TabControl tabC = new TabControl();
            string title = "tabP" + (tabC.TabCount + 1).ToString();
            TabPage tb = new TabPage(title);
            tabC.TabPages.Add(tb);
        }
        private void TabC_Selected(object sender, EventArgs e)
        {
            //this.tabC.TabPages.Clear();
            //this.tabC.TabPages.Remove(tabC.SelectedTab);
        }
        private void rb_btn_Checked(object sender, EventArgs e)
        {
            if (rb_btn1.Checked)
            {
                this.BackColor = Color.Black;
                rb_btn2.ForeColor = Color.White;
                rb_btn1.ForeColor = Color.White;
            }
            else if (rb_btn2.Checked)
            {
                this.BackColor = Color.White;
                rb_btn2.ForeColor = Color.Black;
                rb_btn1.ForeColor = Color.Black;
            }
        }
        private void CB_btn_CheckedChanged(object sender, EventArgs e)
        {
            if (t)
            {
                this.Size = new Size(1100, 1100);
                pb.BorderStyle = BorderStyle.Fixed3D;
                cb_btn2.Text = "Teeme väiksem suurus";
                t = false;
            }
            else
            {
                this.Size = new Size(400, 400);
                cb_btn1.Text = "Suurendame";
                t = true;
            }
        }
    }
}