namespace DTO
{
    public class RetornoDTO<ContentType>
    {
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
        public ContentType Conteudo { get; set; }
    }
}