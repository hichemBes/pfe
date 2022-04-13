using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryFunction> CategoryFunction { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<FunctionofUser> FunctionofUser { get; set; }
        public DbSet<PieceJoint> Pieces { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<typerequestCatg> typerequestCatg { get; set; }

        public DbSet<typeRequest> typeRequests { get; set; }
        public DbSet<Organisme> Organisme{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Settings: set Primary keys
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<CategoryFunction>().HasKey(c => c.CategoryFunctionid);
            modelBuilder.Entity<Function>().HasKey(c => c.IdFunction);
            modelBuilder.Entity<FunctionofUser>().HasKey(c => c.IdFunctionofUser);
            modelBuilder.Entity<PieceJoint>().HasKey(c => c.PieceId);
            modelBuilder.Entity<Request>().HasKey(c => c.RequestId);
        
            modelBuilder.Entity<typeRequest>().HasKey(c => c.RequestTypeId);
            modelBuilder.Entity<typerequestCatg>().HasKey(c => c.typerequestCatgID);
            modelBuilder.Entity<Organisme>().HasKey(c => c.OrganismeId);
            #endregion
            #region Settings: set one to many relations
            modelBuilder.Entity<CategoryFunction>()
                .HasOne(r => r.Category)
                .WithMany(n => n.CategoryFunction)
                .HasForeignKey(x => x.Fk_CategoryId);
            modelBuilder.Entity<CategoryFunction>()
                .HasOne(r => r.Function)
                .WithMany(n => n.CategoryFunction)
                .HasForeignKey(x => x.Fk_IdFunction);
            modelBuilder.Entity<FunctionofUser>().HasOne(r => r.Function)
                .WithMany(n => n.FunctionofUsers)
                .HasForeignKey(n => n.Fk_Function);
            modelBuilder.Entity<Request>()
                                           .HasOne(r => r.RequestType)
                                           .WithMany(n => n.Requests)
                                           .HasForeignKey(n => n.fk_RequestType);

            modelBuilder.Entity<Request>()
                                 .HasOne(r => r.Organisme)
                                 .WithMany(n => n.Requests)
                                 .HasForeignKey(n => n.fk_Organisme);
            modelBuilder.Entity<PieceJoint>()
                                    .HasOne(r => r.Requests)
                                    .WithMany(n => n.Pieces)
                                    .HasForeignKey(n => n.fk_Request);
            

            modelBuilder.Entity<typerequestCatg>()
                                    .HasOne(r => r.Category)
                                    .WithMany(n => n.typerequestCatgories)
                                    .HasForeignKey(n => n.Fk_CategoryId);
            modelBuilder.Entity<typerequestCatg>()
                                .HasOne(r => r.typeRequest)
                                .WithMany(n => n.typerequestCatgories)
                                .HasForeignKey(n => n.FK_typeRequest);
            #endregion

        }
    }
}