using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        private readonly PizzaService _service; // PizzaService のインスタンスを受け取るための変数
        public IList<Pizza> PizzaList { get;set; } = default!; // ピザ一覧を格納するプロパティ

        public PizzaListModel(PizzaService service) // コンストラクタで PizzaService を受け取る
        {
            _service = service;
        }

        public void OnGet() // ページが要求されたときに呼ばれるメソッド
        {
            PizzaList = _service.GetPizzas();
        }
        [BindProperty] // フォームから送信されたデータをバインドするプロパティ
        public Pizza NewPizza { get; set; } = default!; // 新しいピザを格納するプロパティ

        public IActionResult OnPost() // フォームが送信されたときに呼ばれるメソッド
        {
            if (!ModelState.IsValid || NewPizza == null)
            {
                return Page();
            }

            _service.AddPizza(NewPizza); // PizzaService を使って新しいピザを追加

            return RedirectToAction("Get");
        }
        public IActionResult OnPostDelete(int id) // ピザ削除のフォームが送信されたときに呼ばれるメソッド
        {
            _service.DeletePizza(id); // PizzaService を使ってピザを削除
            return RedirectToAction("Get");
        }
    }
}
