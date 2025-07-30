using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Razor_first_Page.Datas;
using Razor_first_Page.Models;

namespace Razor_first_Page.Pages.Products
{
    public class AjouterProduitModel : PageModel
    { 
        private readonly AppDbContext _context;

		public AjouterProduitModel(AppDbContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Product Product { get; set; }

		public SelectList Categories { get; set; }

		public void OnGet()
		{
			Categories = new SelectList(_context.Categories, "Id", "Nom");
		}	

		public IActionResult OnPost()
		{
			try
			{
				if (ProductExist(Product.Nom))
					return Page();

				_context.Products.Add(Product);
				_context.SaveChanges();
			}
			catch (Exception e)
			{
				//Message = e.Message + "\n" + e.InnerException.Message;
			}
			return RedirectToPage("/Products/ListProduits");
		}

		private bool ProductExist(string name)
		{
			return _context.Products.Any(p => p.Nom == name);
		}
	}
}
