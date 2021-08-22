namespace DTO
{
    public class RetornoDTO<ContentType>
    {
        public RetornoDTO()
        {
            Mensagem = "Sucesso";
            Sucesso = true;
        }
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public ContentType Conteudo { get; set; }
    }
}