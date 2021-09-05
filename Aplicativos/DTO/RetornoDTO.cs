namespace DTO
{
    public class RetornoDTO<ContentType>
    {
        public RetornoDTO()
        {
            Mensagem = "Sucesso";
        }
        public RetornoDTO(ContentType conteudo)
        {
            Mensagem = "Sucesso";
            Conteudo = conteudo;
        }
        public string Mensagem { get; set; }
        public ContentType Conteudo { get; set; }
    }
}