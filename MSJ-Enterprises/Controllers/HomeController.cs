using Microsoft.AspNetCore.Mvc;
using MSJ_Enterprises.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace MSJ_Enterprises.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            return this.CheckUserLogin("Index");
        }

      
        private IActionResult CheckUserLogin(string viewName)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
              

            }
            

            return View(viewName);
        }

      



        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("Email") != null)
            {
                HttpContext.Session.Remove("Email");
                HttpContext.Session.Remove("Role");
                return RedirectToAction("Login", "Home");
            }
            else
            {
                ViewBag.LoginError = "Login Failed";
                return View();
            }




        }





        private bool IsUserAdmin()
        {
            return HttpContext.Session.GetString("Role") == "Admin";
        }




        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            var UserLogin = context.login.Where(a => a.Email == login.Email && a.Password == login.Password && a.Role == login.Role).FirstOrDefault();

            if (UserLogin != null)
            {
                HttpContext.Session.SetString("Email", UserLogin.Email);
                HttpContext.Session.SetString("Role", UserLogin.Role);

             
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.LoginError = "Login Failed";
                return View();
            }
        }



        public async Task<IActionResult> Users()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");

                

            }
            if (!IsUserAdmin())
            {
                return RedirectToAction("Oops");
            }

            var users = await context.login.ToListAsync();
            return View(users);
        }

        public async Task<IActionResult> UserReport()
        {

            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var users = await context.login.ToListAsync();
            return View(users);
        }



        [HttpGet]
        public async Task<IActionResult> AddUser()
        {

            if (!IsUserAdmin())
            {
                return RedirectToAction("Oops");
            }

            return this.CheckUserLogin("AddUser");
           

        }


        [HttpPost]
        public async Task<IActionResult> Adduser(Login login)
        {
            if (ModelState.IsValid)
            {
                await context.login.AddAsync(login);
                await context.SaveChangesAsync();
                return RedirectToAction("Users", "Home");
            }
            return View(login);
        }








        public IActionResult Oops()
        {
            return this.CheckUserLogin("Oops");

        }



        public IActionResult Transcation()
        {
            return this.CheckUserLogin("Transcation");
  
        }
        public IActionResult Reports()
        {
            return this.CheckUserLogin("Reports");
        }
        public IActionResult Accounts()
        {
            return this.CheckUserLogin("Accounts");
        }
        public IActionResult Master()
        {
            return this.CheckUserLogin("Master");
        }
        [HttpGet]
        public async Task<IActionResult> CustomerSetup()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            if (!IsUserAdmin())
            {
                return RedirectToAction("Oops");
            }




            var customer = await context.customers.ToListAsync();    
            return View(customer);
        }
        public async Task<IActionResult> CustomerReport()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var customer = await context.customers.ToListAsync();
            return View(customer);
        }


        [HttpGet]
        public async Task<IActionResult> AddCustomer()
        {
            if (!IsUserAdmin())
            {
                return RedirectToAction("Oops");
            }

            return this.CheckUserLogin("AddCustomer");
        }


        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customers customers)
        {
            if (ModelState.IsValid)
            {
                await context.customers.AddAsync(customers);
                await context.SaveChangesAsync();
                return RedirectToAction("CustomerSetup", "Home");
            }
            return View(customers);
        }



        [HttpGet]
        public async Task<IActionResult> ItemSetup()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            if (!IsUserAdmin())
            {
                return RedirectToAction("Oops");
            }

            var item = await context.items.ToListAsync();
            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> ItemReport()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            var item = await context.items.ToListAsync();
            return View(item);
        }



        [HttpGet]
        public async Task<IActionResult> AddItem()
        {
            if (!IsUserAdmin())
            {
                return RedirectToAction("Oops");
            }

            return this.CheckUserLogin("AddItem");
        }


        [HttpPost]
        public async Task<IActionResult> AddItem(Item item)
        {
            if (ModelState.IsValid)
            {
               await context.items.AddAsync(item);
                await context.SaveChangesAsync();
                return RedirectToAction("ItemSetup", "Home");
            }
            return View(item);
            
        }
        [HttpGet]
        public async Task<IActionResult> EditItem(int? id)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            if (!IsUserAdmin())
            {
                return RedirectToAction("Oops");
            }

            var item = await context.items.Where(x => x.Iid == id).FirstOrDefaultAsync();


            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> EditItem(Item item, int? id)
        {
            if(ModelState.IsValid)
            {
                 context.items.Update(item);
                await context.SaveChangesAsync();
                return RedirectToAction("ItemSetup", "Home");
            }
            return View(item);
        }
        [HttpGet]
        public async Task<IActionResult> EditCustomer(int? id)
        {

            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            if (!IsUserAdmin())
            {
                return RedirectToAction("Oops");
            }

            var customer = await context.customers.Where(x => x.Cid == id).FirstOrDefaultAsync();


            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomer(Customers customers, int? id)
        {
            if (ModelState.IsValid)
            {
                context.customers.Update(customers);
                await context.SaveChangesAsync();
                return RedirectToAction("CustomerSetup", "Home");
            }
            return View(customers);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteItem(int? id)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            var item = await context.items.Where(x => x.Iid == id).FirstOrDefaultAsync();

            if (item != null)
            {
                context.items.Remove(item);
            }

            await context.SaveChangesAsync();
            return RedirectToAction("ItemSetup", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> DeleteCustomer(int? id)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            var customer = await context.customers.Where(x => x.Cid == id).FirstOrDefaultAsync();

            if (customer != null)
            {
                context.customers.Remove(customer);
            }

            await context.SaveChangesAsync();
            return RedirectToAction("CustomerSetup", "Home");
        }

        public async Task<IActionResult> DeleteEntry(int? id)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            var Bank = await context.bank.Where(x => x.Tid == id).FirstOrDefaultAsync();

            if (Bank != null)
            {
                context.bank.Remove(Bank);
            }

            await context.SaveChangesAsync();
            return RedirectToAction("ViewEntry", "Home");
        }







        public  IActionResult Voucher(int? id)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
          

            var Voucher =  context.bank.Include(i => i.Customers).FirstOrDefault(i => i.Tid == id);

            if (Voucher == null)
            {
                return NotFound();
            }

            return View("Voucher", Voucher);
        }









        public async Task<IActionResult> PurDetails(int? id)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            if (!IsUserAdmin())
            {
                return RedirectToAction("Oops");
            }

            var item = await context.PurchaseItem.Include(pi => pi.Item).Where(pi => pi.PurchaseInvoice.ID == id).ToListAsync();

            if (item == null || !item.Any())
            {
                return NotFound();
            }
            return View(item);
        }


        public async Task<IActionResult> PurPreview(int? id)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            var item = await context.PurchaseItem.Include(pi => pi.Item).Where(pi => pi.PurchaseInvoice.ID == id).ToListAsync();

            if (item == null || !item.Any())
            {
                return NotFound();
            }
            return View(item);
        }


        public async Task<IActionResult> SaleDetail(int? id)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            var item = await context.saleItems.Include(pi => pi.Item).Where(pi => pi.SaleInvoice.ID == id).ToListAsync();

            if (item == null || !item.Any())
            {
                return NotFound();
            }
            return View(item);
        }



        public async Task<IActionResult> PurReport()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var invoices = await context.PurchaseInvoice.Include(si => si.PurchaseItems).Include(si => si.Customers).ToListAsync();

            return View(invoices);
        }






        public async Task<IActionResult> SaleReport()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            var invoices = await context.invoices.Include(si => si.SaleItems).Include(si => si.Customers).ToListAsync();

            return View(invoices);
       
        }



        






        [HttpGet]

        public async Task<IActionResult> Debit()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            var customersTb = await context.customers.ToListAsync();
            ViewBag.CustomerSL = new List<SelectListItem>();
            foreach (var customer in customersTb)
            {
                ViewBag.CustomerSL.Add(
                    new SelectListItem
                    {
                        Value = customer.Cid.ToString(),
                        Text = customer.Name
                    });
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Debit(Bank bank)
        {
            if (ModelState.IsValid) { 
            await context.bank.AddAsync(bank);
                await context.SaveChangesAsync();
                return RedirectToAction("ViewEntry", "Home");
            
            }
            return View(bank);
        }




        [HttpGet]
        public async Task<IActionResult> Credit()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            var customersTb = await context.customers.ToListAsync();
            ViewBag.CustomerSL = new List<SelectListItem>();
            foreach (var customer in customersTb)
            {
                ViewBag.CustomerSL.Add(
                    new SelectListItem
                    {
                        Value = customer.Cid.ToString(),
                        Text = customer.Name
                    });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Credit(Bank bank)
        {
            if (ModelState.IsValid)
            {
                await context.bank.AddAsync(bank);
                await context.SaveChangesAsync();
                return RedirectToAction("ViewEntry", "Home");

            }
            return View(bank);


        }

        public async Task<IActionResult> ViewEntry()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }

            var entry = await context.bank.Include(b => b.Customers).ToListAsync();

            return View(entry);
        }
        public async Task<IActionResult> ShowSaleInvoices()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            if (!IsUserAdmin())
            {
                return RedirectToAction("Oops");
            }

            var invoices = await context.invoices.Include(si => si.SaleItems).Include(si => si.Customers).ToListAsync();

            return View(invoices);
       
        }

        

        public async Task<IActionResult> BankReport()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            var entry = await context.bank.Include(b => b.Customers).ToListAsync();

            return View(entry);
        }

        [HttpGet]
        public async Task<IActionResult> SaleInvoice()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            if (!IsUserAdmin())
            {
                return RedirectToAction("Oops");
            }

            var viewModel = new SaleInvoiceViewModel
            {
                SaleInvoiceItems = new List<SaleInvoiceItemViewModel>
            {
                new SaleInvoiceItemViewModel() // At least one item to start with
            }
            };


            ViewData["Customers"] = new SelectList(context.customers, "Cid", "Name");
            ViewData["Items"] = new SelectList(context.items, "Iid", "Name");
            return View(viewModel);
        }
            [HttpPost]
            public  async Task<IActionResult> SaleInvoice(SaleInvoiceViewModel model)
            {
            if (ModelState.IsValid)
            {
                var saleInvoice = new SaleInvoice
                {
                    Date = model.Date,
                    CustomerId = model.CustomerId,
                    Total = model.Total,
                    SaleItems = model.SaleInvoiceItems.Select(i => new SaleItem
                    {
                        ItemID = i.ItemId,
                        Qty = i.Quantity,
                        Rate = i.Rate,
                        Discount = i.Discount,
                        Amount = i.Amount
                       
                        
                    }).ToList()
                };

                context.invoices.Add(saleInvoice);
                await context.SaveChangesAsync();

                return RedirectToAction("ShowSaleInvoices");
            }

            ViewBag.Customers = new SelectList(context.customers, "CustomerId", "CustomerName");
            ViewBag.Items = new SelectList(context.items, "ItemId", "ItemName");

            return View(model);
        }







        public  IActionResult Print(int id)
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            if (!IsUserAdmin())
            {
                return RedirectToAction("Oops");
            }

            var invoice = context.invoices.Include(i => i.Customers).Include(i => i.SaleItems).ThenInclude(sii => sii.Item).FirstOrDefault(i => i.ID == id);

            if (invoice == null)
            {
                return NotFound();
            }

            return View("Print", invoice);
        }

        [HttpGet]

        public async Task<IActionResult> PurchaseInvoice()
        {
            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            if (!IsUserAdmin())
            {
                return RedirectToAction("Oops");
            }

            var viewModel = new PurchaseInvoiceModel
            {
                PurchaseItemModels = new List<PurchaseItemModel>
            {
                new PurchaseItemModel() // At least one item to start with
            }
            };


            ViewData["Customers"] = new SelectList(context.customers, "Cid", "Name");
            ViewData["Items"] = new SelectList(context.items, "Iid", "Name");
            return View(viewModel);

        }


        [HttpPost]

        public async Task<IActionResult> PurchaseInvoice(PurchaseInvoiceModel model)
        {
            if (ModelState.IsValid)
            {
                var purchase = new PurchaseInvoice
                {
                    Date = model.Date,
                    CustomerId = model.CustomerId,
                    PurchaseItems = model.PurchaseItemModels.Select(i => new PurchaseItem
                    {
                        ItemID = i.ItemId,
                        Qty = i.Quantity,
                        Rate = i.Rate,
                        Discount = i.Discount,
                        Amount = i.Amount
                    }).ToList()
                };

                context.PurchaseInvoice.Add(purchase);
                await context.SaveChangesAsync();

                return RedirectToAction("ShowPurchaseInvoices");
            }

            ViewBag.Customers = new SelectList(context.customers, "CustomerId", "CustomerName");
            ViewBag.Items = new SelectList(context.items, "ItemId", "ItemName");

            return View(model);
        }




        public async Task<IActionResult> ShowPurchaseInvoices()
        {

            if (HttpContext.Session.GetString("Email") == null)
            {
                return RedirectToAction("Login");
            }
            if (!IsUserAdmin())
            {
                return RedirectToAction("Oops");
            }

            var invoices = await context.PurchaseInvoice.Include(si => si.PurchaseItems).Include(si => si.Customers).ToListAsync();

            return View(invoices);
        }












        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
