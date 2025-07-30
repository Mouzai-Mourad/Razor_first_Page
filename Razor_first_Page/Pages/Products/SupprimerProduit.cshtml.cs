using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Razor_first_Page.Datas;
using Razor_first_Page.Models;

namespace Razor_first_Page.Pages.Products
{
    public class SupprimerProduitModel : PageModel
    {
		private readonly AppDbContext _context;

		public SupprimerProduitModel(AppDbContext context)
		{
			_context = context;
		}

		[BindProperty] public Product Product { get; set; }

		public SelectList Categories { get; set; }

		public async Task<IActionResult> OnGetAsync(int id)
		{
			//Product = await _context.Products.FindAsync(id);
			Product = await _context.Products.Include(p => p.Categorie).FirstOrDefaultAsync(p => p.Id == id);
			if (Product == null)
			{
				return NotFound();
			}

			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int id)
		{
			Product = await _context.Products.FindAsync(id);

			if (Product != null)
			{
				_context.Products.Remove(Product);
				await _context.SaveChangesAsync();
			}	
			return RedirectToPage("ListProduits");
		}
    }
}
