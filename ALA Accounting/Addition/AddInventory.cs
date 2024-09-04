using ALA_Accounting.Addition_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ALA_Accounting.Addition
{
    public partial class AddInventory : Form
    {
        MainInventoryCatagory inventoryCatagory=new MainInventoryCatagory();
        subInventoryCatagory subInventoryCatagory = new subInventoryCatagory();
        InventoryItems inventoryItems = new InventoryItems();
        Brand brand= new Brand();  

        bool isEditing = true;
        

        public AddInventory()
        {
            InitializeComponent();
        }

        

        private void btn_addNewMainCata_Click(object sender, EventArgs e)
        {
            isEditing = false;

            txt_inventoryCataId.Text = inventoryCatagory.GetNextInventoryCategoryID().ToString();

            txt_inventoryCataName.Clear();

            // disabling add button
            btn_addNewMainCata.Enabled = false;
            btn_deleteMainCata.Enabled = false;

            btn_addNewSubCata.Enabled = false;
            btn_saveSubCata.Enabled = false;
            btn_cancelSubCata.Enabled = false;
            btn_deleteSubCata.Enabled = false;

            btn_addNewItem.Enabled = false;
            btn_saveItem.Enabled = false;
            btn_cancelItem.Enabled = false;
            btn_deleteItem.Enabled = false;
        }

        private void btn_saveMainCata_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                if (ValidateMainInventoryCategoryForm(true, false))
                {
                    inventoryCatagory.UpdateInventoryCategory(int.Parse(txt_inventoryCataId.Text), txt_inventoryCataName.Text);
                    loadInventory(true, false, false);

                    btn_addNewMainCata.Enabled=true;
                    btn_deleteMainCata.Enabled = true;

                    btn_addNewSubCata.Enabled = true;
                    btn_saveSubCata.Enabled = true;
                    btn_cancelSubCata.Enabled = true;
                    btn_deleteSubCata.Enabled = true;

                    btn_addNewItem.Enabled = true;
                    btn_saveItem.Enabled = true;
                    btn_cancelItem.Enabled = true;
                    btn_deleteItem.Enabled = true;
                }
            }
            else
            {
                if(ValidateMainInventoryCategoryForm(false,false))
                {
                    inventoryCatagory.SaveInventoryCategory(txt_inventoryCataName.Text.Trim());

                    loadInventory(true, false, false);

                    btn_addNewMainCata.Enabled = true;
                    btn_deleteMainCata.Enabled = true;

                    btn_addNewSubCata.Enabled = true;
                    btn_saveSubCata.Enabled = true;
                    btn_cancelSubCata.Enabled = true;
                    btn_deleteSubCata.Enabled = true;

                    btn_addNewItem.Enabled = true;
                    btn_saveItem.Enabled = true;
                    btn_cancelItem.Enabled = true;
                    btn_deleteItem.Enabled = true;

                    isEditing = true;
                }
            }
        }

        private void loadInventory(bool main, bool sub, bool item) // load catagories and items in list box
        {
            if (main)
            {
                inventoryCatagory.LoadInventoryCategoriesIntoListBox(lstInventoryCatagory);
            }

            if (sub)
            {
                subInventoryCatagory.LoadSubInventoryCategoriesIntoListBox(lstInventorySubCatagory, txt_inventoryCataId.Text.Trim());
            }

            if (item)
            {
                inventoryItems.LoadItemsIntoListBox(lstInventoryItems, txt_inventorySubCataId.Text.Trim());
            }
                
        } 

        private void AddInventory_Load(object sender, EventArgs e)
        {
            loadInventory(true, false, false);

            btn_cancelMainCata_Click(sender, e);

            loadInventory(false, true, false);

            btn_cancelSubCata_Click(sender,e);

            loadInventory(false, false, true);

            btn_cancelItem_Click(sender, e);


        }

        private void btn_cancelMainCata_Click(object sender, EventArgs e)
        {
            btn_addNewMainCata.Enabled = true;
            btn_deleteMainCata.Enabled = true;

            btn_addNewSubCata.Enabled = true;
            btn_saveSubCata.Enabled = true;
            btn_cancelSubCata.Enabled = true;
            btn_deleteSubCata.Enabled = true;

            btn_addNewItem.Enabled = true;
            btn_saveItem.Enabled = true;
            btn_cancelItem.Enabled = true;
            btn_deleteItem.Enabled = true;

            isEditing =true;

            if (lstInventoryCatagory.Items.Count==0)
            {
                txt_inventoryCataId.Clear();
                txt_inventoryCataName.Clear();
                return;
            }

            lstInventoryCatagory.SelectedIndex = 0;

            

            txt_inventoryCataName.Text=lstInventoryCatagory.SelectedItem.ToString();

            txt_inventoryCataId.Text = inventoryCatagory.GetInventoryCategoryIDByName(txt_inventoryCataName.Text.Trim()).ToString();

            
        }

        private void btn_deleteMainCata_Click(object sender, EventArgs e)
        {
            if (ValidateMainInventoryCategoryForm(false, true))
            {
                inventoryCatagory.DeleteInventoryCategory(int.Parse(txt_inventoryCataId.Text));
                loadInventory(true, false, false);

            }
        }

        private bool ValidateMainInventoryCategoryForm(bool isEditing = false, bool isDeleting = false)
        {
            // If deleting, check that a category ID is selected
            if (isDeleting)
            {
                if (string.IsNullOrWhiteSpace(txt_inventoryCataId.Text))
                {
                    MessageBox.Show("براہ کرم حذف کرنے کے لیے کوئی کیٹیگری منتخب کریں", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            // If saving or updating, ensure the category name is filled
            if (!isDeleting)
            {
                if (string.IsNullOrWhiteSpace(txt_inventoryCataName.Text))
                {
                    MessageBox.Show("براہ کرم مین انوینٹری کیٹیگری کا نام درج کریں", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_inventoryCataName.Focus();
                    return false;
                }

                if (isEditing && string.IsNullOrWhiteSpace(txt_inventoryCataId.Text))
                {
                    MessageBox.Show("براہ کرم اپ ڈیٹ کرنے کے لیے کوئی کیٹیگری منتخب کریں", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }

        private void lstInventoryCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lstInventoryCatagory.Items.Count > 0)
            {
                txt_inventoryCataName.Text = lstInventoryCatagory.SelectedItem.ToString();

                txt_inventoryCataId.Text = inventoryCatagory.GetInventoryCategoryIDByName(txt_inventoryCataName.Text.Trim()).ToString();

                loadInventory(false, true, false);

                btn_cancelSubCata_Click(sender, e);

                loadInventory(false, false, true);

                btn_cancelItem_Click(sender, e);
            }
        }





        // sub catagory

        private bool ValidateSubInventoryCategoryForm(bool isEditing = false, bool isDeleting = false)
        {
            // If deleting, check that a sub-category ID is selected
            if (isDeleting)
            {
                if (string.IsNullOrWhiteSpace(txt_inventorySubCataId.Text))
                {
                    MessageBox.Show("براہ کرم حذف کرنے کے لیے کوئی سب کیٹیگری منتخب کریں", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            // If saving or updating, ensure the sub-category name is filled
            if (!isDeleting)
            {
                if (string.IsNullOrWhiteSpace(txt_inventorySubCataName.Text))
                {
                    MessageBox.Show("براہ کرم سب انوینٹری کیٹیگری کا نام درج کریں", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_inventorySubCataName.Focus();
                    return false;
                }

                if (isEditing && string.IsNullOrWhiteSpace(txt_inventorySubCataId.Text))
                {
                    MessageBox.Show("براہ کرم اپ ڈیٹ کرنے کے لیے کوئی سب کیٹیگری منتخب کریں", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            // Ensure an inventory category ID is selected for both saving and updating
            if (!isDeleting && string.IsNullOrWhiteSpace(txt_inventoryCataId.Text))
            {
                MessageBox.Show("براہ کرم ایک مین کیٹیگری منتخب کریں", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void btn_addNewSubCata_Click(object sender, EventArgs e)
        {
            isEditing = false;

            txt_inventorySubCataId.Text = subInventoryCatagory.GetNextSubInventoryCategoryID().ToString();

            txt_inventorySubCataName.Clear();
            txt_inventorySubCataName.Focus();

            btn_addNewSubCata.Enabled = false;
            btn_deleteSubCata.Enabled = false;

            btn_addNewItem.Enabled = false;
            btn_saveItem.Enabled = false;
            btn_cancelItem.Enabled = false;
            btn_deleteItem.Enabled = false;

            btn_addNewMainCata.Enabled = false;
            btn_deleteMainCata.Enabled = false;
            btn_saveMainCata.Enabled = false;
            btn_cancelMainCata.Enabled = false;
        }

        private void btn_saveSubCata_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                if (ValidateSubInventoryCategoryForm(true, false))
                {
                    subInventoryCatagory.UpdateSubInventoryCategory(int.Parse(txt_inventorySubCataId.Text), txt_inventorySubCataName.Text);
                    loadInventory(false, true, false);

                    btn_addNewSubCata.Enabled = true;
                    btn_deleteSubCata.Enabled = true;

                    btn_addNewItem.Enabled = true;
                    btn_saveItem.Enabled = true;
                    btn_cancelItem.Enabled = true;
                    btn_deleteItem.Enabled = true;

                    btn_addNewMainCata.Enabled = true;
                    btn_deleteMainCata.Enabled = true;
                    btn_saveMainCata.Enabled = true;
                    btn_cancelMainCata.Enabled = true;
                }
            }
            else
            {
                if (ValidateMainInventoryCategoryForm())
                {
                    subInventoryCatagory.SaveSubInventoryCategory(int.Parse(txt_inventoryCataId.Text), txt_inventorySubCataName.Text);
                    loadInventory(false, true, false);

                    btn_addNewSubCata.Enabled = true;
                    btn_deleteSubCata.Enabled = true;

                    btn_addNewItem.Enabled = true;
                    btn_saveItem.Enabled = true;
                    btn_cancelItem.Enabled = true;
                    btn_deleteItem.Enabled = true;

                    btn_addNewMainCata.Enabled = true;
                    btn_deleteMainCata.Enabled = true;
                    btn_saveMainCata.Enabled = true;
                    btn_cancelMainCata.Enabled = true;

                    isEditing = true;
                }
            }
        }

        private void btn_cancelSubCata_Click(object sender, EventArgs e)
        {
            btn_addNewSubCata.Enabled = true;
            btn_deleteSubCata.Enabled = true;

            btn_addNewItem.Enabled = true;
            btn_saveItem.Enabled = true;
            btn_cancelItem.Enabled = true;
            btn_deleteItem.Enabled = true;

            btn_addNewMainCata.Enabled = true;
            btn_deleteMainCata.Enabled = true;
            btn_saveMainCata.Enabled = true;
            btn_cancelMainCata.Enabled = true;

            isEditing = true;

            if (lstInventorySubCatagory.Items.Count == 0)
            {
                txt_inventorySubCataId.Clear();
                txt_inventorySubCataName.Clear();
                return;
            }

            lstInventorySubCatagory.SelectedIndex = 0;


            txt_inventorySubCataName.Text = lstInventorySubCatagory.SelectedItem.ToString();

            txt_inventorySubCataId.Text = subInventoryCatagory.GetSubInventoryCategoryIDByName(txt_inventorySubCataName.Text.Trim()).ToString();

        }

        private void btn_deleteSubCata_Click(object sender, EventArgs e)
        {
            if (ValidateSubInventoryCategoryForm(false, true))
            {
                subInventoryCatagory.DeleteSubInventoryCategory(int.Parse(txt_inventorySubCataId.Text));
                loadInventory(false, true, false);

            }
        }

        private void lstInventorySubCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstInventorySubCatagory.Items.Count > 0)
            {
                txt_inventorySubCataName.Text = lstInventorySubCatagory.SelectedItem.ToString();

                txt_inventorySubCataId.Text = subInventoryCatagory.GetSubInventoryCategoryIDByName(txt_inventorySubCataName.Text.Trim()).ToString();

                loadInventory(false, false, true);

                btn_cancelItem_Click(sender, e);
            }
        }

        private void btn_addNewItem_Click(object sender, EventArgs e)
        {
            isEditing = false;

            txt_inventoryItemId.Clear();
            txt_inventoryItemId.Focus();
            txt_inventoryItemName.Clear();

            btn_addNewItem.Enabled = false;
            btn_deleteItem.Enabled = false;

            btn_addNewSubCata.Enabled = false;
            btn_deleteSubCata.Enabled = false;
            btn_cancelSubCata.Enabled = false;
            btn_saveSubCata.Enabled = false;

            btn_addNewMainCata.Enabled = false;
            btn_deleteMainCata.Enabled = false;
            btn_saveMainCata.Enabled = false;
            btn_cancelMainCata.Enabled = false;

            ;
        }

        private void btn_saveItem_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                if (ValidateInventoryItemForm(true, false))
                {
                    inventoryItems.itemId= txt_inventoryItemId.Text.Trim();
                    inventoryItems.itemName= txt_inventoryItemName.Text.Trim();
                    inventoryItems.itemDiscription = txt_itemDiscripton.Text;
                    inventoryItems.brandName = cmbo_itemBrand.Text.Trim();
                    inventoryItems.rackNo = txt_RackNo.Text;
                    inventoryItems.purchasePrice = txt_purchasePrice.Text.Trim();
                    inventoryItems.salePrice=txt_salePrice.Text.Trim();
                    inventoryItems.measurmentUnit = txt_measurmentUnit.Text.Trim();
                    inventoryItems.reOrderQuantity = txt_reOrderQuantity.Text.Trim();

                    inventoryItems.UpdateInventoryItem(inventoryItems);

                    btn_addNewItem.Enabled = true;
                    btn_deleteItem.Enabled = true;

                    btn_addNewSubCata.Enabled = true;
                    btn_deleteSubCata.Enabled = true;
                    btn_cancelSubCata.Enabled = true;
                    btn_saveSubCata.Enabled = true;

                    btn_addNewMainCata.Enabled = true;
                    btn_deleteMainCata.Enabled = true;
                    btn_saveMainCata.Enabled = true;
                    btn_cancelMainCata.Enabled = true;


                    loadInventory(false, false, true);
                }
            }
            else
            {
                if (ValidateInventoryItemForm())
                {
                    isEditing = true;

                    inventoryItems.itemId = txt_inventoryItemId.Text.Trim();
                    inventoryItems.itemName = txt_inventoryItemName.Text.Trim();
                    inventoryItems.itemDiscription = txt_itemDiscripton.Text;
                    inventoryItems.brandName = cmbo_itemBrand.Text.Trim();
                    inventoryItems.rackNo = txt_RackNo.Text;
                    inventoryItems.purchasePrice = txt_purchasePrice.Text.Trim();
                    inventoryItems.salePrice = txt_salePrice.Text.Trim();
                    inventoryItems.measurmentUnit = txt_measurmentUnit.Text.Trim();
                    inventoryItems.reOrderQuantity = txt_reOrderQuantity.Text.Trim();
                    inventoryItems.subCatagoryId = txt_inventorySubCataId.Text.Trim();

                    inventoryItems.SaveInventoryItem(inventoryItems);

                    btn_addNewItem.Enabled = true;
                    btn_deleteItem.Enabled = true;

                    btn_addNewSubCata.Enabled = true;
                    btn_deleteSubCata.Enabled = true;
                    btn_cancelSubCata.Enabled = true;
                    btn_saveSubCata.Enabled = true;

                    btn_addNewMainCata.Enabled = true;
                    btn_deleteMainCata.Enabled = true;
                    btn_saveMainCata.Enabled = true;
                    btn_cancelMainCata.Enabled = true;

                    loadInventory(false, false, true);
                }

                
            }
        }

        private void lstInventoryItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstInventoryItems.SelectedItem != null)
            {
                if (lstInventoryItems.SelectedItem != null)
                {
                    // Cast the selected item to ListBoxItem
                    ListBoxItem selectedItem = (ListBoxItem)lstInventoryItems.SelectedItem;

                    // Use the existing inventoryItems object to fetch item details
                    inventoryItems = inventoryItems.GetItemDetailsById(selectedItem.ItemID.Trim());

                    // If the item was found, update the UI with its details
                    if (inventoryItems != null)
                    {
                        txt_inventoryItemId.Text = inventoryItems.itemId;
                        txt_inventoryItemName.Text = inventoryItems.itemName;
                        txt_itemDiscripton.Text = inventoryItems.itemDiscription;
                        cmbo_itemBrand.Text = inventoryItems.brandName;
                        txt_RackNo.Text = inventoryItems.rackNo;
                        txt_purchasePrice.Text = inventoryItems.purchasePrice;
                        txt_salePrice.Text = inventoryItems.salePrice;
                        txt_measurmentUnit.Text = inventoryItems.measurmentUnit;
                        txt_reOrderQuantity.Text = inventoryItems.reOrderQuantity;
                    }
                    else
                    {
                        MessageBox.Show("Item details could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool ValidateInventoryItemForm(bool isEditing = false, bool isDeleting = false)
        {
            // If deleting, check that an Item ID is selected
            if (isDeleting)
            {
                if (string.IsNullOrWhiteSpace(txt_inventoryItemId.Text))
                {
                    MessageBox.Show("براہ کرم حذف کرنے کے لیے کوئی آئٹم منتخب کریں", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }

            // If saving or updating, ensure the necessary fields are filled
            if (!isDeleting)
            {
                if (string.IsNullOrWhiteSpace(txt_inventoryItemId.Text))
                {
                    MessageBox.Show("براہ کرم آئٹم آئی ڈی درج کریں", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_inventoryItemId.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txt_inventorySubCataId.Text))
                {
                    MessageBox.Show("براہ کرم Sub Catagory Id درج کریں", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_inventoryItemId.Focus();
                    return false;
                }

                if (string.IsNullOrWhiteSpace(txt_inventoryItemName.Text))
                {
                    MessageBox.Show("براہ کرم آئٹم کا نام درج کریں", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_inventoryItemName.Focus();
                    return false;
                }

                // Validate prices and reorder quantity if they are provided
                if (!string.IsNullOrWhiteSpace(txt_purchasePrice.Text))
                {
                    if (!decimal.TryParse(txt_purchasePrice.Text, out decimal purchasePrice))
                    {
                        MessageBox.Show("براہ کرم خریداری کی قیمت درست عدد میں درج کریں", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_purchasePrice.Focus();
                        return false;
                    }
                }

                if (!string.IsNullOrWhiteSpace(txt_salePrice.Text))
                {
                    if (!decimal.TryParse(txt_salePrice.Text, out decimal sellingPrice))
                    {
                        MessageBox.Show("براہ کرم فروخت کی قیمت درست عدد میں درج کریں", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_salePrice.Focus();
                        return false;
                    }
                }

                if (!string.IsNullOrWhiteSpace(txt_reOrderQuantity.Text))
                {
                    if (!decimal.TryParse(txt_reOrderQuantity.Text, out decimal reOrderQuantity))
                    {
                        MessageBox.Show("براہ کرم ری آرڈر مقدار درست عدد میں درج کریں", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_reOrderQuantity.Focus();
                        return false;
                    }
                }

                if (isEditing && string.IsNullOrWhiteSpace(txt_inventoryItemId.Text))
                {
                    MessageBox.Show("براہ کرم اپ ڈیٹ کرنے کے لیے کوئی آئٹم منتخب کریں", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            return true;
        }

        private void btn_addBrand_Click(object sender, EventArgs e)
        {
            AddBrands addBrands = new AddBrands();
            addBrands.ShowDialog();
        }

        private void btn_cancelItem_Click(object sender, EventArgs e)
        {
            btn_addNewItem.Enabled = true;
            btn_deleteItem.Enabled = true;

            isEditing = true;

            if (lstInventoryItems.Items.Count == 0)
            {
                txt_inventoryItemId.Clear();
                txt_inventoryItemName.Clear();
                txt_itemDiscripton.Clear();
                cmbo_itemBrand.SelectedIndex= 0;
                txt_RackNo.Clear();
                txt_purchasePrice.Clear();
                txt_salePrice.Clear();
                txt_measurmentUnit.Clear();
                txt_reOrderQuantity.Clear();
                return;
            }

            lstInventoryItems.SelectedIndex = 0;

            lstInventoryItems_SelectedIndexChanged(sender, e);
        }

        private void AddInventory_Activated(object sender, EventArgs e)
        {
            brand.LoadBrandsIntoComboBox(cmbo_itemBrand);
        }
    }
}
