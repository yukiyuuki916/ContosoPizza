using ContosoPizza.Data;
using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public class PizzaService
    {
        private readonly PizzaContext _context = default!; //データベース操作のために使う変数

        public PizzaService(PizzaContext context) //PizzaService が生成されるときに、外から PizzaContext を注入（渡す）
        {
            _context = context;
        }
        
        public IList<Pizza> GetPizzas() //データベースからピザ一覧を取得するメソッド
        {
            if(_context.Pizzas != null)
            {
                return _context.Pizzas.ToList();
            }
            return new List<Pizza>();
        }

        public void AddPizza(Pizza pizza) //データベースにピザを追加するメソッド
        {
            if (_context.Pizzas != null)
            {
                _context.Pizzas.Add(pizza);
                _context.SaveChanges();
            }
        }

        public void DeletePizza(int id) //データベースからピザを削除するメソッド
        {
            if (_context.Pizzas != null)
            {
                var pizza = _context.Pizzas.Find(id);
                if (pizza != null)
                {
                    _context.Pizzas.Remove(pizza);
                    _context.SaveChanges();
                }
            }            
        } 
    }
}
