namespace Logstore.HungryPizza.Application.Pedidos
{
    public class PedidoItemDto
    {
        public int ProdutoId { get; set; }
        public string DescricaoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public int? Referencia { get; set; }
        public bool MeioPedaco => Referencia.HasValue;

        public PedidoItemDto() { }

        public PedidoItemDto(int produtoId, int quantidade, decimal valorUnitario, int? referencia)
        {
            ProdutoId = produtoId;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
            Referencia = referencia;
        }
    }
}