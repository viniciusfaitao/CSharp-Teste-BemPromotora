using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TesteDevJR.Repository;

namespace TesteDevJR.Pages.Cidades
{
    public class AddModel : PageModel
    {
        ICidadeRepository _cidadeRepository;

        public AddModel(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }
        [BindProperty]
        public Entities.Cidade Cidade { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var count = _cidadeRepository.Add(Cidade);
                if (count > 0)
                {
                    Message = "Nova cidade incluida com sucesso!!";
                    return RedirectToPage("/Index");
                }
            }
            return Page();
        }
    }
}