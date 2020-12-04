namespace Logstore.HungryPizza.Application.SharedKernel
{
    public class EnderecoDto
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Municipio { get; set; }
        public string Cep { get; set; }

        public EnderecoDto() { }

        public EnderecoDto(string logradouro, string bairro, string numero, string complemento, string municipio, string cep)
        {
            Logradouro = logradouro;
            Bairro = bairro;
            Numero = numero;
            Complemento = complemento;
            Municipio = municipio;
            Cep = cep;
        }
    }
}