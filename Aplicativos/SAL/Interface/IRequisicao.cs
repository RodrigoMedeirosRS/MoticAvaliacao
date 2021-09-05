namespace SAL.Interface
{
    public interface IRequisicao
    {
        S ExecutarPost<T, S>(string url, T Corpo);
        string ExecutarGet(string requisicao);
    }
}