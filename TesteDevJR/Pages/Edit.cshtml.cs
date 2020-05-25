using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TesteDevJR.Repository;

namespace TesteDevJR.Pages.Cidade
{
    public class EditModel : PageModel
    {
        ICidadeRepository _cidadeRepository;

        public EditModel(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        [BindProperty]
        public Entities.Cidade Cidade { get; set; }

        public void OnGet(int id)
        {
            Cidade = _cidadeRepository.Get(id);
        }

        public IActionResult OnPost()
        {
            var dados = Cidade;
            if (ModelState.IsValid)
            {
                var count = _cidadeRepository.Edit(dados);
                if (count > 0)
                {
                    return RedirectToPage("/Index");
                }
            }
            return Page();
        }
    }
}