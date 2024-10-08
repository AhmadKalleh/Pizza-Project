using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
         
        }

        private void UpdateSize()
        {

            if(rbSmall.Checked)
            {
                labelSize.Text=rbSmall.Text;
                return;
            }

            if(rbMeduim.Checked)
            {
                labelSize.Text = rbMeduim.Text;
                return;
            }

            if(rbLarg.Checked)
            {
                labelSize.Text= rbLarg.Text;
                return;
            }
        }

        private void UpdateCrustType()
        {
            if(rbThinCrust.Checked)
            {
                labelCrustType.Text = rbThinCrust.Text;
                return;
            }

            if(rbThinkCrust.Checked)
            {
                labelCrustType.Text = rbThinkCrust.Text;
                return;
            }
        }

        private void UpdateWhereToEat()
        {
            if(rbEatIn.Checked)
            {
                labelWhereToEat.Text = rbEatIn.Text;
                return;
            }

            if(rbTakeOut.Checked)
            {
                labelWhereToEat.Text = rbTakeOut.Text;
                return;
            }
        }
        private void UpdatesToppings()
        {
            String sToppings = "";

            if (chkExtraChees.Checked)
            {
                sToppings += chkExtraChees.Text;
            }

            if (chkOnion.Checked)
            {
                sToppings += ", " + chkOnion.Text;
            }

            if (chkMushrooms.Checked)
            {
                sToppings += ", " + chkMushrooms.Text;
            }

            if (chkOlives.Checked)
            {
                sToppings += ", " + chkOlives.Text;
            }

            if (chkTomatoes.Checked)
            {
                sToppings += ", " + chkTomatoes.Text;
            }

            if (chkGreenPeppers.Checked)
            {
                sToppings += ", " + chkGreenPeppers.Text;
            }

            if (sToppings.StartsWith(", "))
            {
                sToppings = sToppings.Substring(1, sToppings.Length -1 ).Trim();
            }

            if (sToppings == "")
                sToppings = "No Toppings";

            labelToppings.Text = sToppings;


        }

        float GetSelectedSizePrice()
        {
            if(rbSmall.Checked)
            {
                return Convert.ToSingle(rbSmall.Tag);
            }

            else if(rbMeduim.Checked)
            {
                return Convert.ToSingle(rbMeduim.Tag);
            }

            else
                return  Convert.ToSingle(rbLarg.Tag);


        }

        float GetSelectedCrustPrice()
        {
            if(rbThinCrust.Checked)
                return Convert.ToSingle(rbThinCrust.Tag);

            else 
                return Convert.ToSingle(rbThinkCrust.Tag);
        }

        float CalculateToppingsPrice()
        {
            float price = 0;

           
            if (chkExtraChees.Checked)
                price += Convert.ToSingle(chkExtraChees.Tag);

            if (chkOlives.Checked) 
                price += Convert.ToSingle(chkOlives.Tag); ;


            if (chkMushrooms.Checked) 
                price += Convert.ToSingle(chkMushrooms.Tag);

            if (chkOnion.Checked) 
                price += Convert.ToSingle(chkOnion.Tag);

            if (chkTomatoes.Checked) 
                price += Convert.ToSingle(chkTomatoes.Tag);

            if (chkGreenPeppers.Checked) 
                price += Convert.ToSingle(chkGreenPeppers.Tag);

            return price;

        }

        private float CalculateTotalPrice()
        {
            return GetSelectedSizePrice() + CalculateToppingsPrice()+ GetSelectedCrustPrice();
        }
        private void UpdateTotalPrice()
        {
          
            labelPrice.Text = "$" + CalculateTotalPrice().ToString(); 

        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
            UpdateTotalPrice();
        }

        private void rbMeduim_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
            UpdateTotalPrice();
        }

        private void rbLarg_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
            UpdateTotalPrice();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
            UpdateTotalPrice();
        }

        private void rbThinkCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrustType();
            UpdateTotalPrice();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        
        private void chkExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdatesToppings();
            UpdateTotalPrice();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdatesToppings();
            UpdateTotalPrice();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdatesToppings();
            UpdateTotalPrice();
        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdatesToppings();
            UpdateTotalPrice();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdatesToppings();
            UpdateTotalPrice();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdatesToppings();
            UpdateTotalPrice();
        }

        private void DisableForm()
        {
            gbSize.Enabled = false;
            gbCrustType.Enabled = false;
            gbWhereToEat.Enabled = false;
            gbToppings.Enabled = false;
            btnOrderPizza.Enabled = false;
        }

        private void ResetForm()
        {
            gbSize.Enabled = true;
            gbCrustType.Enabled = true;
            gbWhereToEat.Enabled = true;
            gbToppings.Enabled = true;

            btnOrderPizza.Enabled = true;

            rbMeduim.Enabled = true;
            chkExtraChees.Enabled = false;
            chkGreenPeppers.Enabled = false;
            chkOlives.Enabled = false;
            chkTomatoes.Enabled = false;
            chkOnion.Enabled = false;
            chkMushrooms.Enabled = false;

            rbThinCrust.Enabled = true;

            

            rbEatIn.Checked = true;

        }
        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure about this request ?","Order Recipient",MessageBoxButtons.OKCancel, MessageBoxIcon.Information,MessageBoxDefaultButton.Button2)==DialogResult.OK)
            {
                DisableForm();
            }
            
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void UpdateNumberOfPizza()
        {
            lbNumberOfPizza.Text = "1";
        }
        private void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateCrustType();
            UpdateWhereToEat();
            UpdatesToppings();
            UpdateTotalPrice();
            UpdateNumberOfPizza();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            lbNumberOfPizza.Text = numericUpDown1.Value.ToString();
            labelPrice.Text = "$" + (CalculateTotalPrice() * Convert.ToDouble(numericUpDown1.Value)).ToString();
        }
    }
}
