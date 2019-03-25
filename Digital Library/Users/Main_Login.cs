﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digital Library.Customization;
using Digital Library;

namespace Digital Library__Main.Login
{
    public partial class Main_Login : Form
    {
        public Main_Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            pnlPage2Admin.Visible = false;
            this.Height = 134;
            this.CenterToScreen();
            FormAnimation.AnimateWindow(this.Handle, 500, FormAnimation.BLEND);            
            AutoGeneratedId();
            pnlPage3_Signup_Admin.Visible = false;
        }

        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
                "123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        private void AutoGeneratedId()
        {
            lblMainIdNumberPage3_Signup.Text = "ADMIN-" + GetUniqueKey(10);            
        }

        private void btnPage2SignIn_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder3D(e.Graphics, this.btnPage2SignIn.ClientRectangle, Border3DStyle.RaisedOuter, Border3DSide.Bottom);
        }

        private bool flagPinkColor;

        private void btnPage2Signup_Click(object sender, EventArgs e)
        {
            if (lblPage2Admin.Text == "LIBRARIAN")
            {
                pnlPage2_SignIn_Admin.Visible = false;
                pnlPage3_Signup_Admin.Visible = false;
                pnlPageSignup_Librarian.Visible = true;
            }
            else
            {
                pnlPage2_SignIn_Admin.Visible = false;
                pnlPage3_Signup_Admin.Visible = true;
            }
            Separator_SignUp.BackColor = Color.FromArgb(235, 42, 121);
            //Separator_SignIn.BackColor = Color.FromArgb(55, 52, 71);
            Separator_SignUp.Size = new Size(0, 2);
            PinkSlider.Enabled = true;
            flagPinkColor = false;
            
        }

        private void PinkSlider_Tick(object sender, EventArgs e)
        {
            if (flagPinkColor)
            {
                if (Separator_SignIn.Width >= 253)
                {
                    PinkSlider.Enabled = false;
                }
                else
                {
                    Separator_SignUp.Width -= 20;
                    Separator_SignIn.Width += 20;
                }
            }
            else
            {

                if (Separator_SignUp.Width >= 254)
                {
                    PinkSlider.Enabled = false;
                }
                else
                {
                    Separator_SignUp.Width += 20;
                    Separator_SignIn.Width -= 20;
                }

            }
        }

        private void btnPage2SignIn_Click(object sender, EventArgs e)
        {
            //Separator_SignUp.BackColor = Color.FromArgb(55, 52, 71);
            Separator_SignIn.BackColor = Color.FromArgb(235, 42, 121);
            Separator_SignIn.Size = new Size(0, 2);
            PinkSlider.Enabled = true;
            flagPinkColor = true;
            pnlPage3_Signup_Admin.Visible = false;
            pnlPage2_SignIn_Admin.Visible = true;
        }

        private void txtbxPage2SignInMail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbxPage2SignInMail.Text) || txtbxPage2SignInMail.Text == "e.g. MoinAkther@gmail.com")
            {
                picbxPage2SignInEmailCheck.Visible = true;
                picbxPage2SignInEmailCheck.Load(@"../../Resources/Login/Error_3.png");
            }
            else
            {
                picbxPage2SignInEmailCheck.Visible = true;
                picbxPage2SignInEmailCheck.Load(@"../../Resources/Login/Tick_2.png");
            }
        }

        private void btnPage1Login_Click(object sender, EventArgs e)
        {            
            pnlPage2Admin.Visible = false;
            AdminSlider.Enabled = true;
            Digital Library.Global.LibrarianType = "Admin";
        }

        private void AdminSlider_Tick(object sender, EventArgs e)
        {
            if (this.Height <= 3)
            {
                AdminSlider.Enabled = false;
                pnlPage1.Visible = false;
                pnlPage2Admin.Visible = true;
                Slider_Admin_2.Enabled = true;
            }
            else
            {
                var xAxis = this.Location.X;
                var yAxis = this.Location.Y - 60;
                this.Height -= 30;
                this.Location = new Point(xAxis, yAxis);
            }
        }

        private void Slider_Admin_2_Tick(object sender, EventArgs e)
        {
            if (this.Height >= 760)
            {
                Slider_Admin_2.Enabled = false;
                Refresh();
            }
            else
            {
                this.Height += 20;
            }
        }

        private void txtbxPage2SignInPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbxPage2SignInPassword.Text))
            {
                picbxPage2SignInPasswordCheck.Visible = true;
                picbxPage2SignInPasswordCheck.Load(@"../../Resources/Login/Error_3.png");
            }
            else
            {
                picbxPage2SignInPasswordCheck.Visible = true;
                picbxPage2SignInPasswordCheck.Load(@"../../Resources/Login/Tick_2.png");
            }
        }

        private void txtbxEmailPage3_Signup_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbxEmailPage3_Signup.Text))
            {
                picbxEmailCheckPage3_Signup.Visible = true;
                picbxEmailCheckPage3_Signup.Load(@"../../Resources/Login/Error_3.png");
            }
            else
            {
                picbxEmailCheckPage3_Signup.Visible = true;
                picbxEmailCheckPage3_Signup.Load(@"../../Resources/Login/Tick_2.png");
            }
        }

        private void txtbxPasswordPage3_Signup_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbxPasswordPage3_Signup.Text))
            {
                picbxPasswordCheckPage3_Signup.Visible = true;
                picbxPasswordCheckPage3_Signup.Load(@"../../Resources/Login/Error_3.png");
            }
            else
            {
                picbxPasswordCheckPage3_Signup.Visible = true;
                picbxPasswordCheckPage3_Signup.Load(@"../../Resources/Login/Tick_2.png");
            }
        }

        private void txtbxRetypePage3_Signup_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtbxRetypePage3_Signup.Text))
            {
                picbxRetypeCheckPage3_Signup.Visible = true;
                picbxRetypeCheckPage3_Signup.Load(@"../../Resources/Login/Error_3.png");
            }
            else
            {
                picbxRetypeCheckPage3_Signup.Visible = true;
                picbxRetypeCheckPage3_Signup.Load(@"../../Resources/Login/Tick_2.png");
            }
        }

        private void btnLibrarian_Click(object sender, EventArgs e)
        {
            lblPage2Admin.Text = "LIBRARIAN";
            Digital Library.Global.LibrarianType = "Librarian";
            btnPage1Login_Click(sender, e);
        }

        private void lblPage2SignInAccountCreate_Click(object sender, EventArgs e)
        {            
            btnPage2Signup_Click(sender, e);
        }

        private void lblLogInPage3_Signup_Click(object sender, EventArgs e)
        {
            btnPage2SignIn_Click(sender, e);
        }

        private void picbxAdmin_Select_MouseEnter(object sender, EventArgs e)
        {
            btnAdmin_Select.BackColor = Color.FromArgb(61, 57, 79);
        }

        private void picbxAdmin_Select_MouseLeave(object sender, EventArgs e)
        {
            btnAdmin_Select.BackColor = Color.FromArgb(49, 46, 63);
        }

        private void picbxLibrarian_Select_MouseEnter(object sender, EventArgs e)
        {
            btnLibrarian_Select.BackColor = Color.FromArgb(61, 57, 79);
        }

        private void picbxLibrarian_Select_MouseLeave(object sender, EventArgs e)
        {
            btnLibrarian_Select.BackColor = Color.FromArgb(49, 46, 63);
        }

        private void lblClose_MouseEnter(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.FromArgb(49, 46, 63);
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.BackColor = Color.FromArgb(55, 52, 71);
        }

        private void lblClose_Select_MouseEnter(object sender, EventArgs e)
        {
            lblClose_Select.BackColor = Color.FromArgb(49, 46, 63);
        }

        private void lblClose_Select_MouseLeave(object sender, EventArgs e)
        {
            lblClose_Select.BackColor = Color.FromArgb(55, 52, 71);
        }

        private void lblClose_Select_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        public event EventHandler<Digital Library.Lib.ActionDataEventArgs> NewActionData;
        private void btnPage2SignInEnter_Click(object sender, EventArgs e)
        {
            //lblPage2Admin
            if (lblPage2Admin.Text == "Admin")
            {
                Digital Library.Global.LibrarianType = "Admin";
            }
            else
            {
                Digital Library.Global.LibrarianType = "Librarian";
            }
            if (txtbxPage2SignInMail.Text.Trim() != "" && txtbxPage2SignInPassword.Text.Trim() != "")
            {
                Digital Library.Lib.User_Info u = new Digital Library.Lib.User_Info();
                u.MainId = txtbxPage2SignInMail.Text.Trim();
                u.Password = txtbxPage2SignInPassword.Text.Trim();
                u.UserType = lblPage2Admin.Text.Trim();
                if (u.Login())
                {
                    Dashboard showDashboard = new Dashboard();
                    this.NewActionData += showDashboard.GetActionData;
                    DataTable dt = u.FilterLibrarianList("ID", txtbxPage2SignInMail.Text.Trim());
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            var Id = dr["Lib_MainId"].ToString();
                            var Type = dr["Lib_Type"].ToString();
                            var Name = (dr["Lib_FirstName"].ToString() + " " + dr["Lib_LastName"].ToString());
                            Image Pic = null;
                            if (!DBNull.Value.Equals(dr["Lib_Pic"]))
                            {
                                Pic = Global.ConvertIntoImage((byte[])dr["Lib_Pic"]);
                            }
                            else
                            {
                                Pic = Digital Library.Properties.Resources.default_man;
                            }
                            OnNewActionData(Pic, Type, Id, Name);
                        }
                    }
                    this.Hide();
                    showDashboard.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Incorrect username and password", Digital Library.Global.CaptionLib, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private  void OnNewActionData(Image img, string LibType, string LibId, string LibName)
        {
            var handler = NewActionData;
            if (handler != null)
            {
                handler(this, new Digital Library.Lib.ActionDataEventArgs() { Picture = img, LibID = LibId, LibType = LibType, LibName = LibName });
            }
        }
    }
}
