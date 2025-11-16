using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaAgain_Course14_
{
    public partial class Form1 : Form
    {

        public float totalPrice = 0;
        public string strToppings = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void PutNewLineIfNeeded(int L)
        {
            if (L == 3)
                strToppings += "\n";
        }
        private void UpdateToppings()
        {

            int Line = 0;
            int pr = 0;
            strToppings = "";

            if (chkExtraChees.Checked)
            {
                strToppings = "Extra Chees";
                pr += 5;
                Line++;
                PutNewLineIfNeeded(Line);
            }

            if (chkOnion.Checked)
            {
                strToppings += ", Onion";
                pr += 5;
                Line++;
                PutNewLineIfNeeded(Line);
            }

            if (chkMushrooms.Checked)
            {
                strToppings += ", Mushrooms";
                pr += 5;
                Line++;
                PutNewLineIfNeeded(Line);
            }


            if (chkOlives.Checked)
            {
                strToppings += ", Olives";
                pr += 5;
                Line++;
                PutNewLineIfNeeded(Line);
            }


            if (chkTomatoes.Checked)
            {
                strToppings += ", Tomatoes";
                pr += 5;
                Line++;
                PutNewLineIfNeeded(Line);
            }


            if (chkGreenPeppers.Checked)
            {
                strToppings += ", Green Peppers";
                pr += 5;
                Line++;
                PutNewLineIfNeeded(Line);
            }

            gbToppings.Tag = pr;

            if (strToppings.StartsWith(","))
            {
                strToppings = strToppings.Substring(1, strToppings.Length - 1);
            }

            if (strToppings == "")
                lblToppings.Text = "No Toppings";
            else lblToppings.Text = strToppings;

            UpdatePrice();

        }

        private void UpdatePrice()
        {
            totalPrice = Convert.ToSingle(gbSize.Tag) + Convert.ToSingle(gbToppings.Tag) + Convert.ToSingle(gbCrustType.Tag);
            lblTotalPrice.Text = totalPrice.ToString() + '$';
        }

        private void UpdateSize()
        {

            if (rbSmall.Checked)
            {
                gbSize.Tag = 10;
                lblSize.Text = "Small";
            }

            if (rbMeduim.Checked)
            {
                gbSize.Tag = 20;
                lblSize.Text = "Meduim";
            }

            if (rbLarge.Checked)
            {
                gbSize.Tag = 30;
                lblSize.Text = "Large";
            }

            UpdatePrice();
            //UpdateToppings();

        }



        private void UpdateCrust()
        {

            if (rbThinCrust.Checked)
            {
                gbCrustType.Tag = 0;
                lblCrustType.Text = "Thin";
            }

            if (rbThinkCrust.Checked)
            {
                gbCrustType.Tag = 10;
                lblCrustType.Text = "Think";
            }

            UpdatePrice();
            UpdateToppings();

        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThinkCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void BackToDefault()
        {

            rbMeduim.Checked = true;
            rbThinCrust.Checked = true;

            rbEatIn.Checked = false;
            rbTakeOut.Checked = false;

            chkExtraChees.Checked = false;
            chkOnion.Checked = false;
            chkMushrooms.Checked = false;
            chkOlives.Checked = false;
            chkTomatoes.Checked = false;
            chkGreenPeppers.Checked = false;

            gbSize.Enabled = true;
            gbToppings.Enabled = true;
            gbCrustType.Enabled = true;
            gbWhereToEat.Enabled = true;

            btnOrderPizza.Enabled = true;

            UpdateSize();
            UpdateCrust();
            lblWhereToEat.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BackToDefault();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            lblWhereToEat.Text = "Eat In";
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            lblWhereToEat.Text = "Take Out";
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Confirm Order ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                btnOrderPizza.Enabled = false;

                gbSize.Enabled = false;
                gbToppings.Enabled = false;
                gbCrustType.Enabled = false;
                gbWhereToEat.Enabled = false;

                MessageBox.Show("Order Confirmed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            BackToDefault();
        }

        //private void rbSmall_MouseEnter(object sender, EventArgs e)
        //{
        //    Cursor.Current = DefaultCursor;
        //}

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMeduim_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }
    }
}


