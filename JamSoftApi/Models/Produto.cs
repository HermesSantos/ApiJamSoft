namespace JamSoftApi.Models
{
    //estrtuturaçao do modelo para o controller
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Valor_Unitario { get; set; }
        public int Qtd_Estoque { get; set; }

    }
}