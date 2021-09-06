using Godot;
using BLL.Utils;
using BLL.Interface;

namespace BLL
{
    public class DashboardBLL : IDashboardBLL
    {
        public void InstanciarTab(TabContainer container, string caminhoTab, string nomeTab)
        {
            var cena = InstanciadorUtil.CarregarCena(caminhoTab);
            InstanciadorUtil.InstanciarTab(container, nomeTab, caminhoTab, false);
            container.CurrentTab = container.GetChildCount() -1;             
        }
        public void LimparMenuLateral(TabContainer container)
        {
            InstanciadorUtil.DecarregarFilhos(container);
        }
    }
}