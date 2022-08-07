using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MarketStore.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AboutFp> AboutFps { get; set; }
        public virtual DbSet<CardFp> CardFps { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryFp> CategoryFps { get; set; }
        public virtual DbSet<ContactFp> ContactFps { get; set; }
        public virtual DbSet<CourseV> CourseVs { get; set; }
        public virtual DbSet<Coursea> Courseas { get; set; }
        public virtual DbSet<Coursez> Coursezs { get; set; }
       
        public virtual DbSet<HomeFp> HomeFps { get; set; }
        public virtual DbSet<LoginFp> LoginFps { get; set; }
        public virtual DbSet<OrderFp> OrderFps { get; set; }
        public virtual DbSet<OrderProductFp> OrderProductFps { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCustomer> ProductCustomers { get; set; }
        public virtual DbSet<ProductFp> ProductFps { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleFp> RoleFps { get; set; }
        public virtual DbSet<StoreFp> StoreFps { get; set; }
        public virtual DbSet<StoreProductFp> StoreProductFps { get; set; }
        public virtual DbSet<TestimonialFp> TestimonialFps { get; set; }
        public virtual DbSet<UserFp> UserFps { get; set; }
        public virtual DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=TAH14_USER90;PASSWORD=0787sS$;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TAH14_USER90")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<AboutFp>(entity =>
            {
                entity.HasKey(e => e.AboutId)
                    .HasName("ABOUT_FP_PK");

                entity.ToTable("ABOUT_FP");

                entity.Property(e => e.AboutId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ABOUT_ID");

                entity.Property(e => e.Discription)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DISCRIPTION");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IMAGE_PATH");
            });

            modelBuilder.Entity<CardFp>(entity =>
            {
                entity.HasKey(e => e.CardId)
                    .HasName("CARD_FP_PK");

                entity.ToTable("CARD_FP");

                entity.Property(e => e.CardId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CARD_ID");

                entity.Property(e => e.Cardnumber)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CARDNUMBER");

                entity.Property(e => e.Cvv)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CVV");

                entity.Property(e => e.Palance)
                    .HasColumnType("FLOAT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PALANCE");

                entity.Property(e => e.Password)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PASSWORD");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORY_NAME");

                entity.Property(e => e.ImageBath)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IMAGE_BATH");
            });

            modelBuilder.Entity<CategoryFp>(entity =>
            {
                entity.HasKey(e => e.CatecoryId)
                    .HasName("CATEGORY_FP_PK");

                entity.ToTable("CATEGORY_FP");

                entity.Property(e => e.CatecoryId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATECORY_ID");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NAME");
            });

            modelBuilder.Entity<ContactFp>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("COCTACT_FP_PK");

                entity.ToTable("CONTACT_FP");

                entity.Property(e => e.ContactId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Taxtmassage)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TAXTMASSAGE");
            });

            modelBuilder.Entity<CourseV>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("COURSE_V");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Coursename)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COURSENAME");

                entity.Property(e => e.Datefrom)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEFROM");

                entity.Property(e => e.Dateto)
                    .HasColumnType("DATE")
                    .HasColumnName("DATETO");

                entity.Property(e => e.Mark)
                    .HasColumnType("FLOAT")
                    .HasColumnName("MARK");

                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<Coursea>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("COURSEA");

                entity.Property(e => e.Courseid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("COURSEID");

                entity.Property(e => e.Coursename)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COURSENAME");

                entity.Property(e => e.Datefrom)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEFROM");

                entity.Property(e => e.Dateto)
                    .HasColumnType("DATE")
                    .HasColumnName("DATETO");

                entity.Property(e => e.Mark)
                    .HasColumnType("FLOAT")
                    .HasColumnName("MARK");

                entity.Property(e => e.Status)
                    .HasColumnType("NUMBER")
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<Coursez>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("COURSEZ");

                entity.Property(e => e.Coursename)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COURSENAME");

                entity.Property(e => e.Mark)
                    .HasColumnType("FLOAT")
                    .HasColumnName("MARK");
            });

           

            modelBuilder.Entity<HomeFp>(entity =>
            {
                entity.HasKey(e => e.HomeId)
                    .HasName("HOME_FP_PK");

                entity.ToTable("HOME_FP");

                entity.Property(e => e.HomeId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("HOME_ID");

                entity.Property(e => e.Discription)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DISCRIPTION");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IMAGE_PATH");
            });

            modelBuilder.Entity<LoginFp>(entity =>
            {
                entity.HasKey(e => e.LoginId)
                    .HasName("LOGIN_FP_PK");

                entity.ToTable("LOGIN_FP");

                entity.Property(e => e.LoginId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NAME");

                entity.Property(e => e.Password)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.LoginFps)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("LOGIN_FP_FK1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoginFps)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("LOGIN_FP_FK2");
            });

            modelBuilder.Entity<OrderFp>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("ORDER_FP_PK");

                entity.ToTable("ORDER_FP");

                entity.Property(e => e.OrderId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.Cart)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CART");

                entity.Property(e => e.Cost)
                    .HasColumnType("FLOAT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COST");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Price)
                    .HasColumnType("FLOAT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRICE");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCT_NAME");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STORE_NAME");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("FLOAT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TOTAL_PRICE");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OrderFps)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ORDER_FP_FK1");
            });

            modelBuilder.Entity<OrderProductFp>(entity =>
            {
                entity.HasKey(e => e.OrderProductId)
                    .HasName("ORDER_PRODUCT_FP_PK");

                entity.ToTable("ORDER_PRODUCT_FP");

                entity.Property(e => e.OrderProductId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDER_PRODUCT_ID");

                entity.Property(e => e.Cart)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CART");

                entity.Property(e => e.DateOrder)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DATE_ORDER");

                entity.Property(e => e.OrderId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCT_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProductFps)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ORDER_PRODUCT_FP_FK2");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderProductFps)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("ORDER_PRODUCT_FP_FK1");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Price)
                    .HasColumnType("FLOAT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRICE");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCT_NAME");

                entity.Property(e => e.Sale)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SALE");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PRODUCT_FK1");
            });

            modelBuilder.Entity<ProductCustomer>(entity =>
            {
                entity.ToTable("PRODUCT_CUSTOMER");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.DateFrom)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DATE_FROM");

                entity.Property(e => e.DateTo)
                    .HasColumnType("DATE")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DATE_TO");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("QUANTITY");

               

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCustomers)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("PRODUCT_CUSTOMER_FK1");
            });

            modelBuilder.Entity<ProductFp>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PRODUCT_FP_PK");

                entity.ToTable("PRODUCT_FP");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NAME");

                entity.Property(e => e.Price)
                    .HasColumnType("FLOAT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRICE");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("QUANTITY");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RolesId)
                    .HasName("ROLES_PK");

                entity.ToTable("ROLES");

                entity.Property(e => e.RolesId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLES_ID");

                entity.Property(e => e.RolesName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLES_NAME");
            });

            modelBuilder.Entity<RoleFp>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("ROLE_FP_PK");

                entity.ToTable("ROLE_FP");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");
            });

            modelBuilder.Entity<StoreFp>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("STORE_FP_PK");

                entity.ToTable("STORE_FP");

                entity.Property(e => e.StoreId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STORE_ID");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NAME");

                entity.Property(e => e.Obtainsfinancial)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OBTAINSFINANCIAL");

                entity.Property(e => e.Totalsale)
                    .HasColumnType("FLOAT")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TOTALSALE");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.StoreFps)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("STORE_FP_FK1");
            });

            modelBuilder.Entity<StoreProductFp>(entity =>
            {
                entity.HasKey(e => e.StoreProductId)
                    .HasName("STORE_PRODUCT_FP_PK");

                entity.ToTable("STORE_PRODUCT_FP");

                entity.Property(e => e.StoreProductId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STORE_PRODUCT_ID");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.StoreId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STORE_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StoreProductFps)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("STORE_PRODUCT_FP_FK2");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreProductFps)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("STORE_PRODUCT_FP_FK1");
            });

            modelBuilder.Entity<TestimonialFp>(entity =>
            {
                entity.HasKey(e => e.TestimonialId)
                    .HasName("TESTIMONIAL_FP_PK");

                entity.ToTable("TESTIMONIAL_FP");

                entity.Property(e => e.TestimonialId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIAL_ID");

                entity.Property(e => e.Discription)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DISCRIPTION");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NAME");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TestimonialFps)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("TESTIMONIAL_FP_FK1");
            });

            modelBuilder.Entity<UserFp>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("CUSTOMER_FP_PK");

                entity.ToTable("USER_FP");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IMAGE_PATH");

                entity.Property(e => e.Password)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phonenumber)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PHONENUMBER");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("USER_LOGIN_PK");

                entity.ToTable("USER_LOGIN");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_NAME");

               
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("USER_LOGIN_FK2");
            });

            modelBuilder.HasSequence("ABOUT_AS_FP_SEQ");

            modelBuilder.HasSequence("ABOUT_FP_SEQ");

            modelBuilder.HasSequence("ABOUTE_AS_SEQ");

            modelBuilder.HasSequence("ADMIN_SEQ");

            modelBuilder.HasSequence("ADMIN_SEQ1");

            modelBuilder.HasSequence("ADMIN_USER_FP_SEQ");

            modelBuilder.HasSequence("ADMIN_USER_FP_SEQ1");

            modelBuilder.HasSequence("CARD_FP_SEQ");

            modelBuilder.HasSequence("CARD_FP_SEQ1");

            modelBuilder.HasSequence("CARD_FP_SEQ2");

            modelBuilder.HasSequence("CARD_FP_SEQ3");

            modelBuilder.HasSequence("CARD_FP_SEQ4");

            modelBuilder.HasSequence("CARD_SEQ");

            modelBuilder.HasSequence("CARD_SEQ1");

            modelBuilder.HasSequence("CAREANDMEDECINE_SEQ");

            modelBuilder.HasSequence("CATEGORY_FP_SEQ");

            modelBuilder.HasSequence("CATEGORY_FP_SEQ1");

            modelBuilder.HasSequence("CATEGORY_SEQ");

            modelBuilder.HasSequence("COMOANY_MUST_SEQ");

            modelBuilder.HasSequence("CONTACT_AS_FP_SEQ");

            modelBuilder.HasSequence("CONTACT_AS_SEQ");

            modelBuilder.HasSequence("CONTACT_FP_SEQ");

            modelBuilder.HasSequence("COURSE_SEQ");

            modelBuilder.HasSequence("COURSE_SEQ1");

            modelBuilder.HasSequence("CUSTOMER_FP_SEQ");

            modelBuilder.HasSequence("CUSTOMER_SEQ");

            modelBuilder.HasSequence("DEPARTMENT_SEQ");

            modelBuilder.HasSequence("DOCTOR_SEQ");

            modelBuilder.HasSequence("DOCTORPATIENT_SEQ");

            modelBuilder.HasSequence("EMPL_ADUIT2_SEQ");

            modelBuilder.HasSequence("EMPLOYEE_SEQ");

            modelBuilder.HasSequence("EMPLOYEE1_SEQ");

            modelBuilder.HasSequence("EXAM_SEQ");

            modelBuilder.HasSequence("HEMPLOYEE_SEQ");

            modelBuilder.HasSequence("HOME_FP_SEQ");

            modelBuilder.HasSequence("HOME_FP_SEQ1");

            modelBuilder.HasSequence("ITEM_MUST_SEQ");

            modelBuilder.HasSequence("LOG_IN_FP_SEQ");

            modelBuilder.HasSequence("LOGIN_FP_SEQ");

            modelBuilder.HasSequence("LOGIN_FP_SEQ1");

            modelBuilder.HasSequence("ORDER__SEQ");

            modelBuilder.HasSequence("ORDER_AND_PRODUCT_SEQ");

            modelBuilder.HasSequence("ORDER_FP_SEQ");

            modelBuilder.HasSequence("ORDER_FP_SEQ1");

            modelBuilder.HasSequence("ORDER_FP_SEQ2");

            modelBuilder.HasSequence("ORDER_FP_SEQ3");

            modelBuilder.HasSequence("ORDER_PRODUCT_FP_SEQ");

            modelBuilder.HasSequence("ORDER_PRODUCT_FP_SEQ1");

            modelBuilder.HasSequence("ORDER_PRODUCT_FP_SEQ2");

            modelBuilder.HasSequence("PATIENT_SEQ");

            modelBuilder.HasSequence("PATIENTCAREANDMIDICINE_SEQ");

            modelBuilder.HasSequence("PEOPLE_OPINIONS_SEQ");

            modelBuilder.HasSequence("POSITION_SEQ");

            modelBuilder.HasSequence("PRODUCT_CUSTOMER_SEQ");

            modelBuilder.HasSequence("PRODUCT_FP_SEQ");

            modelBuilder.HasSequence("PRODUCT_FP_SEQ1");

            modelBuilder.HasSequence("PRODUCT_FP_SEQ2");

            modelBuilder.HasSequence("PRODUCT_SEQ");

            modelBuilder.HasSequence("PRODUCT_SEQ1");

            modelBuilder.HasSequence("PROFILE_FP_SEQ");

            modelBuilder.HasSequence("REGISTER_FP_SEQ");

            modelBuilder.HasSequence("ROLES_SEQ");

            modelBuilder.HasSequence("ROOM_SEQ");

            modelBuilder.HasSequence("STORE_FP_SEQ");

            modelBuilder.HasSequence("STORE_FP_SEQ1");

            modelBuilder.HasSequence("STORE_FP_SEQ2");

            modelBuilder.HasSequence("STORE_FP_SEQ3");

            modelBuilder.HasSequence("STORE_FP_SEQ4");

            modelBuilder.HasSequence("STORE_FP_SEQ5");

            modelBuilder.HasSequence("STORE_FP_SEQ6");

            modelBuilder.HasSequence("STORE_PRODUCT_FP_SEQ");

            modelBuilder.HasSequence("TEACHER_SEQ");

            modelBuilder.HasSequence("TEACHERCOURSE_SEQ");

            modelBuilder.HasSequence("TESTIMONIAL_FP_SEQ");

            modelBuilder.HasSequence("TESTIMONIAL_FP_SEQ1");

            modelBuilder.HasSequence("TESTIMONIAL_FP_SEQ2");

            modelBuilder.HasSequence("USER__SEQ");

            modelBuilder.HasSequence("USER__SEQ1");

            modelBuilder.HasSequence("USER_CONTACT_FP_SEQ");

            modelBuilder.HasSequence("USER_FP_SEQ");

            modelBuilder.HasSequence("USER_FP_SEQ1");

            modelBuilder.HasSequence("USER_LOGIN_SEQ");

            modelBuilder.HasSequence("USER_PRODUCT_FP_SEQ");

            modelBuilder.HasSequence("USER_TASTIMONIAL_FP_SEQ");

            modelBuilder.HasSequence("WEB_SITE_SEQ");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
