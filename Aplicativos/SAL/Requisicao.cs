using System;
using System.IO;
using System.Net;
using System.Configuration;
using Newtonsoft.Json;
using RestSharp;

using SAL.Interface;

namespace SAL
{
    public class Requisicao : IRequisicao
    {
        public S ExecutarPost<T, S>(string url, T Corpo)
        {
            var client = DefinirCliente(url);
            var request = CriarRequisicao(JsonConvert.SerializeObject(Corpo));
            return JsonConvert.DeserializeObject<S>(EnviarPOST(client, request));
        }

        public string ExecutarGet(string requisicao)
        {
            try
            {
                using (var resposta = EnviarGET(requisicao))
                {
                    string textoResposta = ObterResposta(resposta);
                    return textoResposta;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private RestRequest CriarRequisicao(string body)
        {
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "*/*");
            request.AddHeader("Cache-Control", "no-cache");
            //if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["UrlHost"]))
            //   request.AddHeader("Host", ConfigurationManager.AppSettings["UrlHost"]);
            request.AddHeader("Accept-Encoding", "gzip, deflate, br");
            request.AddHeader("Content-Length", body.Length.ToString());
            request.AddHeader("Connection", "keep-alive");
            request.AddJsonBody(body);
            request.ReadWriteTimeout = 60000;
            return request;
        }

        private RestClient DefinirCliente(string url)
        {
            var client = new RestClient(url);
            client.ReadWriteTimeout = 60000;
            return client;
        }

        private string ObterResposta(WebResponse resposta)
        {
            var streamDados = resposta.GetResponseStream();
            StreamReader reader = new StreamReader(streamDados);
            var textoResposta = reader.ReadToEnd().ToString();

            reader.Close();
            streamDados.Close();
            return textoResposta;
        }

        private string EnviarPOST(RestClient client, RestRequest request)
        {
            IRestResponse response = client.Execute(request);
            return response.Content.ToString();
        }

        private WebResponse EnviarGET(string requisicao)
        {
            var requisicaoWeb = WebRequest.CreateHttp(requisicao);
            requisicaoWeb.Method = "GET";
            var resposta = requisicaoWeb.GetResponse();
            return resposta;
        }
    }
}