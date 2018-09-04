﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using Products.Models;


namespace DAL
{
    public class DBOperations : IDBOperations
    {
        private SqlCommand cmd;
        private SqlConnection conn;
        private SqlDataAdapter adp;
        private string connStr = @"Data Source=DESKTOP-BUVPTNA\;Initial Catalog=registration;Integrated Security=True";
        /// <summary>
        /// This method is used for add product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public int AddProduct(Product product)
        {
            using (conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("spAddProduct", conn);
                cmd.CommandType = CommandType.StoredProcedure;
               
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                cmd.Parameters.AddWithValue("@ProductCategoryId", product.ProductCategoryId);
                DateTime currentDate = DateTime.Now;
                string time = currentDate.ToString();
                cmd.Parameters.AddWithValue("@DateCreated", time);
                var result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                return result;
            }
        }

      //To view all product details 
        public IEnumerable<Product> GetProduct()
        {

            using (conn = new SqlConnection(connStr))
            {
                List<Product> allProduct = new List<Product>();
                SqlCommand command = new SqlCommand("SELECT * FROM Product ", conn);
              
                conn.Open();
                SqlDataReader rd = command.ExecuteReader();
                while (rd.Read())
                {
                    allProduct.Add(new Product()
                    {
                        ProductID = Convert.ToInt32(rd["ProductID"]),
                        ProductName = rd["ProductName"].ToString(),
                        ProductPrice = Convert.ToInt32(rd["ProductPrice"]),
                        ProductCategoryId = Convert.ToInt32(rd["ProductCategoryId"]),
                        DateCreated = rd["DateCreated"].ToString()
                    });
                }
                if (allProduct.Count > 0)
                {
                    return allProduct;
                }
                
                return null;
            }  
        }
        /// <summary>
        /// This method is used to get particular product detail
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public Product GetProductID(int productID)
        {
            using (conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "SELECT * FROM Product where ProductID ="+productID;
                cmd = new SqlCommand(query,conn);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    return new Product
                    {
                        ProductID = Convert.ToInt32(dr[0]),
                        ProductName = dr["ProductName"].ToString(),
                        ProductPrice = Convert.ToInt32(dr["ProductPrice"]),
                        ProductCategoryId = Convert.ToInt32(dr["ProductCategoryId"]),
                        DateCreated = dr["DateCreated"].ToString()

                    };
                }
                return null;
            }
        }
        //To update products
        public void UpdateProduct(Product product)
        {
            using (conn = new SqlConnection(connStr))
            {
                product.DateCreated = DateTime.Now.ToString();
                conn.Open();
                string query = "UPDATE Product SET " +
                    "ProductName ='" + product.ProductName +
                    "', ProductPrice = " + product.ProductPrice +
                    ", ProductCategoryId =" + product.ProductCategoryId +
                    ", DateCreated ='" + product.DateCreated
                    + "' where ProductID =" + product.ProductID;

                cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();

            }
        }
        //To delete products
        public void DeleteProductID(int productID)
        {
            using (conn = new SqlConnection(connStr))
            {
                conn.Open();
                string query = "DELETE FROM Product where ProductID = " + productID;
                cmd = new SqlCommand(query, conn);
                SqlDataReader dr = cmd.ExecuteReader();
            }

        }
    }


}

