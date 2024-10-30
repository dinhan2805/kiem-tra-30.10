using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ShoppingCart shoppingCart = new ShoppingCart();
        private List<Product> productList = new List<Product>();
        public Form1()
        {
            InitializeComponent();
            LoadProducts();
            UpdateDataGridView();
        }
        private void LoadProducts()
        {
            productList.Add(new Product("Sản phẩm 1", 20, null, 1));
            productList.Add(new Product("Sản phẩm 2", 15, null, 1));
            productList.Add(new Product("Sản phẩm 3", 30, null, 1));
            productList.Add(new Product("Sản phẩm 4", 55, null, 1));
            productList.Add(new Product("Sản phẩm 5", 17, null, 1));
            productList.Add(new Product("Sản phẩm 6", 14, null, 1));
        }
        private void UpdateDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = productList;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm từ danh sách.");
                return;
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedProduct = (Product)dataGridView1.SelectedRows[0].DataBoundItem;
                var existingProduct = shoppingCart.GetProducts().FirstOrDefault(p => p.Name == selectedProduct.Name);

                if (existingProduct != null)
                {
                    existingProduct.Quantity++;
                }
                else
                {
                    shoppingCart.AddProduct(new Product(selectedProduct.Name, selectedProduct.Price, selectedProduct.Image, 1));
                }

                // Cập nhật giỏ hàng
                UpdateCart();
            }
        }
        private void UpdateCart()
        {
            listBox1.DataSource = null; // Đặt lại nguồn dữ liệu
            listBox1.DataSource = shoppingCart.GetProducts(); // Cập nhật nguồn dữ liệu mới
            listBox1.DisplayMember = "Name"; // Hiển thị tên sản phẩm trong ListBox

            textBox1.Text = shoppingCart.GetTotalQuantity().ToString();
            textBox2.Text = shoppingCart.GetTotalPrice().ToString("C");
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thanh toán không?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                shoppingCart.Clear();
                UpdateCart();
                MessageBox.Show("Đơn hàng đã được hoàn tất!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                var selectedProduct = (Product)listBox1.SelectedItem;

                // Giảm số lượng sản phẩm
                if (selectedProduct.Quantity > 1)
                {
                    selectedProduct.Quantity--;
                }
                else
                {
                    // Nếu số lượng bằng 1, xóa sản phẩm khỏi giỏ hàng
                    shoppingCart.RemoveProduct(selectedProduct);
                }

                // Cập nhật giỏ hàng
                UpdateCart();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra nếu hàng được chọn hợp lệ
            {
                var selectedProduct = (Product)dataGridView1.Rows[e.RowIndex].DataBoundItem;
            }
        }
    }
}
