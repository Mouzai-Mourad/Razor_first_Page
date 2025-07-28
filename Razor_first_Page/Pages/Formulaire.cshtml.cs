using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Razor_first_Page.Services;

namespace Razor_first_Page.Pages
{
    public class FormulaireModel : PageModel
    {
        [BindProperty]
		[Required(ErrorMessage = "Le nom est requis")]
        [StringLength(20, ErrorMessage = "Le nom ne doit pas dépasser 20 caractères")]
        public string Nom { get; set; }

		public string Message { get; set; }

        private readonly IMessageService _messageService;

		public FormulaireModel(IMessageService messageService)
		{
			_messageService = messageService;
		}


        public void OnGet()
        {
			Message = _messageService.GetMessage();
        }

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				Message = _messageService.GetMessage();
				return Page(); // Retourne la page avec les erreurs de validation si nécessai
			}
			// Traiter les données du formulaire ici
			Message = _messageService.GetMessageWithNom(Nom);
			return Page();
		}	
    }
}
