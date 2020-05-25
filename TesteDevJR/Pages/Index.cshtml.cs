using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TesteDevJR.Repository;

namespace TesteDevJR.Pages.Cidade
{
    public class IndexModel : PageModel
    {
        ICidadeRepository _cidadeRepository;
        public IndexModel(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        [BindProperty]
        public List<Entities.Cidade> ListaCidades { get; set; }
        public List<Entities.Cidade> ListaCidadesPorUF { get; set; }

        [BindProperty]
        public Entities.Cidade Cidade { get; set; }

        [TempData]
        public string Message { get; set; }

        public void OnGet()
        {
            ListaCidades = _cidadeRepository.GetCidades();
            ListaCidadesPorUF = _cidadeRepository.GetCidadesPorUF();
        }

        public IActionResult OnPostDelete(int id)
        {
            if (id > 0)
            {
                var count = _cidadeRepository.Delete(id);
                if (count > 0)
                {
                    Message = "Cidade deletada com sucesso!!";
                    return RedirectToPage("/index");
                }
            }
            return Page();
        }


    }
}