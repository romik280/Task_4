﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using WindowsService.DAL.Entities;
using WindowsService.DAL.EntityFramework;
using WindowsService.DAL.Interfaces;

namespace WindowsService.DAL.Repositories
{
    public class ProductRepository: IRepository<Product>
    {
        private SalesContext db;

        public ProductRepository(SalesContext context)
        {
            db = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> Find(Func<Product, Boolean> predicate)
        {
            return db.Products.Where(predicate).ToList();
        }

        public void Create(Product item)
        {
            db.Products.Add(item);
        }

        public void Update(Product item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Product item = db.Products.Find(id);
            db.Products.Remove(item);
        }
    }
}