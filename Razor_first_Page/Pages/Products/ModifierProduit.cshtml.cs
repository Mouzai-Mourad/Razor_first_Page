using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Razor_first_Page.Datas;
using Razor_first_Page.Models;

namespace Razor_first_Page.Pages.Products
{
	public class ModifierProduitModel : PageModel
	{
		private readonly AppDbContext _context;

		public ModifierProduitModel(AppDbContext context)
		{
			_context = context;
		}

		[BindProperty] public Product Product { get; set; }

		public SelectList Categories { get; set; }

		public async Task<IActionResult> OnGetAsync(int id)
		{
			Product = await _context.Products.FindAsync(id);
			if (Product == null)
			{
				return NotFound();
			}

			Categories = new SelectList(_context.Categories, "Id", "Nom");

			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			//if (!ModelState.IsValid)
			//{
			//	Categories = new SelectList(_context.Categories, "Id", "Nom", Product.CategorieId);
			//	return Page();
			//}

			//_context.Update(Product);
			//await _context.SaveChangesAsync();

			_context.Attach(Product).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return RedirectToPage("ListProduits");

		}
	}
}
