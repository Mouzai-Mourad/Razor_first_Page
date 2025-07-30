using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Razor_first_Page.Datas;
using Razor_first_Page.Models;

namespace Razor_first_Page.Pages.Products
{
    public class ListProduitsModel : PageModel
    {
        private readonly AppDbContext _context;

		public ListProduitsModel(AppDbContext context)
		{
			_context = context;
		}

        public List<Product> Products { get; set; }
        public string Message { get; set; }
		

		public async Task OnGetAsync()
        {
	        //AddProduct();
			//Products = await _context.Products.ToListAsync();
			Products = await _context.Products
				.Include(p => p.Categorie)
				//.Where(p => p.Prix > 50)
				//.Where(p => p.Categorie.Nom == "Electronique")
				.OrderBy(p => p.Prix)
				.AsNoTracking()
				.ToListAsync();

			//var categories = await _context.Categories
			//	.Include(c => c.Produits)	
			//	.ToListAsync();

			//string message = "";
			//foreach (var category in categories)
			//{
			//	message += category.Nom + " " + "\n";
			//	foreach (var produit in category.Produits)
			//	{
			//		message += produit.Nom + " " + "\n";
			//	}

			//	message += "\n";
			//}
			//Message = message;
		}

        public async Task<IActionResult> Return()
        {
	        List<Product> produits = await _context.Products.ToListAsync();
			return Redirect("/Products/ListProduits");
			//	return Page();
			//return BadRequest("Bad Request");
		}

        public async Task<List<Product>> Return1()
        {
	        List<Product> produits = await _context.Products.ToListAsync();
	        return produits;
        }

        public async Task<Product> Return2()
        {
	        Product produit = await _context.Products.FirstOrDefaultAsync();
	        return produit;
        }

        public async Task<Product> Return3(int id)
        {
	        Product produit = await _context.Products.FindAsync(id);
	        return produit;
        }

        public async Task<int> Return4()
        {
	        int count = await _context.Products.CountAsync();
	        return count;
        }

        public void AddProduct()
        {
	        try
	        {
				Product product = new Product();
				product.Nom = "Ordinateur Portable HP";
				product.Prix = 1000;	
				product.CategorieId = 10;
				product.Description = "Ordinateur portable";

				if(ProductExist(product.Nom))
					return;

		        _context.Products.Add(product);
				_context.SaveChanges();
			}
			catch (Exception e)
			{
				//Console.WriteLine(e);
				Message = e.Message + "\n" + e.InnerException.Message;
			}	

			//try
			//{
			//	using var transaction = _context.Database.BeginTransaction();
			//	//
			//	_context.Products.Add(product);
			//	_context.Categories.Add(new Category());
				
			//	_context.SaveChanges();	
			//	transaction.Commit();
			//}
			//catch (Exception e)
			//{
			//	_context.Database.RollbackTransaction();
			//	Console.WriteLine(e);
			//	throw;
			//}
        }

        private bool ProductExist(string name)
        {
	        return _context.Products.Any(p => p.Nom == name);
        }





		//public void OnGet()
		//{
		//    Products = _context.Products.ToList();
		//}

		//public async Task<IActionResult> OnGetAsync()
		//{
		//	Products = await _context.Products.ToListAsync();
		//	return Page();
		//}

		//public IActionResult OnGet()
		//      {
		//       Products = _context.Products.ToList();
		//       return Page();
		//}

    }
}
