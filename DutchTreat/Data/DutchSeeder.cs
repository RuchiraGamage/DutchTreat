using DutchTreat.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Data
{
    //this class use to seed datto the database 
    public class DutchSeeder
    {
        private readonly DutchContext _context;
        private readonly IHostingEnvironment _hosting;
        private readonly UserManager<StoreUser> _userManager;

        public DutchSeeder(DutchContext context,IHostingEnvironment hosting,UserManager<StoreUser> userManager)//usermanager use to work with identity
        {
            _context = context;
            _hosting = hosting;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            _context.Database.EnsureCreated();//make sure database is exists,if not create

            StoreUser user = await _userManager.FindByEmailAsync("htruchira@gmail.com");

            if (user == null)
            {
                user = new StoreUser()
                {
                    FirstName = "Tharindu",
                    LastName = "Ruchira",
                    Email = "htruchira@gmail.com",
                    UserName = "htruchira@gmail.com"
                };

                var result = await _userManager.CreateAsync(user, "Ht@112!");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in Seeder");
                }
            }

            if (!_context.Products.Any())
            {
                //need to create sample data
                var filePath = Path.Combine(_hosting.ContentRootPath,"Data/art.json");
                var json = File.ReadAllText(filePath);
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                _context.AddRange(products);

                var order = _context.Orders.Where(o => o.Id == 1).FirstOrDefault();

                if (order != null)
                {
                    order.User = user;
                    order.Items = new List<OrderItem>()
                    {
                        new OrderItem()
                        {
                            Product=products.First(),
                            Quantity=5,
                            UnitPrice=products.First().Price
                        }
                    };
                }

                _context.SaveChanges();

            }
        }
    }
}

//we should have a way to instantiate a object of this class to seed to the database that can be done in the startup class,
//through  program.cs class