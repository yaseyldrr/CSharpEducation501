using CSharpEducation501.Dtos;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEducation501
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(
                "Data Source=YASEMONSTER\\MSSQLSERVER01;" +
                "Initial Catalog=Education501DB;" +
                "Integrated Security=True");
        private async void btnList_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM TblProduct";
            var values = await connection.QueryAsync<ResultProductDto>(query); // mapleme
            dataGridView1.DataSource = values;
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO TblProduct" +
                " (ProductName, ProductStock, ProductPrice, ProductCategory)" +
                " VALUES (@productName, @productStock, @productPrice, @productCategory)";
            var parameters = new DynamicParameters();
            parameters.Add("@productName", txtProductName.Text);
            parameters.Add("@productStock", txtProductStock.Text);
            parameters.Add("@productPrice", txtProductPrice.Text);
            parameters.Add("@productCategory", txtProductCategory.Text);
            await connection.ExecuteAsync(query, parameters);
            MessageBox.Show("New Book Added Successfully.");

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM TblProduct WHERE ProductId = @productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", txtProductId.Text);
            await connection.ExecuteAsync(query, parameters);
            MessageBox.Show("Book Deleted Successfully.");
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            string query = "UPDATE TblProduct SET ProductName =" +
                " @productName, ProductStock = @productStock, ProductPrice =" +
                " @productPrice, ProductCategory = @productCategory " +
                "WHERE ProductId = @productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", txtProductId.Text);
            parameters.Add("@productName", txtProductName.Text);
            parameters.Add("@productStock", txtProductStock.Text);
            parameters.Add("@productPrice", txtProductPrice.Text);
            parameters.Add("@productCategory", txtProductCategory.Text);
            await connection.ExecuteAsync(query, parameters);
            MessageBox.Show("Book Updated Successfully.");
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string query1 = "SELECT Count(*) FROM TblProduct";  
            var count = await connection.QueryFirstOrDefaultAsync<int>(query1);
            lblTotalProduct.Text = count.ToString();


            string query2 = "SELECT ProductName FROM TblProduct Where" +
                " ProductPrice = (Select Max(ProductPrice) From TblProduct)" ;
            var maxPrice = await connection.QueryFirstOrDefaultAsync<string>(query2);
            lblMaxProduct.Text = maxPrice.ToString();

            string query3 = "SELECT Count(Distinct(ProductCategory)) From TblProduct;";
            var categoryCount = await connection.QueryFirstOrDefaultAsync<int>(query3);
            lblCategoryCount.Text = categoryCount.ToString();




        }

        //string query = "DELETE FROM TblProduct WHERE ProductId = @productId";
        //var parameters = new DynamicParameters();
        //parameters.Add("@productId", txtProductId.Text);
    }
}
