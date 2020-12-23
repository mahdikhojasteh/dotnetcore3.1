using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreDbSpCall.Models.DB
{
    public partial class db_core_sp_callContext : DbContext
    {
        public db_core_sp_callContext()
        {
        }

        public db_core_sp_callContext(DbContextOptions<db_core_sp_callContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDepartment> TblDepartment { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblVendor> TblVendor { get; set; }

        ////protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)  
        ////{  
        ////    if (!optionsBuilder.IsConfigured)  
        ////    {  
        ////        optionsBuilder.UseSqlServer("Server=SQL SERVER;Database=DATABASE;Trusted_Connection=True;user id=SQL USERNAME;password=SQL PASSWORD;");  
        ////    }  
        ////}  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDepartment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("tbl_department");

                entity.Property(e => e.GroupName).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("tbl_product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Color).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductNumber).IsRequired();
            });

            modelBuilder.Entity<TblVendor>(entity =>
            {
                entity.HasKey(e => e.VendorId);

                entity.ToTable("tbl_vendor");

                entity.Property(e => e.Name).IsRequired();
            });

            // [Asma Khalid]: Regster store procedure custom object.  
            modelBuilder.Query<SpGetProductByPriceGreaterThan1000>();
            modelBuilder.Query<SpGetProductByID>();
        }

        #region Get products whose price is greater than equal to 1000 store procedure method.  

        /// <summary>  
        /// Get products whose price is greater than equal to 1000 store procedure method.  
        /// </summary>  
        /// <returns>Returns - List of products whose price is greater than equal to 1000</returns>  
        public async Task<List<SpGetProductByPriceGreaterThan1000>> GetProductByPriceGreaterThan1000Async()
        {
            // Initialization.  
            List<SpGetProductByPriceGreaterThan1000> lst = new List<SpGetProductByPriceGreaterThan1000>();

            try
            {
                // Processing.  
                string sqlQuery = "EXEC [dbo].[GetProductByPriceGreaterThan1000] ";

                lst = await this.Query<SpGetProductByPriceGreaterThan1000>().FromSql(sqlQuery).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Info.  
            return lst;
        }

        #endregion

        #region Get product by ID store procedure method.  

        /// <summary>  
        /// Get product by ID store procedure method.  
        /// </summary>  
        /// <param name="productId">Product ID value parameter</param>  
        /// <returns>Returns - List of product by ID</returns>  
        public async Task<List<SpGetProductByID>> GetProductByIDAsync(int productId)
        {
            // Initialization.  
            List<SpGetProductByID> lst = new List<SpGetProductByID>();

            try
            {
                // Settings.  
                SqlParameter usernameParam = new SqlParameter("@product_ID", productId.ToString() ?? (object)DBNull.Value);

                // Processing.  
                string sqlQuery = "EXEC [dbo].[GetProductByID] " +
                                    "@product_ID";

                lst = await this.Query<SpGetProductByID>().FromSql(sqlQuery, usernameParam).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Info.  
            return lst;
        }

        #endregion
    }
}