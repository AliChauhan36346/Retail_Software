using ALA_Accounting.Addition_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ALA_Accounting.Addition
{
    public partial class AddBrands : Form
    {
        Brand brand = new Brand();

        bool isEditing = true;
        

        public AddBrands()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddBrands_Load(object sender, EventArgs e)
        {
            brand.LoadBrandsIntoListBox(lstBrandName);
        }

        private void btn_addNew_Click(object sender, EventArgs e)
        {
            txt_brandName.Clear();
            isEditing = false;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(isEditing)
            {
                if(lstBrandName.Items.Count==0 || lstBrandName.SelectedItems.Count==0)
                {
                    return;
                }
                brand.UpdateBrand(lstBrandName.SelectedItem.ToString().Trim(), txt_brandName.Text.Trim());
                brand.LoadBrandsIntoListBox(lstBrandName);
            }
            else
            {
                brand.brandName=txt_brandName.Text.Trim();
                brand.SaveBrand(brand.brandName);
                brand.LoadBrandsIntoListBox(lstBrandName);

                isEditing = true;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            isEditing = true;

            if(lstBrandName.Items.Count == 0)
            {
                txt_brandName.Clear();
                return;
            }

            lstBrandName.SelectedIndex= 0;

            txt_brandName.Text = lstBrandName.SelectedItem.ToString();
        }

        private void lstBrandName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBrandName.SelectedItems.Count > 0)
            {
                txt_brandName.Text = lstBrandName.SelectedItem.ToString();
            }
            
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            
            if (lstBrandName.SelectedItems.Count > 0)
            {
                brand.DeleteBrand(lstBrandName.SelectedItem.ToString().Trim());
                brand.LoadBrandsIntoListBox(lstBrandName);
            }
        }
    }
}
